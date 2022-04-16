﻿namespace UELib.Dummy
{
    class Material : MinimalBase
    {
        protected override byte[] MinimalByteArray { get; } =
        {
            0xFF, 0xFF, 0xFF, 0xFF, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF5, 0xF5, 0x04, 0xEC,
            0x14, 0x8F, 0x83, 0x4E, 0xA1, 0x24, 0xA4, 0x09, 0x91, 0x57, 0x82, 0xFC, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };


        public Material(UExportTableItem exportTableItem, UnrealPackage package) : base(exportTableItem, package)
        {
            FixNameIndexAtPosition(package, "None", 4);
        }


        protected override void WriteSerialData(IUnrealStream stream, UnrealPackage package)
        {
            stream.Write(MinimalByteArray, 0, MinimalByteArray.Length);
        }
    }

    /* Just use the DefaultDummy for mics for now
    class MaterialInstanceConstant : MinimalBase
    {
        private const int SerialSize = 12;


        protected override byte[] MinimalByteArray { get; } =
        {
            0xFF, 0xFF, 0xFF, 0xFF, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };

        public override void WriteSerialData(IUnrealStream stream, UnrealPackage package)
        {
            FixNameIndexAtPosition(package, "None", 4);
            stream.Write(MinimalByteArray, 0, SerialSize);
        }

        public override int SerialSize()
        {
            return SerialSize;
        }

        public MaterialInstanceConstant(UExportTableItem exportTableItem, UnrealPackage package) : base(exportTableItem, package)
        {
        }
    }
    */
}