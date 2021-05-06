using System;
using System.IO;
using System.Windows.Forms;
using UDKObjectGenerator.NameTable;
using UELib;

namespace UDKObjectGenerator
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
            Console.SetOut(new ControlWriter(txtBoxConsole));
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (!bgWorkerGeneration.IsBusy)
                bgWorkerGeneration.RunWorkerAsync();
        }

        private void BgWorkerGeneration_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            btnGenerate.Text = "Generating ...";
            splitContainer1.Panel1.Enabled = false;

            if (!File.Exists(filePath))
                return;

            var fileName = Path.GetFileNameWithoutExtension(filePath);

            if (fileName == null)
                return;

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

                if (lstBoxTypesToGenerate.SelectedItems.Count == 0
                    || lstBoxTypesToGenerate.SelectedItems.Contains(obj.NameTable.Name))
                {
                    //if (obj.NameTable.Name == "StaticMeshActor_SMC") // Only use one NameTable during my tests until they're all implemented
                    //if (obj.Name == "StaticMeshActor_SMC_39")
                    //{
                    var nameTable = NameTableFactory.GetNameTable(obj, fileName, chckBoxInvisitek.Checked, chckBoxLayers.Checked);

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
            btnGenerate.Text = "Generate";
            splitContainer1.Panel1.Enabled = true;
        }

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
