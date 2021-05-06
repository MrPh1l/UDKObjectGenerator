using System;
using System.Linq;
using System.Text.RegularExpressions;
using UELib.Core;

namespace UDKObjectPaster.NameTable
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
            Console.Write($"Processing '{UObj.Name}' ... ");

            if (UseInvisitek)
            {
                var lines = TextObject.Split(new[] { '\r', '\n' }).ToList();
                // TODO: Replace Materials by InvisiTekMaterials when its not set to 'none'
                //       Also, delete InvisiTekMaterials row
            }

            if (UseLayers)
            {
                var layerName = "\r\n\tLayer=\"GEN_" + UObj.NameTable.Name + "\"";

                if (TextObject.Contains("Layer="))
                    TextObject = Regex.Replace(TextObject, "Layer=.+\\n", layerName);
                else
                    TextObject += layerName;
            }

            return TextObject;
        }
    }
}
