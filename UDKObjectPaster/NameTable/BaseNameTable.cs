using System;
using System.Linq;
using UELib.Core;

namespace UDKObjectPaster.NameTable
{
    public class BaseNameTable
    {
        protected UObject UObj;
        protected string TextObject;
        protected string FileName;
        protected bool UseInvisitek;

        public BaseNameTable(UObject uObj, string fileName, bool useInvisitek)
        {
            UObj = uObj;
            TextObject = uObj.Decompile();
            FileName = fileName;
            UseInvisitek = useInvisitek;
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

            return TextObject;
        }
    }
}
