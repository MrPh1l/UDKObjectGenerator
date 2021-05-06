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

            // TODO: improve logic to allow those args in any order
            var useInvisitek = args.Length > 1 && args[1].ToLower() == "--invisitek";
            var useLayers = args.Length > 2 && args[2].ToLower() == "--layers";

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

                //if (obj.NameTable.Name == "PlayerStart_TA") // Only use one NameTable during my tests until they're all implemented
                //{
                var nameTable = NameTableFactory.GetNameTable(obj, fileName, useInvisitek, useLayers);

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
