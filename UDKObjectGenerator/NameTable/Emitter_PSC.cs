using System;
using UELib.Core;

namespace UDKObjectGenerator.NameTable
{
    public class Emitter_PSC : BaseNameTable
    {
        public Emitter_PSC(UObject uObj, string fileName, bool useInvisitek, bool useLayers) : base(uObj, fileName, useInvisitek, useLayers) { }

        public override string ProcessString()
        {
            base.ProcessString();
            TextObject =
                "Begin Actor Class=Emitter Name=Emitter_0 Archetype=Emitter'Engine.Default__Emitter'\r\n" +
                TextObject;
                

            TextObject = TextObject.Replace("EDetailMode.", "");
            TextObject = TextObject.Replace("ParticleSystem'", $"ParticleSystem'{FileName}.");
            TextObject = TextObject.Replace("Translation=", "Location=");
            TextObject = TextObject.Replace("\tScale3D=", "\tDrawScale3D=");

            var finalString = "";
            var stringToMoveAfterObject = "";
            var objectCreated = false;

            var lines = TextObject.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                if (line.ToLower().Contains("begin object "))
                    finalString += "\t\t\t" + line + " ObjName=ParticleSystemComponent_0 Archetype=ParticleSystemComponent'Engine.Default__Emitter:ParticleSystemComponent0'\r\n";
                else
                {
                    if (line.ToLower().Contains("location") || line.ToLower().Contains("rotation")
                        || line.ToLower().Contains("drawscale3d"))
                        stringToMoveAfterObject += "\t\t" + line + "\r\n";
                    else if (line.ToLower().Contains("object end"))
                    {
                        finalString += "\t\t\tEnd Object\r\n" + stringToMoveAfterObject + "\r\n";
                        objectCreated = true;
                    }
                    else
                    {
                        if (!objectCreated && !line.ToLower().Contains("begin actor"))
                            finalString += "\t\t\t" + line + "\r\n";
                        else
                            finalString += "\t\t" + line + "\r\n";
                    }
                }
            }

            finalString += "\t\tEnd Actor\r\n";

            Console.WriteLine("Done.");
            return finalString;
        }
    }
}
