using System;
using System.Text.RegularExpressions;
using UELib.Core;

namespace UDKObjectGenerator.NameTable
{
    public class SceneCaptureCubeMapActor : BaseNameTable
    {
        public SceneCaptureCubeMapActor(UObject uObj, string fileName, bool useInvisitek, bool useLayers) : base(uObj, fileName, useInvisitek, useLayers) { }

        public override string ProcessString()
        {
            base.ProcessString();

            TextObject =
                "Begin Actor Class=SceneCaptureCubeMapActor Name=SceneCaptureCubeMapActor_0 Archetype=SceneCaptureCubeMapActor'Engine.Default__SceneCaptureCubeMapActor'\r\n\t" +
                TextObject +
                "\r\nEnd Actor\r\n";

            var lines = TextObject.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var objectCreated = false;
            var inObject = false;
            var inObjectToIgnore = false;
            var finalString = "";

            foreach (var line in lines)
            {
                if (inObjectToIgnore && line.ToLower().Contains("object end"))
                {
                    inObjectToIgnore = false;
                    continue;
                }

                if (inObjectToIgnore)
                    continue;

                if (Regex.IsMatch(line, @"begin object name=\w+ class=StaticMeshComponent", RegexOptions.IgnoreCase))
                {
                    inObjectToIgnore = true;
                    continue;
                }

                if (!objectCreated)
                {
                    if (Regex.IsMatch(line, @"begin object name=\w+ class=SceneCaptureCubeMapActor", RegexOptions.IgnoreCase))
                        continue;

                    if (line.ToLower().Contains("begin object "))
                        finalString += "\t\t" + line + " ObjName=SceneCaptureCubeMapComponent_0 Archetype=SceneCaptureCubeMapComponent'Engine.Default__SceneCaptureCubeMapActor:SceneCaptureCubeMapComponent0'\r\n";
                    else
                    {
                        if (line.ToLower().Contains("object end"))
                        {
                            finalString += "\t\t\tEnd Object\r\n";
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
                        && !line.ToLower().Contains("staticmesh=")
                        && !line.ToLower().Contains("scenecapture="))
                        finalString += "\t\t" + line + "\r\n";

                    if (line.ToLower().Contains("object end"))
                        inObject = false;
                }
            }

            Console.WriteLine("Done.");
            return finalString;
        }
    }
}
