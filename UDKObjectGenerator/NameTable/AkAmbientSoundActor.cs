using System;
using System.Text.RegularExpressions;
using UELib.Core;

namespace UDKObjectGenerator.NameTable
{
    public class AkAmbientSoundActor : BaseNameTable
    {
        public AkAmbientSoundActor(UObject uObj, string fileName, bool useInvisitek, bool useLayers) : base(uObj, fileName, useInvisitek, useLayers)
        {
        }

        public override string ProcessString()
        {
            base.ProcessString();
            TextObject =
                "Begin Actor Class=AkAmbientSoundActor Name=AkAmbientSoundActor_0 Archetype=AkAmbientSoundActor'akaudio.Default__AkAmbientSoundActor'\r\n" +
                TextObject +
                "\r\nEnd Actor\r\n";

            TextObject = TextObject.Replace("AkSoundCue'", $"AkSoundCue'{FileName}.");

            var finalString = "";
            var objectCreated = false;
            var inObject = false;

            var lines = TextObject.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                if (!objectCreated)
                {
                    if (Regex.IsMatch(line, @"begin object name=\w+ class=AkAmbientSoundActor", RegexOptions.IgnoreCase))
                        continue;

                    if (line.ToLower().Contains("begin object "))
                        finalString += "\t\t" + line + " ObjName=AkPlaySoundComponent_0\r\n";
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
                        if (line.ToLower().Contains("playsoundcomponent="))
                            finalString += "\t\t\tPlaySoundComponent=AkPlaySoundComponent_0\r\n";
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
