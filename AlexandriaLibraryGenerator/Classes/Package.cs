using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UELib;

namespace AlexandriaLibraryGenerator.Classes
{
    internal class Package
    {
        private readonly string Name;
        private readonly Vector2 KismetLoc;
        public List<string> Materials { get; set; } = new List<string>();

        public Package(string packageName, Vector2 kismetLoc, UnrealPackage unrealPackage)
        {
            Name = packageName;
            KismetLoc = kismetLoc;

            var materials = unrealPackage.Objects.Where(obj => obj.ExportTable != null && obj.Name != "None" &&
                (obj.GetClassName() == "Material" || obj.GetClassName() == "MaterialInstanceConstant")).ToList();

            foreach (var material in materials)
            {
                Materials.Add($"{material.GetClassName()}'{Name}.{material.GetOuterGroup()}'");
            }
        }

        public string GetSerialized()
        {
            if (!Materials.Any())
                return "";

            Console.WriteLine($"Package -> Starting serialization for package {Name}.");

            var serializedObjectList =
                "Begin Object Class=SeqVar_ObjectList Name=SeqVar_ObjectList_2\n";

            for (int i = 0; i < Materials.Count; i++)
            {
                serializedObjectList +=
                    $"\tObjList({i})={Materials[i]}\n";
            }

            serializedObjectList +=
                    $"\tVarName=\"mats_{Name}\"\n" +
                    "\tObjInstanceVersion=1\n" +
                    "\tParentSequence=Sequence'Main_Sequence'\n" +
                    $"\tObjPosX={KismetLoc.X}\n" +
                    $"\tObjPosY={KismetLoc.Y}\n" +
                    "\tDrawWidth=32\n" +
                    "\tDrawHeight=32\n" +
                    "\tName=\"SeqVar_ObjectList_2\"\n" +
                    "\tObjectArchetype=SeqVar_ObjectList'Engine.Default__SeqVar_ObjectList'\n" +
                "End Object\n";

            Console.WriteLine($"Package -> Serialization done for package {Name}.");
            return serializedObjectList;
        }
    }
}
