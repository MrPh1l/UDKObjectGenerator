
namespace UDKObjectGenerator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblTypesToGenerate = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lstBoxTypesToGenerate = new System.Windows.Forms.ListBox();
            this.chckBoxLayers = new System.Windows.Forms.CheckBox();
            this.chckBoxInvisitek = new System.Windows.Forms.CheckBox();
            this.lblSettings = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblPackagesToGenerate = new System.Windows.Forms.Label();
            this.btnAlexandriaGenerate = new System.Windows.Forms.Button();
            this.btnGetKismetCode = new System.Windows.Forms.Button();
            this.btnGetLevelCode = new System.Windows.Forms.Button();
            this.lstBoxPackagesToGenerate = new System.Windows.Forms.ListBox();
            this.txtBoxConsole = new System.Windows.Forms.RichTextBox();
            this.bgWorkerPackageGen = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerAlexandriaGen = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Enabled = false;
            this.btnGenerate.Location = new System.Drawing.Point(171, 299);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(96, 30);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // lblTypesToGenerate
            // 
            this.lblTypesToGenerate.AutoSize = true;
            this.lblTypesToGenerate.Location = new System.Drawing.Point(6, 151);
            this.lblTypesToGenerate.Name = "lblTypesToGenerate";
            this.lblTypesToGenerate.Size = new System.Drawing.Size(99, 15);
            this.lblTypesToGenerate.TabIndex = 2;
            this.lblTypesToGenerate.Text = "Types to generate";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Map files|*.upk";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(6, 21);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse ...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(6, 3);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(88, 15);
            this.lblFileName.TabIndex = 4;
            this.lblFileName.Text = "No file selected";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(-1, -1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtBoxConsole);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer1.Size = new System.Drawing.Size(822, 413);
            this.splitContainer1.SplitterDistance = 274;
            this.splitContainer1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(282, 410);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.lstBoxTypesToGenerate);
            this.tabPage1.Controls.Add(this.chckBoxLayers);
            this.tabPage1.Controls.Add(this.lblTypesToGenerate);
            this.tabPage1.Controls.Add(this.chckBoxInvisitek);
            this.tabPage1.Controls.Add(this.btnBrowse);
            this.tabPage1.Controls.Add(this.lblSettings);
            this.tabPage1.Controls.Add(this.btnGenerate);
            this.tabPage1.Controls.Add(this.lblFileName);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(274, 382);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Package generation";
            // 
            // lstBoxTypesToGenerate
            // 
            this.lstBoxTypesToGenerate.FormattingEnabled = true;
            this.lstBoxTypesToGenerate.ItemHeight = 15;
            this.lstBoxTypesToGenerate.Items.AddRange(new object[] {
            "AkAmbientSoundActor",
            "DynamicMeshActor_TA",
            "Emitter_PSC",
            "InterpActor",
            "LensFlareSource",
            "PlayerStart_TA",
            "StaticMeshActor",
            "StaticMeshActor_SMC"});
            this.lstBoxTypesToGenerate.Location = new System.Drawing.Point(6, 169);
            this.lstBoxTypesToGenerate.Name = "lstBoxTypesToGenerate";
            this.lstBoxTypesToGenerate.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstBoxTypesToGenerate.Size = new System.Drawing.Size(261, 124);
            this.lstBoxTypesToGenerate.TabIndex = 8;
            // 
            // chckBoxLayers
            // 
            this.chckBoxLayers.AutoSize = true;
            this.chckBoxLayers.Location = new System.Drawing.Point(6, 109);
            this.chckBoxLayers.Name = "chckBoxLayers";
            this.chckBoxLayers.Size = new System.Drawing.Size(174, 19);
            this.chckBoxLayers.TabIndex = 7;
            this.chckBoxLayers.Text = "Add custom layer to objects";
            this.chckBoxLayers.UseVisualStyleBackColor = true;
            // 
            // chckBoxInvisitek
            // 
            this.chckBoxInvisitek.AutoSize = true;
            this.chckBoxInvisitek.Location = new System.Drawing.Point(6, 87);
            this.chckBoxInvisitek.Name = "chckBoxInvisitek";
            this.chckBoxInvisitek.Size = new System.Drawing.Size(142, 19);
            this.chckBoxInvisitek.TabIndex = 6;
            this.chckBoxInvisitek.Text = "Use invisitek materials";
            this.chckBoxInvisitek.UseVisualStyleBackColor = true;
            // 
            // lblSettings
            // 
            this.lblSettings.AutoSize = true;
            this.lblSettings.Location = new System.Drawing.Point(6, 69);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(49, 15);
            this.lblSettings.TabIndex = 5;
            this.lblSettings.Text = "Settings";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.lblPackagesToGenerate);
            this.tabPage2.Controls.Add(this.btnAlexandriaGenerate);
            this.tabPage2.Controls.Add(this.btnGetKismetCode);
            this.tabPage2.Controls.Add(this.btnGetLevelCode);
            this.tabPage2.Controls.Add(this.lstBoxPackagesToGenerate);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(274, 382);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Alexandria library";
            // 
            // lblPackagesToGenerate
            // 
            this.lblPackagesToGenerate.AutoSize = true;
            this.lblPackagesToGenerate.Location = new System.Drawing.Point(8, 9);
            this.lblPackagesToGenerate.Name = "lblPackagesToGenerate";
            this.lblPackagesToGenerate.Size = new System.Drawing.Size(119, 15);
            this.lblPackagesToGenerate.TabIndex = 8;
            this.lblPackagesToGenerate.Text = "Packages to generate";
            // 
            // btnAlexandriaGenerate
            // 
            this.btnAlexandriaGenerate.Location = new System.Drawing.Point(8, 322);
            this.btnAlexandriaGenerate.Name = "btnAlexandriaGenerate";
            this.btnAlexandriaGenerate.Size = new System.Drawing.Size(258, 23);
            this.btnAlexandriaGenerate.TabIndex = 7;
            this.btnAlexandriaGenerate.Text = "Generate";
            this.btnAlexandriaGenerate.UseVisualStyleBackColor = true;
            this.btnAlexandriaGenerate.Click += new System.EventHandler(this.BtnAlexandriaGenerate_Click);
            // 
            // btnGetKismetCode
            // 
            this.btnGetKismetCode.Enabled = false;
            this.btnGetKismetCode.Location = new System.Drawing.Point(138, 351);
            this.btnGetKismetCode.Name = "btnGetKismetCode";
            this.btnGetKismetCode.Size = new System.Drawing.Size(128, 23);
            this.btnGetKismetCode.TabIndex = 6;
            this.btnGetKismetCode.Text = "Get kismet";
            this.btnGetKismetCode.UseVisualStyleBackColor = true;
            this.btnGetKismetCode.Click += new System.EventHandler(this.BtnGetKismetCode_Click);
            // 
            // btnGetLevelCode
            // 
            this.btnGetLevelCode.Enabled = false;
            this.btnGetLevelCode.Location = new System.Drawing.Point(8, 351);
            this.btnGetLevelCode.Name = "btnGetLevelCode";
            this.btnGetLevelCode.Size = new System.Drawing.Size(124, 23);
            this.btnGetLevelCode.TabIndex = 5;
            this.btnGetLevelCode.Text = "Get level";
            this.btnGetLevelCode.UseVisualStyleBackColor = true;
            this.btnGetLevelCode.Click += new System.EventHandler(this.BtnGetLevelCode_Click);
            // 
            // lstBoxPackagesToGenerate
            // 
            this.lstBoxPackagesToGenerate.FormattingEnabled = true;
            this.lstBoxPackagesToGenerate.ItemHeight = 15;
            this.lstBoxPackagesToGenerate.Items.AddRange(new object[] {
            "ARC_Field",
            "ARC_FX",
            "ARC_P",
            "arc_p_MapImage_SF",
            "ARC_SFX",
            "ARC_Sky",
            "ARC_Standard_Field",
            "ARC_Standard_FX",
            "ARC_Standard_Grass",
            "ARC_Standard_P",
            "arc_standard_p_MapImage_SF",
            "ARC_Standard_Sky",
            "Beach_Cage",
            "Beach_Field",
            "Beach_FX",
            "Beach_Night_Cage",
            "Beach_Night_Field",
            "Beach_Night_FX",
            "Beach_Night_OOB",
            "Beach_Night_OOB2",
            "Beach_Night_OOBTerrain",
            "Beach_Night_P",
            "beach_night_p_mapimage_SF",
            "Beach_Night_SFX",
            "Beach_OOB",
            "Beach_OOB2",
            "Beach_OOBTerrain",
            "Beach_P",
            "beach_p_mapimage_SF",
            "Beach_SFX",
            "CHN_Stadium_Cage",
            "CHN_Stadium_Day_Field",
            "CHN_Stadium_Day_Mountains",
            "CHN_Stadium_Day_OOB",
            "chn_stadium_day_p_mapimage_SF",
            "CHN_Stadium_Day_SFX",
            "CHN_Stadium_Day_VFX",
            "CHN_Stadium_Field",
            "CHN_Stadium_Lighting",
            "CHN_Stadium_OOB",
            "CHN_Stadium_OOB_Mountains",
            "chn_stadium_p_mapimage_SF",
            "CHN_Stadium_Rocks",
            "CHN_Stadium_SFX",
            "CHN_Stadium_VFX",
            "CS_Day_Field",
            "CS_Day_Grounds",
            "CS_Day_Lights",
            "CS_Day_OOB",
            "CS_Day_OOB2",
            "CS_Day_P",
            "cs_day_p_MapImage_SF",
            "CS_Day_SFX",
            "CS_Field",
            "CS_Grounds",
            "CS_HW_Field",
            "CS_HW_Grounds",
            "CS_HW_Lights",
            "CS_HW_OOB",
            "CS_HW_OOB2",
            "CS_HW_P",
            "cs_hw_p_MapImage_SF",
            "CS_HW_SFX",
            "CS_Lights",
            "CS_OOB",
            "CS_OOB2",
            "CS_P",
            "cs_p_MapImage_SF",
            "CS_SFX",
            "EuroStadium_Night_P",
            "eurostadium_night_p_MapImage_SF",
            "EuroStadium_Night_SFX",
            "EuroStadium_P",
            "eurostadium_p_MapImage_SF",
            "EuroStadium_Rainy_Audio",
            "EuroStadium_Rainy_P",
            "eurostadium_rainy_p_MapImage_SF",
            "EuroStadium_SnowNight_P",
            "eurostadium_snownight_p_MapImage_SF",
            "EuroStadium_SnowNight_SFX",
            "EuroStadium_Snow_SFX",
            "Farm_Art",
            "Farm_Night_OOBTerrain",
            "Farm_Night_P",
            "farm_night_p_mapimage_SF",
            "Farm_Night_SFX",
            "Farm_OOBTerrain",
            "Farm_P",
            "Farm_Props_CMB",
            "farm_p_mapimage_SF",
            "Farm_SFX",
            "Farm_UpsideDown_P",
            "farm_upsidedown_p_mapimage_SF",
            "Farm_UpsideDown_SFX",
            "Farm_VFX",
            "Haunted_TrainStation_P",
            "haunted_trainstation_p_mapimage_SF",
            "Haunted_TrainStation_SFX",
            "HoopsStadium_P",
            "hoopsstadium_p_mapimage_SF",
            "HoopsStadium_SFX",
            "Labs_Basin_P",
            "labs_basin_p_mapimage_SF",
            "Labs_CirclePillars_P",
            "labs_circlepillars_p_MapImage_SF",
            "Labs_Corridor_P",
            "labs_corridor_p_mapimage_SF",
            "Labs_Cosmic_P",
            "labs_cosmic_p_MapImage_SF",
            "Labs_Cosmic_V4_P",
            "labs_cosmic_v4_p_MapImage_SF",
            "Labs_DoubleGoal_P",
            "labs_doublegoal_p_MapImage_SF",
            "Labs_DoubleGoal_V2_P",
            "labs_doublegoal_v2_p_MapImage_SF",
            "labs_galleon_mast_p_MapImage_SF",
            "Labs_Galleon_P",
            "labs_galleon_p_mapimage_SF",
            "labs_holyfield_p_MapImage_SF",
            "Labs_Octagon_02_P",
            "labs_octagon_02_p_MapImage_SF",
            "Labs_Octagon_P",
            "Labs_OOB_01",
            "Labs_SFX",
            "Labs_Underpass_P",
            "labs_underpass_p_MapImage_SF",
            "Labs_Underpass_v0_p",
            "Labs_Utopia_P",
            "labs_utopia_p_MapImage_SF",
            "Music_Effects",
            "Music_Field",
            "Music_OOB",
            "music_p_mapimage_SF",
            "Music_SFX",
            "mutators_balls_SF",
            "mutators_items_SF",
            "Mutators_SF",
            "NeoTokyo_Buildings",
            "NeoTokyo_Buildings_S",
            "NeoTokyo_Lights",
            "NeoTokyo_Lights_S",
            "NeoTokyo_P",
            "neotokyo_p_MapImage_SF",
            "NeoTokyo_SFX",
            "NeoTokyo_Signs",
            "NeoTokyo_Signs_02",
            "NeoTokyo_Signs_S",
            "NeoTokyo_Standard_P",
            "neotokyo_standard_p_MapImage_SF",
            "Outlaw_P",
            "outlaw_p_MapImage_SF",
            "Outlaw_SFX",
            "Park_Night_P",
            "park_night_p_MapImage_SF",
            "Park_Night_SFX",
            "Park_P",
            "park_p_MapImage_SF",
            "Park_Rainy_P",
            "park_rainy_p_MapImage_SF",
            "Park_Rainy_SFX",
            "Park_SFX",
            "ShatterShot_OOB_Exploration",
            "ShatterShot_P",
            "shattershot_p_MapImage_SF",
            "ShatterShot_SFX",
            "ShatterShot_VFX",
            "Stadium_Day_P",
            "stadium_day_p_MapImage_SF",
            "Stadium_Foggy_P",
            "stadium_foggy_p_MapImage_SF",
            "Stadium_Foggy_SFX",
            "Stadium_OOB_Audio_Map",
            "Stadium_P",
            "stadium_p_MapImage_SF",
            "Stadium_Race_Day_Audio_Map",
            "Stadium_Race_Day_P",
            "stadium_race_day_p_MapImage_SF",
            "Stadium_Winter_P",
            "stadium_winter_p_MapImage_SF",
            "ThrowbackStadium_Field",
            "ThrowbackStadium_OOB",
            "ThrowbackStadium_P",
            "throwbackstadium_p_MapImage_SF",
            "TrainStation_Dawn_P",
            "trainstation_dawn_p_MapImage_SF",
            "TrainStation_Dawn_SFX",
            "TrainStation_Night_P",
            "trainstation_night_p_MapImage_SF",
            "TrainStation_Night_SFX",
            "TrainStation_P",
            "trainstation_p_MapImage_SF",
            "TrainStation_SFX",
            "TrainStation_Spooky_P",
            "trainstation_spooky_p_mapimage_SF",
            "Underwater_Field",
            "Underwater_FX",
            "Underwater_Lights",
            "Underwater_OOB_foliage",
            "Underwater_P",
            "Underwater_Plants",
            "underwater_p_MapImage_SF",
            "Underwater_SFX",
            "UtopiaStadium_Dusk_P",
            "utopiastadium_dusk_p_MapImage_SF",
            "UtopiaStadium_Night_SFX",
            "UtopiaStadium_P",
            "utopiastadium_p_MapImage_SF",
            "UtopiaStadium_SFX",
            "UtopiaStadium_Snow_P",
            "utopiastadium_snow_p_MapImage_SF",
            "UtopiaStadium_Snow_SFX",
            "Wasteland_Art_Night_P",
            "Wasteland_Art_Night_S_P",
            "Wasteland_Art_P",
            "Wasteland_Art_S_P",
            "Wasteland_Night_P",
            "wasteland_night_p_MapImage_SF",
            "Wasteland_Night_SFX",
            "Wasteland_Night_S_P",
            "wasteland_night_s_p_MapImage_SF",
            "Wasteland_Night_S_VFX",
            "Wasteland_Night_VFX_P",
            "Wasteland_P",
            "wasteland_p_MapImage_SF",
            "Wasteland_SFX",
            "Wasteland_S_P",
            "wasteland_s_p_MapImage_SF",
            "Wasteland_S_VFX",
            "Wasteland_VFX"});
            this.lstBoxPackagesToGenerate.Location = new System.Drawing.Point(8, 27);
            this.lstBoxPackagesToGenerate.Name = "lstBoxPackagesToGenerate";
            this.lstBoxPackagesToGenerate.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstBoxPackagesToGenerate.Size = new System.Drawing.Size(258, 289);
            this.lstBoxPackagesToGenerate.TabIndex = 4;
            // 
            // txtBoxConsole
            // 
            this.txtBoxConsole.BackColor = System.Drawing.Color.White;
            this.txtBoxConsole.Location = new System.Drawing.Point(10, 27);
            this.txtBoxConsole.Name = "txtBoxConsole";
            this.txtBoxConsole.ReadOnly = true;
            this.txtBoxConsole.Size = new System.Drawing.Size(522, 374);
            this.txtBoxConsole.TabIndex = 0;
            this.txtBoxConsole.Text = "";
            this.txtBoxConsole.TextChanged += new System.EventHandler(this.TxtBoxConsole_TextChanged);
            // 
            // bgWorkerPackageGen
            // 
            this.bgWorkerPackageGen.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgWorkerPackageGen_DoWork);
            this.bgWorkerPackageGen.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgWorkerPackageGen_RunWorkerCompleted);
            // 
            // bgWorkerAlexandriaGen
            // 
            this.bgWorkerAlexandriaGen.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgWorkerAlexandriaGen_DoWork);
            this.bgWorkerAlexandriaGen.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgWorkerAlexandriaGen_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 412);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "UDK Object Generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblTypesToGenerate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txtBoxConsole;
        private System.Windows.Forms.CheckBox chckBoxLayers;
        private System.Windows.Forms.CheckBox chckBoxInvisitek;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.ListBox lstBoxTypesToGenerate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAlexandriaGenerate;
        private System.Windows.Forms.Button btnGetKismetCode;
        private System.Windows.Forms.Button btnGetLevelCode;
        private System.Windows.Forms.ListBox lstBoxPackagesToGenerate;
        private System.Windows.Forms.Label lblPackagesToGenerate;
        private System.ComponentModel.BackgroundWorker bgWorkerPackageGen;
        private System.ComponentModel.BackgroundWorker bgWorkerAlexandriaGen;
    }
}

