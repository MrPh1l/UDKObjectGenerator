using System;
using System.Linq;
using System.Text.RegularExpressions;
using UELib.Core;

namespace UDKObjectPaster.NameTable
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
            TextObject = TextObject.Replace("InvisiTekMaterials'", $"InvisiTekMaterials'{FileName}.");
            TextObject = TextObject.Replace("EDetailMode.", "");
            TextObject = TextObject.Replace("Translation=", "Location=");
            TextObject = TextObject.Replace("\tScale3D=", "\tDrawScale3D=");

            var finalString = "";
            var stringToMoveInsideObject = "";
            var stringToMoveAfterObject = "";
            var objectCreated = false;
            var inObject = false;

            var lines = TextObject.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            if (UseInvisitek)
            {
                var materialLines = lines.Where(line => Regex.IsMatch(line, @"(?<!InvisiTek)Materials\([0-9]{1}\)=", RegexOptions.IgnoreCase)).ToList(); // TODO: don't get duplicates
                var invisiTekMaterialLines = lines.Where(line => Regex.IsMatch(line, @"InvisiTekMaterials\([0-9]{1}\)=", RegexOptions.IgnoreCase)).ToList(); // TODO: don't get duplicates

                for (int i = 0; i < materialLines.Count; i++)
                {
                    if (invisiTekMaterialLines.Count > i && !invisiTekMaterialLines[i].ToLower().Contains("=none"))
                        stringToMoveInsideObject += "\t\t\t" + invisiTekMaterialLines[i].Replace("InvisiTekMaterials", "Materials") + "\r\n";
                    else
                        stringToMoveInsideObject += "\t\t\t" + materialLines[i] + "\r\n";
                }

                lines.ToList().RemoveAll(line =>
                    Regex.IsMatch(line, @"Materials\([0-9]{1}\)=", RegexOptions.IgnoreCase)
                    || Regex.IsMatch(line, @"InvisiTekMaterials\([0-9]{1}\)=", RegexOptions.IgnoreCase)); // TODO: Not working. Lines don't get removed
            }

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
