using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UDKObjectPaster.NameTable;
using UELib;

namespace UDKObjectPaster
{
    public partial class MainForm : Form
    {
        private string generatedText = "";
        private string filePath = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //AllocConsole();
            Console.SetOut(new ControlWriter(txtBoxConsole));
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (!bgWorkerGeneration.IsBusy)
                bgWorkerGeneration.RunWorkerAsync();
        }

        private void BgWorkerGeneration_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (!File.Exists(filePath))
                return;

            var fileName = Path.GetFileNameWithoutExtension(filePath);

            if (fileName == null)
                return;

            // TODO: improve logic to allow those args in any order
            var useInvisitek = true;
            var useLayers = true;

            Console.Write("Loading package ... ");
            var package = UnrealLoader.LoadFullPackage(filePath, FileAccess.Read);
            Console.WriteLine("Done.");
            var finalString =
                "Begin Map\r\n" +
                    "\tBegin Level\r\n";

            foreach (var obj in package.Objects)
            {
                if (obj.ExportTable == null || obj.Name == "None")
                    continue;

                if (chkLstBoxTypesToGenerate.CheckedItems.Count == 0
                    || chkLstBoxTypesToGenerate.CheckedItems.Contains(obj.NameTable.Name))
                {
                    //if (obj.NameTable.Name == "StaticMeshActor_SMC") // Only use one NameTable during my tests until they're all implemented
                    //if (obj.Name == "StaticMeshActor_SMC_39")
                    //{
                    var nameTable = NameTableFactory.GetNameTable(obj, fileName, useInvisitek, useLayers);

                    if (nameTable != null)
                        finalString += nameTable.ProcessString();
                    //}
                }


                continue;
            }

            finalString +=
                    "\tEnd Level\r\n" +
                    "\tBegin Surface\r\n" +
                    "\tEnd Surface\r\n" +
                "End Map";

            generatedText = finalString;
        }

        private void BgWorkerGeneration_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Clipboard.SetText(generatedText);
            Console.WriteLine("Objects generation copied to clipboard.");
        }

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            filePath = openFileDialog1.FileName;
            lblFileName.Text = Path.GetFileName(openFileDialog1.FileName);
            btnGenerate.Enabled = true;
        }

        private void TxtBoxConsole_TextChanged(object sender, EventArgs e)
        {
            txtBoxConsole.SelectionStart = txtBoxConsole.Text.Length;
            txtBoxConsole.ScrollToCaret();
        }
    }
}
