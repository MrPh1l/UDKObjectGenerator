using System;
using UELib.Core;

namespace UDKObjectGenerator.NameTable
{
    public static class NameTableFactory
    {
        public static BaseNameTable GetNameTable(UObject uObj, string fileName, bool useInvisitek, bool useLayers)
        {
            switch (uObj.NameTable.Name)
            {
                case "DynamicMeshActor_TA":
                    return new DynamicMeshActor_TA(uObj, fileName, useInvisitek, useLayers);
                case "InterpActor":
                    return new InterpActor(uObj, fileName, useInvisitek, useLayers);
                case "PlayerStart_TA":
                    return new PlayerStart_TA(uObj, fileName, useInvisitek, useLayers);
                case "StaticMeshActor":
                    return new StaticMeshActor(uObj, fileName, useInvisitek, useLayers);
                case "StaticMeshActor_SMC":
                    return new StaticMeshActor_SMC(uObj, fileName, useInvisitek, useLayers);
                default:
                    Console.WriteLine($"Class not implemented for '{uObj.NameTable.Name}'.");
                    return null;
            }
        }
    }
}
