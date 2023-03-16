using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UELib.Core;

namespace UDKObjectGenerator.NameTable
{
    public class BaseNameTable
    {
        protected UObject UObj;
        protected string TextObject;
        protected string FileName;
        protected bool UseInvisitek;
        protected bool UseLayers;

        public BaseNameTable(UObject uObj, string fileName, bool useInvisitek, bool useLayers)
        {
            UObj = uObj;
            TextObject = uObj.Decompile();
            FileName = fileName;
            UseInvisitek = useInvisitek;
            UseLayers = useLayers;
        }

        public virtual string ProcessString()
        {
            Console.Write($"Processing '{UObj.Name}' of type '{UObj.GetClassName()}' ... ");

            if (UseInvisitek)
            {
                var lines = TextObject.Split(new[] { '\r', '\n' }).ToList();
                var materialLines = lines.Where(line => Regex.IsMatch(line, @"(?<!InvisiTek)Materials\([0-9]{1}\)=", RegexOptions.IgnoreCase)).Select(line => new
                {
                    index = line.Substring(line.IndexOf("(") + 1, line.IndexOf(")") - line.IndexOf("(") - 1),
                    materialValue = line.Substring(line.IndexOf("=") + 1)
                });
                var invisiTekMaterialLines = lines.Where(line => Regex.IsMatch(line, @"InvisiTekMaterials\([0-9]{1}\)=", RegexOptions.IgnoreCase)).Select(line => new
                {
                    index = line.Substring(line.IndexOf("(") + 1, line.IndexOf(")") - line.IndexOf("(") - 1),
                    materialValue = line.Substring(line.IndexOf("=") + 1)
                });

                if (invisiTekMaterialLines.Any())
                {
                    var updatedMaterialLines = new List<string>();

                    foreach (var materialLine in materialLines)
                    {
                        var invisiTekMaterialLine = invisiTekMaterialLines.FirstOrDefault(line => line.index == materialLine.index);

                        if (invisiTekMaterialLine != null && invisiTekMaterialLine.materialValue.ToLower() != "none")
                            updatedMaterialLines.Add("\tMaterials(" + materialLine.index + ")=" + invisiTekMaterialLine.materialValue);
                        else
                            updatedMaterialLines.Add("\tMaterials(" + materialLine.index + ")=" + materialLine.materialValue);
                    }

                    var materialStartIndex = lines.FindIndex(line => line.ToLower().Contains("materials(0)="));
                    lines.RemoveAll(line => Regex.IsMatch(line, @"Materials\([0-9]{1}\)=", RegexOptions.IgnoreCase));
                    lines.InsertRange(materialStartIndex, updatedMaterialLines);
                    TextObject = string.Join("\r\n", lines.Where(line => !string.IsNullOrWhiteSpace(line)));
                }
            }

            if (UseLayers)
            {
                var layerName = "\r\n\tLayer=\"" + UObj.Package.PackageName + "__" + UObj.NameTable.Name + "\"";

                if (TextObject.Contains("Layer="))
                    TextObject = Regex.Replace(TextObject, "Layer=.+\\n", layerName);
                else
                    TextObject += layerName;
            }

            return TextObject;
        }
    }
}
