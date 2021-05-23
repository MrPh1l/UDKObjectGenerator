using System;
using System.Text.RegularExpressions;
using UELib.Core;

namespace UDKObjectGenerator.NameTable
{
    public class LensFlareSource : BaseNameTable
    {
        public LensFlareSource(UObject uObj, string fileName, bool useInvisitek, bool useLayers) : base(uObj, fileName, useInvisitek, useLayers) { }

        public override string ProcessString()
        {
            base.ProcessString();
            TextObject =
                "Begin Actor Class=LensFlareSource Name=LensFlareSource_0 Archetype=LensFlareSource'Engine.Default__LensFlareSource'\r\n" +
                TextObject +
                "\r\nEnd Actor\r\n";

            TextObject = TextObject.Replace("EDetailMode.", "");
            TextObject = TextObject.Replace("ESceneDepthPriorityGroup.", "");
            TextObject = TextObject.Replace("LensFlare'", $"LensFlare'{FileName}.");
            TextObject = TextObject.Replace("Translation=", "Location=");
            TextObject = TextObject.Replace("\tScale3D=", "\tDrawScale3D=");

            var finalString = "";
            var objectCreated = false;
            var inObject = false;

            var lines = TextObject.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                if (!objectCreated)
                {
                    if (Regex.IsMatch(line, @"begin object name=\w+ class=LensFlareSource", RegexOptions.IgnoreCase))
                        continue;

                    if (line.ToLower().Contains("begin object "))
                        finalString += "\t\t" + line + " ObjName=LensFlareComponent_0 Archetype=LensFlareComponent'Engine.Default__LensFlareSource:LensFlareComponent0'\r\n";
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

                    if (!inObject && !line.ToLower().Contains("object end"))
                    {
                        if (line.ToLower().Contains("lensflarecomp="))
                            finalString += "\t\t\tLensFlareComp=LensFlareComponent_0\r\n";
                        else if (!Regex.IsMatch(line, @"components\([0-9]+\)=", RegexOptions.IgnoreCase))
                            finalString += "\t\t" + line + "\r\n";
                    }

                    if (line.ToLower().Contains("object end"))
                        inObject = false;
                }
            }

            Console.WriteLine("Done.");
            return finalString;
        }
    }
}
