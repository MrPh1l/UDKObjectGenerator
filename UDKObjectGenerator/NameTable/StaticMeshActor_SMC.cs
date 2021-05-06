using System;
using UELib.Core;

namespace UDKObjectGenerator.NameTable
{
    public class StaticMeshActor_SMC : BaseNameTable
    {
        public StaticMeshActor_SMC(UObject uObj, string fileName, bool useInvisitek, bool useLayers) : base(uObj, fileName, useInvisitek, useLayers) { }

        public override string ProcessString()
        {
            base.ProcessString();
            TextObject = 
                "Begin Actor Class=StaticMeshActor Name=StaticMeshActor_0 Archetype=StaticMeshActor'Engine.Default__StaticMeshActor'\r\n" +
                TextObject +
                "\r\nEnd Actor\r\n";

            TextObject = TextObject.Replace("StaticMesh'", $"StaticMesh'{FileName}.");
            TextObject = TextObject.Replace("MaterialInstanceConstant'", $"MaterialInstanceConstant'{FileName}.");
            TextObject = TextObject.Replace("Material'", $"Material'{FileName}.");
            TextObject = TextObject.Replace("EDetailMode.", "");
            TextObject = TextObject.Replace("Translation=", "Location=");
            TextObject = TextObject.Replace("\tScale3D=", "\tDrawScale3D=");

            var finalString = "";
            var stringToMoveInsideObject = "";
            var stringToMoveAfterObject = "";

            var lines = TextObject.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                if (line.ToLower().Contains("begin object "))
                {
                    finalString += "\t\t" + line + " ObjName=StaticMeshComponent_0 Archetype=StaticMeshComponent'Engine.Default__StaticMeshActor:StaticMeshComponent0'\r\n";
                    finalString += stringToMoveInsideObject;
                }
                else
                {
                    if (line.ToLower().Contains("location") || line.ToLower().Contains("rotation") || line.ToLower().Contains("drawscale3d"))
                        stringToMoveAfterObject += "\t\t" + line + "\r\n";
                    else if (line.ToLower().Contains("object end"))
                        finalString += "\t\tEnd Object\r\n" + stringToMoveAfterObject + "\r\n";
                    else
                        finalString += "\t\t" + line + "\r\n";
                }
            }

            Console.WriteLine("Done.");
            return finalString;
        }
    }
}
