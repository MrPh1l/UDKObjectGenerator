using System.Text.RegularExpressions;
using System;
using UELib.Core;
using System.Xml.Linq;

namespace UDKObjectGenerator.NameTable
{
    public class ExponentialHeightFog : BaseNameTable
    {
        public ExponentialHeightFog(UObject uObj, string fileName, bool useInvisitek, bool useLayers) : base(uObj, fileName, useInvisitek, useLayers) { }

        public override string ProcessString()
        {
            base.ProcessString();

            TextObject =
                "Begin Actor Class=ExponentialHeightFog Name=ExponentialHeightFog_0 Archetype=ExponentialHeightFog'Engine.Default__ExponentialHeightFog'\r\n" +
                TextObject +
                "\r\nEnd Actor\r\n";

            var lines = TextObject.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var objectCreated = false;
            var inObject = false;
            var finalString = "";

            foreach (var line in lines)
            {
                if (!objectCreated)
                {
                    if (Regex.IsMatch(line, "begin object name=ExponentialHeightFog class=ExponentialHeightFog", RegexOptions.IgnoreCase))
                        continue;

                    if (line.ToLower().Contains("begin object "))
                        finalString += "\t\t" + line + " ObjName=ExponentialHeightFogComponent_0 Archetype=ExponentialHeightFogComponent'Engine.Default__ExponentialHeightFog:HeightFogComponent0'\r\n";
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
                        && !line.ToLower().Contains("component="))
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
