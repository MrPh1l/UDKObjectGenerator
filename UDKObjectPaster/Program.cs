using System;
using System.IO;
using System.Windows.Forms;
using UDKObjectPaster.NameTable;
using UELib;

namespace UDKObjectPaster
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length < 1 || !File.Exists(args[0]))
                return;

            var fileName = Path.GetFileNameWithoutExtension(args[0]);

            if (fileName == null)
                return;

            var useInvisitek = args.Length > 1 && args[1].ToLower() == "--invisitek";

            Console.Write("Loading package ... ");
            var package = UnrealLoader.LoadFullPackage(args[0], FileAccess.Read);
            Console.WriteLine("Done.");
            var finalString =
                "Begin Map\r\n" +
                    "\tBegin Level\r\n";

            foreach (var obj in package.Objects)
            {
                if (obj.ExportTable == null || obj.Name == "None")
                    continue;

                //if (obj.NameTable.Name == "DynamicMeshActor_TA") // Only use one NameTable during my tests until they're all implemented
                //{
                var nameTable = NameTableFactory.GetNameTable(obj, fileName, useInvisitek);

                if (nameTable != null)
                    finalString += nameTable.ProcessString();
                //}

                continue;
            }

            finalString +=
                    "\tEnd Level\r\n" +
                    "\tBegin Surface\r\n" +
                    "\tEnd Surface\r\n" +
                "End Map";

            Clipboard.SetText(finalString);
        }
    }
}
