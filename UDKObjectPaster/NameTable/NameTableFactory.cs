using System;
using UELib.Core;

namespace UDKObjectPaster.NameTable
{
    public static class NameTableFactory
    {
        public static BaseNameTable GetNameTable(UObject uObj, string fileName, bool useInvisitek)
        {
            switch (uObj.NameTable.Name)
            {
                case "DynamicMeshActor_TA":
                    return new DynamicMeshActor_TA(uObj, fileName, useInvisitek);
                case "InterpActor":
                    return new InterpActor(uObj, fileName, useInvisitek);
                case "PlayerStart_TA":
                    return new PlayerStart_TA(uObj, fileName, useInvisitek);
                case "StaticMeshActor":
                    return new StaticMeshActor(uObj, fileName, useInvisitek);
                case "StaticMeshActor_SMC":
                    return new StaticMeshActor_SMC(uObj, fileName, useInvisitek);
                default:
                    Console.WriteLine($"Class not implemented for '{uObj.NameTable.Name}'.");
                    return null;
            }
        }
    }
}
