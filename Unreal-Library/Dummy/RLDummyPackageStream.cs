﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UELib.Dummy
{

    public class RLDummyPackageStream : UPackageStream, IUnrealStream
    {
        private const int DummyPackageFlag = 1;
        private const int DummyFileVersion = 868;
        private const int DummyLicenseeVersion = 0;
        private const int DummyEngineVersion = 12791;
        private const int DummyCookerVersion = 0;
        private const int DummyCompression = 0;
        private const int DummyCompressedChunksData = 0;
        private const int DummyUnknown5 = 0;
        private const int DummyUnknownStringArray = 0;
        private const int DummyUnknownTypeArray = 0;

        private const int NameCountPosition = 25;
        private const int ExportCountPosition = 33;
        private const int ImportCountPosition = 41;

        private const int TotalHeaderSizePosition = 8;

        private UnrealPackage package;

        //public uint Version { get; set; }

        public RLDummyPackageStream(UnrealPackage package, string filePath)
        {
            this.package = package;
            var fileStream = File.Open(filePath, FileMode.Create, FileAccess.Write);
            _stream = fileStream;
            Package = package;

            UW = new RLPackageWriter(_stream, DummyEngineVersion);
            MinimalTexture2D.AddNamesToNameTable(package);
        }

        private const int ExportTableItemSize = 68;
        private const int DependsOffsetPosition = 49;
        private const int ThumbnailDataOffsetPosition = 53;
        private const int ThumbnailTableOffsetPosition = 65;

        public void Serialize()
        {
            initHeader();
            SerializeNameTable();
            SerializeImportsTable();

            List<DummyExportTableItem> exportsToSerialize = GetExportsToSerialize();

            var exportOffset = UW.BaseStream.Position;
            WriteIntAtPosition(exportsToSerialize.Count(), ExportCountPosition);
            WriteIntAtPosition((int)exportOffset, ExportCountPosition + 4);


            //This comes after. But we need to know it's size. so we can set the serialOffsets for the export items.
            var thumbnails = new ThumbnailTable();
            thumbnails.Init(exportsToSerialize);
            var thumbnailsTotalSize = thumbnails.GetSerialSize();

            //TODO - understand this table...
            var dependsTotalSize = exportsToSerialize.Count() * 4;

            int footerNumbers = 8;
            int calculatedTotalHeaderSize = (int)(UW.BaseStream.Position + ExportTableItemSize * exportsToSerialize.Count()) + thumbnailsTotalSize + dependsTotalSize;
            int serialOffset = calculatedTotalHeaderSize;
            foreach (var dummyExport in exportsToSerialize)
            {
                var export = dummyExport.original;
                switch (export.ClassName)
                {
                    case "Texture2D":
                        DummyExportTableSerialize(dummyExport, serialOffset, MinimalTexture2D.serialSize);
                        serialOffset += MinimalTexture2D.serialSize;
                        break;
                    case "StaticMesh":
                        DummyExportTableSerialize(dummyExport, serialOffset, MinimalStaticMesh.serialSize);
                        serialOffset += MinimalStaticMesh.serialSize;
                        break;
                    case "class":
                        if (export.SerialSize == 0)
                        {
                            DummyExportTableSerialize(dummyExport, 0, 0);
                        }
                        break;
                    default:
                        DummyExportTableSerialize(dummyExport, serialOffset, DummySerialSize);
                        serialOffset += DummySerialSize;
                        break;
                }

                //export.Serialize( this );
            }
            //unknown footer info
            SerializeDependsTable(exportsToSerialize.Count());

            thumbnails.Serialize(this);
            WriteIntAtPosition(thumbnails.thumbnailDataOffset, ThumbnailDataOffsetPosition);
            WriteIntAtPosition(thumbnails.thumbnailTableOffset, ThumbnailTableOffsetPosition);

            WriteIntAtPosition((int)UW.BaseStream.Position, TotalHeaderSizePosition);

            int noneIndex = package.Names.FindIndex((n) => n.Name == "None");
            foreach (var dummyExport in exportsToSerialize)
            {
                var exportObject = dummyExport.original;
                switch (exportObject.ClassName)
                {
                    case "Texture2D":
                        new MinimalTexture2D().Write(this, package);
                        break;

                    case "StaticMesh":
                        new MinimalStaticMesh().Write(this, package);
                        break;
                    case "class":
                        if (exportObject.SerialSize == 0)
                        {
                            break;
                        }
                        break;
                    default:
                        //We just need the netindex and a None FName
                        package.Stream.Position = exportObject.SerialOffset;
                        //NetIndex
                        UW.Write(package.Stream.ReadInt32());
                        //None index and count
                        UW.Write(noneIndex);
                        UW.Write(0);
                        break;
                }
            }
            for (int ii = 0; ii < 250; ii++)
            {
                UW.Write(0);
            }
        }

        private void SerializeDependsTable(int exportCount)
        {
            WriteIntAtPosition((int)UW.BaseStream.Position, DependsOffsetPosition);
            for (int i = 0; i < exportCount; i++)
            {
                UW.Write(0);
            }
        }

        private List<DummyExportTableItem> GetExportsToSerialize()
        {
            var exportsToSerialize = package.Exports.Where((e) => e.SerialSize != 0 && (e.OuterTable == null ||  e.OuterTable.ClassName == "Package"))
                .Select((e) => new DummyExportTableItem(e))
                .ToList();
            //exportsToSerialize = exportsToSerialize.Skip(2).Take(2).ToList();
            foreach (var export in exportsToSerialize)
            {
                FixObjectReferencesInFilteredExports(export, exportsToSerialize, package.Exports);
            }

            return exportsToSerialize;
        }

        private void SerializeImportsTable()
        {
            var importOffset = UW.BaseStream.Position;
            WriteIntAtPosition(package.Imports.Count(), ImportCountPosition);
            WriteIntAtPosition((int)importOffset, ImportCountPosition + 4);
            foreach (var import in package.Imports)
            {
                import.Serialize(this);
            }
        }

        private void SerializeNameTable()
        {
            var nameOffset = UW.BaseStream.Position;
            WriteIntAtPosition(package.Names.Count(), NameCountPosition);
            WriteIntAtPosition((int)nameOffset, NameCountPosition + 4);

            foreach (var name in package.Names)
            {
                name.Serialize(this);
            }
        }

        private void FixObjectReferencesInFilteredExports(DummyExportTableItem export, List<DummyExportTableItem> exportsToSerialize, List<UExportTableItem> exports)
        {
            export.newClassIndex = FindNewReference(export.original.ClassIndex, exportsToSerialize, exports);
            export.newSuperIndex = FindNewReference(export.original.SuperIndex, exportsToSerialize, exports);
            export.newOuterIndex = FindNewReference(export.original.OuterIndex, exportsToSerialize, exports);
            export.newArchetypeIndex = FindNewReference(export.original.ArchetypeIndex, exportsToSerialize, exports);
        }

        private int FindNewReference(int originalIndex, List<DummyExportTableItem> exportsToSerialize, List<UExportTableItem> exports)
        {
            if (originalIndex <= 0)
            {
                return originalIndex;
            }
            var reference = exports[originalIndex - 1];
            var newReferenceIndex = exportsToSerialize.FindIndex((e) => e.original == reference) + 1;
            return newReferenceIndex;
        }

        private void WriteIntAtPosition(int value, int writePosition)
        {
            var oldPosition = UW.BaseStream.Position;
            UW.BaseStream.Position = writePosition;
            UW.Write(value);
            UW.BaseStream.Position = oldPosition;
        }

        private void initHeader()
        {
            UW.BaseStream.Position = 0;
            //Tag
            UW.Write(UnrealPackage.Signature);
            //File Version
            var version = (int)(DummyFileVersion & 0x0000FFFFU) | DummyLicenseeVersion << 16;
            UW.Write(version);
            //Total HeaderSize will be calculated later
            UW.Write(0);
            //Group name
            UW.WriteString("None");
            //Package flags
            UW.Write(DummyPackageFlag);

            //Name / Import / Export count and offsets
            UW.Write(0);
            UW.Write(1);
            UW.Write(2);
            UW.Write(3);
            UW.Write(4);
            UW.Write(5);

            //DependsOffset / ImportExportGuidsOffset / ImportGuidsCount / ExportGuidsCount / ThumbnailTableOffset
            UW.Write(0);
            UW.Write(0);
            UW.Write(0);
            UW.Write(0);
            UW.Write(0);

            //guid (this might work?..)
            UW.Write(Guid.Parse(package.GUID).ToByteArray(), 0, 16);

            //Generations
            package.Generations.Serialize(this);

            //EngineVersion
            UW.Write(DummyEngineVersion);

            //CookerVersion
            UW.Write(DummyCookerVersion);
            //CompressionFlags
            UW.Write(DummyCompression);
            //compressedChunks
            UW.Write(DummyCompressedChunksData);
            //Unknown5
            UW.Write(DummyUnknown5);
            //UnknownStringArray
            UW.Write(DummyUnknownStringArray);
            //UnknownTypeArray
            UW.Write(DummyUnknownTypeArray);
        }

        private const int DummySerialSize = 12;

        private void DummyExportTableSerialize(DummyExportTableItem tableItem, int serialOffset, int serialSize)
        {
            this.Write(tableItem.newClassIndex);
            this.Write(tableItem.newSuperIndex);
            this.Write(tableItem.newOuterIndex);
            this.Write(tableItem.original.ObjectName);
            this.Write(tableItem.newArchetypeIndex);
            //this.Write(tableItem.ObjectFlags);
            if (tableItem.original.ClassName == "Package")
            {
                this.Write(1970342016843776);
            }else
            {
                this.Write(4222141830530048);
            }
            

            this.Write(serialSize);

            //this.Write(tableItem.SerialOffset);
            this.Write(serialOffset);
            //this.Write(tableItem.ExportFlags);
            this.Write(0);
            //Net objects count
            this.Write(0);

            //PackageGUID
            this.Write(0);
            this.Write(0);
            this.Write(0);
            this.Write(0);

            //Package flags
            if (tableItem.original.ClassName == "Package")
            {
                this.Write(1);
            }
            else
            {
                this.Write(0);
            }
        }
    }
}