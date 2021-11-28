using AlexandriaLibraryGenerator.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AlexandriaLibraryGenerator
{
    public partial class MainForm : Form
    {
        private Level MainLevel;

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
            const string rlCookedPCConsoleDir = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\rocketleague\\TAGame\\CookedPCConsole";

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

        private void TxtBoxConsole_TextChanged(object sender, EventArgs e)
        {
            txtBoxConsole.SelectionStart = txtBoxConsole.Text.Length;
            txtBoxConsole.ScrollToCaret();
        }
    }
}
