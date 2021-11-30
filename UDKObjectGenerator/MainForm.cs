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
        private string filePath = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Console.SetOut(new ControlWriter(txtBoxConsole));
        }

        #region Package generation tab
        private void BtnGenerate_Click(object sender, EventArgs e)
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

            Clipboard.SetText(finalString);
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
        private void BtnAlexandriaGenerate_Click(object sender, EventArgs e)
        {
            const string rlCookedPCConsoleDir = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\rocketleague\\TAGame\\CookedPCConsole";
            splitContainer1.Panel1.Enabled = false;

            if (!Directory.Exists(rlCookedPCConsoleDir))
                return;

            if (lstBoxPackagesToGenerate.SelectedItems.Count <= 0)
                return;

            Console.WriteLine("Starting serialization.");
            MainLevel = new Level(lstBoxPackagesToGenerate.SelectedItems.Cast<string>().ToList());
            MainLevel.Serialize();
            Console.WriteLine("Serialize done.");
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
