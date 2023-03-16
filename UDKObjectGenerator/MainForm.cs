using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UDKObjectGenerator.AlexandriaLibrary;
using UDKObjectGenerator.NameTable;
using UELib;

namespace UDKObjectGenerator
{
    public partial class MainForm : Form
    {
        private Level MainLevel;
        private string rlCookedPCConsoleDir = "";
        private string generatedText = "";
        private string filePath = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Console.SetOut(new ControlWriter(txtBoxConsole));
            using var streamReader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\config.cfg");
            rlCookedPCConsoleDir = streamReader.ReadLine();
            streamReader.Close();
        }

        #region Package generation tab
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (!bgWorkerPackageGen.IsBusy)
                bgWorkerPackageGen.RunWorkerAsync();
        }

        private void BgWorkerPackageGen_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
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

                var objTopOuter = obj;

                while (objTopOuter.Outer != null)
                    objTopOuter = objTopOuter.Outer;

                if (objTopOuter.GetClassName() != "World")
                    continue;

                if (lstBoxTypesToGenerate.SelectedItems.Count == 0
                    || lstBoxTypesToGenerate.SelectedItems.Contains(obj.GetClassName()))
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

        private void BgWorkerPackageGen_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
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
        #endregion

        #region Alexandria library tab
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 && string.IsNullOrWhiteSpace(rlCookedPCConsoleDir))
            {
                if (folderBrowserDialogCookedPCConsole.ShowDialog() == DialogResult.OK
                    && !string.IsNullOrWhiteSpace(folderBrowserDialogCookedPCConsole.SelectedPath)
                    && folderBrowserDialogCookedPCConsole.SelectedPath.EndsWith("CookedPCConsole"))
                {
                    rlCookedPCConsoleDir = folderBrowserDialogCookedPCConsole.SelectedPath;
                    using var streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\config.cfg");
                    streamWriter.Write(rlCookedPCConsoleDir);
                    streamWriter.Close();
                }
            }
        }

        private void BtnAlexandriaGenerate_Click(object sender, EventArgs e)
        {
            if (!bgWorkerAlexandriaGen.IsBusy)
                bgWorkerAlexandriaGen.RunWorkerAsync();
        }

        private void BgWorkerAlexandriaGen_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (!Directory.Exists(rlCookedPCConsoleDir) || !File.Exists($"{rlCookedPCConsoleDir}\\AkAudio.upk"))
            {
                Console.WriteLine("Could not find or invalid CookedPCConsole directory.");
                return;
            }

            if (lstBoxPackagesToGenerate.SelectedItems.Count <= 0)
                return;

            splitContainer1.Panel1.Enabled = false;
            Console.WriteLine("Starting serialization.");
            btnAlexandriaGenerate.Text = "Generating ...";
            MainLevel = new Level(lstBoxPackagesToGenerate.SelectedItems.Cast<string>().ToList());
            MainLevel.Serialize();
        }

        private void BgWorkerAlexandriaGen_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Serialize done.");
            btnAlexandriaGenerate.Text = "Generate";
            btnGetLevelCode.Enabled = true;
            btnGetKismetCode.Enabled = true;
            splitContainer1.Panel1.Enabled = true;
        }

        private void BtnGetLevelCode_Click(object sender, EventArgs e)
        {
            if (MainLevel != null)
                Clipboard.SetText(MainLevel.MapData);
        }

        private void BtnGetKismetCode_Click(object sender, EventArgs e)
        {
            if (MainLevel != null)
                Clipboard.SetText(MainLevel.Kismet);
        }
        #endregion

        private void TxtBoxConsole_TextChanged(object sender, EventArgs e)
        {
            txtBoxConsole.SelectionStart = txtBoxConsole.Text.Length;
            txtBoxConsole.ScrollToCaret();
        }
    }
}
