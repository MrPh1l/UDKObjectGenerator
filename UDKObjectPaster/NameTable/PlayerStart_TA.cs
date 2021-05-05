using System;
using System.Text.RegularExpressions;
using UELib.Core;

namespace UDKObjectPaster.NameTable
{
    public class PlayerStart_TA : BaseNameTable
    {
        public PlayerStart_TA(UObject uObj, string fileName, bool useInvisitek) : base(uObj, fileName, useInvisitek) { }

        public override string ProcessString()
        {
            base.ProcessString();

            TextObject =
                "Begin Actor Class=PlayerStart_TA Name=PlayerStart_TA_0 Archetype=PlayerStart_TA'tagame.Default__PlayerStart_TA'\r\n" +
                TextObject +
                "\r\nEnd Actor\r\n";

            var lines = TextObject.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var skipObjectLines = false;
            var finalString = "";

            foreach (var line in lines)
            {
                if (line.ToLower().Contains("cylindercomponent=") || line.ToLower().Contains("collisioncomponent="))
                    continue;

                if (Regex.IsMatch(line, @"begin object .*class=PlayerStart_TA", RegexOptions.IgnoreCase)
                    || Regex.IsMatch(line, @"Components\([0-9]{1}\)=", RegexOptions.IgnoreCase))
                    continue;

                if (Regex.IsMatch(line, @"begin object .*class=CylinderComponent"))
                    skipObjectLines = true;

                if (!skipObjectLines && !line.ToLower().Contains("object end"))
                    finalString += "\t\t" + line + "\r\n";

                if (skipObjectLines && line.ToLower().Contains("object end"))
                    skipObjectLines = false;
            }

            Console.WriteLine("Done.");
            return finalString;
        }
    }
}
