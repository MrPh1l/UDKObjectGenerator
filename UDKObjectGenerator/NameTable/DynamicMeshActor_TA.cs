using System;
using System.Linq;
using System.Text.RegularExpressions;
using UELib.Core;

namespace UDKObjectGenerator.NameTable
{
    public class DynamicMeshActor_TA : BaseNameTable
    {
        public DynamicMeshActor_TA(UObject uObj, string fileName, bool useInvisitek, bool useLayers) : base(uObj, fileName, useInvisitek, useLayers) { }

        public override string ProcessString()
        {
            base.ProcessString();
            TextObject =
                "Begin Actor Class=DynamicMeshActor_TA Name=DynamicMeshActor_TA_0 Archetype=DynamicMeshActor_TA'Engine.Default__DynamicMeshActor_TA'\r\n" +
                TextObject;

            TextObject = TextObject.Replace("StaticMesh'", $"StaticMesh'{FileName}.");
            TextObject = TextObject.Replace("MaterialInstanceConstant'", $"MaterialInstanceConstant'{FileName}.");
            TextObject = TextObject.Replace("Material'", $"Material'{FileName}.");
            TextObject = TextObject.Replace("EDetailMode.", "");
            TextObject = TextObject.Replace("Translation=", "Location=");
            TextObject = TextObject.Replace("\tScale3D=", "\tDrawScale3D=");

            var finalString = "";
            var stringToMoveInsideObject = "";
            var stringToMoveAfterObject = "";
            var objectCreated = false;
            var inObject = false;

            var lines = TextObject.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                if (!objectCreated)
                {
                    if (Regex.IsMatch(line, @"begin object name=\w+ class=DynamicMeshActor_TA", RegexOptions.IgnoreCase))
                        continue;

                    if (line.ToLower().Contains("begin object "))
                    {
                        finalString += "\t\t" + line + " ObjName=StaticMeshComponent_0 Archetype=StaticMeshComponent'tagame.Default__DynamicMeshActor_TA:StaticMeshComponent0'\r\n";
                        finalString += stringToMoveInsideObject;
                    }
                    else
                    {
                        if (line.ToLower().Contains("location") || line.ToLower().Contains("rotation") || line.ToLower().Contains("drawscale3d"))
                            stringToMoveAfterObject += "\t\t" + line + "\r\n";
                        else if (line.ToLower().Contains("object end"))
                        {
                            finalString += "\t\t\tEnd Object\r\n" + stringToMoveAfterObject + "\r\n";
                            objectCreated = true;
                        }
                        else
                            finalString += "\t\t" + line + "\r\n";
                    }
                }
                else
                {
                    if (line.ToLower().Contains("begin object "))
                        inObject = true;

                    if (!inObject && !line.ToLower().Contains("object end")
                        && !Regex.IsMatch(line, @"components\([0-9]+\)=", RegexOptions.IgnoreCase)
                        && !line.ToLower().Contains("staticmeshcomponent=")
                        && !line.ToLower().Contains("collisioncomponent="))
                        finalString += "\t\t" + line + "\r\n";

                    if (line.ToLower().Contains("object end"))
                        inObject = false;
                }
            }

            finalString += "\t\tEnd Actor\r\n";

            Console.WriteLine("Done.");
            return finalString;
        }
    }
}
