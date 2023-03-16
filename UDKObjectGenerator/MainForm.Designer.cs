
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
            btnGenerate = new System.Windows.Forms.Button();
            lblTypesToGenerate = new System.Windows.Forms.Label();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            btnBrowse = new System.Windows.Forms.Button();
            lblFileName = new System.Windows.Forms.Label();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            lstBoxTypesToGenerate = new System.Windows.Forms.ListBox();
            chckBoxLayers = new System.Windows.Forms.CheckBox();
            chckBoxInvisitek = new System.Windows.Forms.CheckBox();
            lblSettings = new System.Windows.Forms.Label();
            tabPage2 = new System.Windows.Forms.TabPage();
            lblPackagesToGenerate = new System.Windows.Forms.Label();
            btnAlexandriaGenerate = new System.Windows.Forms.Button();
            btnGetKismetCode = new System.Windows.Forms.Button();
            btnGetLevelCode = new System.Windows.Forms.Button();
            lstBoxPackagesToGenerate = new System.Windows.Forms.ListBox();
            txtBoxConsole = new System.Windows.Forms.RichTextBox();
            bgWorkerPackageGen = new System.ComponentModel.BackgroundWorker();
            bgWorkerAlexandriaGen = new System.ComponentModel.BackgroundWorker();
            folderBrowserDialogCookedPCConsole = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // btnGenerate
            // 
            btnGenerate.Enabled = false;
            btnGenerate.Location = new System.Drawing.Point(171, 299);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new System.Drawing.Size(96, 30);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += BtnGenerate_Click;
            // 
            // lblTypesToGenerate
            // 
            lblTypesToGenerate.AutoSize = true;
            lblTypesToGenerate.Location = new System.Drawing.Point(6, 151);
            lblTypesToGenerate.Name = "lblTypesToGenerate";
            lblTypesToGenerate.Size = new System.Drawing.Size(99, 15);
            lblTypesToGenerate.TabIndex = 2;
            lblTypesToGenerate.Text = "Types to generate";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Map files|*.upk";
            openFileDialog1.FileOk += OpenFileDialog1_FileOk;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new System.Drawing.Point(6, 21);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new System.Drawing.Size(75, 23);
            btnBrowse.TabIndex = 3;
            btnBrowse.Text = "Browse ...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += BtnBrowse_Click;
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Location = new System.Drawing.Point(6, 3);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new System.Drawing.Size(88, 15);
            lblFileName.TabIndex = 4;
            lblFileName.Text = "No file selected";
            // 
            // splitContainer1
            // 
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new System.Drawing.Point(-1, -1);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(txtBoxConsole);
            splitContainer1.Size = new System.Drawing.Size(822, 413);
            splitContainer1.SplitterDistance = 274;
            splitContainer1.TabIndex = 5;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new System.Drawing.Point(0, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(282, 410);
            tabControl1.TabIndex = 6;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = System.Drawing.SystemColors.Control;
            tabPage1.Controls.Add(lstBoxTypesToGenerate);
            tabPage1.Controls.Add(chckBoxLayers);
            tabPage1.Controls.Add(lblTypesToGenerate);
            tabPage1.Controls.Add(chckBoxInvisitek);
            tabPage1.Controls.Add(btnBrowse);
            tabPage1.Controls.Add(lblSettings);
            tabPage1.Controls.Add(btnGenerate);
            tabPage1.Controls.Add(lblFileName);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(274, 382);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Package generation";
            // 
            // lstBoxTypesToGenerate
            // 
            lstBoxTypesToGenerate.FormattingEnabled = true;
            lstBoxTypesToGenerate.ItemHeight = 15;
            lstBoxTypesToGenerate.Items.AddRange(new object[] { "AkAmbientSoundActor", "DynamicMeshActor_TA", "InterpActor", "LensFlareSource", "ParticleSystemComponent", "PlayerStart_TA", "SceneCaptureCubeMapActor", "StaticMeshActor", "StaticMeshComponent" });
            lstBoxTypesToGenerate.Location = new System.Drawing.Point(6, 169);
            lstBoxTypesToGenerate.Name = "lstBoxTypesToGenerate";
            lstBoxTypesToGenerate.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            lstBoxTypesToGenerate.Size = new System.Drawing.Size(261, 124);
            lstBoxTypesToGenerate.TabIndex = 8;
            // 
            // chckBoxLayers
            // 
            chckBoxLayers.AutoSize = true;
            chckBoxLayers.Location = new System.Drawing.Point(6, 109);
            chckBoxLayers.Name = "chckBoxLayers";
            chckBoxLayers.Size = new System.Drawing.Size(174, 19);
            chckBoxLayers.TabIndex = 7;
            chckBoxLayers.Text = "Add custom layer to objects";
            chckBoxLayers.UseVisualStyleBackColor = true;
            // 
            // chckBoxInvisitek
            // 
            chckBoxInvisitek.AutoSize = true;
            chckBoxInvisitek.Location = new System.Drawing.Point(6, 87);
            chckBoxInvisitek.Name = "chckBoxInvisitek";
            chckBoxInvisitek.Size = new System.Drawing.Size(142, 19);
            chckBoxInvisitek.TabIndex = 6;
            chckBoxInvisitek.Text = "Use invisitek materials";
            chckBoxInvisitek.UseVisualStyleBackColor = true;
            // 
            // lblSettings
            // 
            lblSettings.AutoSize = true;
            lblSettings.Location = new System.Drawing.Point(6, 69);
            lblSettings.Name = "lblSettings";
            lblSettings.Size = new System.Drawing.Size(49, 15);
            lblSettings.TabIndex = 5;
            lblSettings.Text = "Settings";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = System.Drawing.SystemColors.Control;
            tabPage2.Controls.Add(lblPackagesToGenerate);
            tabPage2.Controls.Add(btnAlexandriaGenerate);
            tabPage2.Controls.Add(btnGetKismetCode);
            tabPage2.Controls.Add(btnGetLevelCode);
            tabPage2.Controls.Add(lstBoxPackagesToGenerate);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(274, 382);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Alexandria library";
            // 
            // lblPackagesToGenerate
            // 
            lblPackagesToGenerate.AutoSize = true;
            lblPackagesToGenerate.Location = new System.Drawing.Point(8, 9);
            lblPackagesToGenerate.Name = "lblPackagesToGenerate";
            lblPackagesToGenerate.Size = new System.Drawing.Size(119, 15);
            lblPackagesToGenerate.TabIndex = 8;
            lblPackagesToGenerate.Text = "Packages to generate";
            // 
            // btnAlexandriaGenerate
            // 
            btnAlexandriaGenerate.Location = new System.Drawing.Point(8, 322);
            btnAlexandriaGenerate.Name = "btnAlexandriaGenerate";
            btnAlexandriaGenerate.Size = new System.Drawing.Size(258, 23);
            btnAlexandriaGenerate.TabIndex = 7;
            btnAlexandriaGenerate.Text = "Generate";
            btnAlexandriaGenerate.UseVisualStyleBackColor = true;
            btnAlexandriaGenerate.Click += BtnAlexandriaGenerate_Click;
            // 
            // btnGetKismetCode
            // 
            btnGetKismetCode.Enabled = false;
            btnGetKismetCode.Location = new System.Drawing.Point(138, 351);
            btnGetKismetCode.Name = "btnGetKismetCode";
            btnGetKismetCode.Size = new System.Drawing.Size(128, 23);
            btnGetKismetCode.TabIndex = 6;
            btnGetKismetCode.Text = "Get kismet";
            btnGetKismetCode.UseVisualStyleBackColor = true;
            btnGetKismetCode.Click += BtnGetKismetCode_Click;
            // 
            // btnGetLevelCode
            // 
            btnGetLevelCode.Enabled = false;
            btnGetLevelCode.Location = new System.Drawing.Point(8, 351);
            btnGetLevelCode.Name = "btnGetLevelCode";
            btnGetLevelCode.Size = new System.Drawing.Size(124, 23);
            btnGetLevelCode.TabIndex = 5;
            btnGetLevelCode.Text = "Get level";
            btnGetLevelCode.UseVisualStyleBackColor = true;
            btnGetLevelCode.Click += BtnGetLevelCode_Click;
            // 
            // lstBoxPackagesToGenerate
            // 
            lstBoxPackagesToGenerate.FormattingEnabled = true;
            lstBoxPackagesToGenerate.ItemHeight = 15;
            lstBoxPackagesToGenerate.Items.AddRange(new object[] { "ARC_Field", "ARC_FX", "ARC_P", "arc_p_MapImage_SF", "ARC_SFX", "ARC_Sky", "ARC_Standard_Field", "ARC_Standard_FX", "ARC_Standard_Grass", "ARC_Standard_P", "arc_standard_p_MapImage_SF", "ARC_Standard_Sky", "Beach_Cage", "Beach_Field", "Beach_FX", "Beach_Night_Cage", "Beach_Night_Field", "Beach_Night_FX", "Beach_Night_OOB", "Beach_Night_OOB2", "Beach_Night_OOBTerrain", "Beach_Night_P", "beach_night_p_mapimage_SF", "Beach_Night_SFX", "Beach_OOB", "Beach_OOB2", "Beach_OOBTerrain", "Beach_P", "beach_p_mapimage_SF", "Beach_SFX", "BG_ARC_Darc", "BG_CS", "BG_FNI_Stadium", "BG_Outlaw_Oasis", "BG_Park_Snowy", "BG_Stadium", "BG_UtopiaSnow", "CHN_Stadium_Cage", "CHN_Stadium_Day_Field", "CHN_Stadium_Day_Mountains", "CHN_Stadium_Day_OOB", "chn_stadium_day_p_mapimage_SF", "CHN_Stadium_Day_SFX", "CHN_Stadium_Day_VFX", "CHN_Stadium_Field", "CHN_Stadium_Lighting", "CHN_Stadium_OOB", "CHN_Stadium_OOB_Mountains", "chn_stadium_p_mapimage_SF", "CHN_Stadium_Rocks", "CHN_Stadium_SFX", "CHN_Stadium_VFX", "CS_Day_Field", "CS_Day_Grounds", "CS_Day_Lights", "CS_Day_OOB", "CS_Day_OOB2", "CS_Day_P", "cs_day_p_MapImage_SF", "CS_Day_SFX", "CS_Field", "CS_Grounds", "CS_HW_Field", "CS_HW_Grounds", "CS_HW_Lights", "CS_HW_OOB", "CS_HW_OOB2", "CS_HW_P", "cs_hw_p_MapImage_SF", "CS_HW_SFX", "CS_Lights", "CS_OOB", "CS_OOB2", "CS_P", "cs_p_MapImage_SF", "CS_SFX", "EuroStadium_Night_P", "eurostadium_night_p_MapImage_SF", "EuroStadium_Night_SFX", "EuroStadium_P", "eurostadium_p_MapImage_SF", "EuroStadium_Rainy_Audio", "EuroStadium_Rainy_P", "eurostadium_rainy_p_MapImage_SF", "EuroStadium_SnowNight_P", "eurostadium_snownight_p_MapImage_SF", "EuroStadium_SnowNight_SFX", "EuroStadium_Snow_SFX", "Farm_Night_OOBTerrain", "Farm_Night_P", "farm_night_p_mapimage_SF", "Farm_Night_SFX", "Farm_OOBTerrain", "Farm_P", "farm_p_mapimage_SF", "Farm_SFX", "Farm_UpsideDown_SFX", "Farm_VFX", "FNI_Stadium_Field", "FNI_Stadium_OOB", "FNI_Stadium_OOB_LOD", "FNI_Stadium_OOB_Mountains", "FNI_Stadium_P", "FNI_Stadium_P_MapImage_SF", "FNI_Stadium_SFX", "FNI_Stadium_VFX", "Haunted_TrainStation_P", "haunted_trainstation_p_mapimage_SF", "Haunted_TrainStation_SFX", "HoopsStadium_P", "hoopsstadium_p_mapimage_SF", "HoopsStadium_SFX", "KO_Calavera_P", "ko_calavera_p_MapImage_SF", "KO_Carbon_P", "ko_carbon_p_MapImage_SF", "KO_Quadron_P", "ko_quadron_p_MapImage_SF", "KO_Retro_OOB", "KO_Retro_OOB2", "Labs_Basin_P", "labs_basin_p_mapimage_SF", "Labs_CirclePillars_P", "labs_circlepillars_p_MapImage_SF", "Labs_Corridor_P", "labs_corridor_p_mapimage_SF", "Labs_Cosmic_P", "Labs_Cosmic_V4_P", "labs_cosmic_v4_p_MapImage_SF", "Labs_DoubleGoal_P", "Labs_DoubleGoal_V2_P", "labs_doublegoal_v2_p_MapImage_SF", "labs_galleon_mast_p_MapImage_SF", "Labs_Galleon_P", "labs_galleon_p_mapimage_SF", "labs_holyfield_p_MapImage_SF", "Labs_Octagon_02_P", "labs_octagon_02_p_MapImage_SF", "Labs_Octagon_P", "Labs_OOB_01", "Labs_SFX", "Labs_Underpass_P", "labs_underpass_p_MapImage_SF", "Labs_Underpass_v0_p", "Labs_Utopia_P", "labs_utopia_p_MapImage_SF", "Music_Effects", "Music_Field", "Music_OOB", "music_p_mapimage_SF", "Music_SFX", "mutators_balls_SF", "mutators_items_SF", "Mutators_SF", "NeoTokyo_Buildings", "NeoTokyo_Buildings_S", "NeoTokyo_Lights", "NeoTokyo_Lights_S", "NeoTokyo_P", "neotokyo_p_MapImage_SF", "NeoTokyo_SFX", "NeoTokyo_Signs", "NeoTokyo_Signs_02", "NeoTokyo_Signs_S", "NeoTokyo_Standard_P", "neotokyo_standard_p_MapImage_SF", "NeoTokyo_Toon_P", "neotokyo_toon_p_MapImage_SF", "NeoTokyo_Toon_SFX", "Outlaw_Oasis_FX_P", "Outlaw_Oasis_OOB", "Outlaw_Oasis_P", "Outlaw_Oasis_SFX", "outlaw_oasis_p_MapImage_SF", "Outlaw_P", "outlaw_p_MapImage_SF", "Outlaw_SFX", "Park_Night_P", "park_night_p_MapImage_SF", "Park_Night_SFX", "Park_P", "park_p_MapImage_SF", "Park_Rainy_P", "park_rainy_p_MapImage_SF", "Park_Rainy_SFX", "Park_SFX", "ShatterShot_OOB_Exploration", "ShatterShot_P", "shattershot_p_MapImage_SF", "ShatterShot_SFX", "ShatterShot_VFX", "Stadium_Day_P", "stadium_day_p_MapImage_SF", "Stadium_Foggy_P", "stadium_foggy_p_MapImage_SF", "Stadium_Foggy_SFX", "Stadium_OOB_Audio_Map", "Stadium_P", "stadium_p_MapImage_SF", "Stadium_Race_Day_Audio_Map", "Stadium_Race_Day_P", "stadium_race_day_p_MapImage_SF", "Stadium_Winter_P", "stadium_winter_p_MapImage_SF", "Street_P", "street_p_MapImage_SF", "Street_SFX", "Swoosh_Field", "Swoosh_Grounds", "Swoosh_Lights", "Swoosh_OOB", "Swoosh_OOB2", "Swoosh_P", "swoosh_p_MapImage_SF", "Swoosh_SFX", "ThrowbackStadium_Field", "ThrowbackStadium_OOB", "ThrowbackStadium_P", "throwbackstadium_p_MapImage_SF", "TrainStation_Dawn_P", "trainstation_dawn_p_MapImage_SF", "TrainStation_Dawn_SFX", "TrainStation_Night_P", "trainstation_night_p_MapImage_SF", "TrainStation_Night_SFX", "TrainStation_P", "trainstation_p_MapImage_SF", "TrainStation_SFX", "trainstation_spooky_p_mapimage_SF", "Underwater_Field", "Underwater_FX", "Underwater_Lights", "Underwater_OOB_foliage", "Underwater_P", "Underwater_Plants", "underwater_p_MapImage_SF", "Underwater_SFX", "UtopiaStadium_Dusk_P", "utopiastadium_dusk_p_MapImage_SF", "UtopiaStadium_Lux_P", "utopiastadium_lux_p_MapImage_SF", "UtopiaStadium_Lux_SFX", "UtopiaStadium_Night_SFX", "UtopiaStadium_P", "utopiastadium_p_MapImage_SF", "UtopiaStadium_SFX", "UtopiaStadium_Snow_P", "utopiastadium_snow_p_MapImage_SF", "UtopiaStadium_Snow_SFX", "Wasteland_Art_Night_P", "Wasteland_Art_Night_S_P", "Wasteland_Art_P", "Wasteland_Art_S_P", "Wasteland_Night_P", "wasteland_night_p_MapImage_SF", "Wasteland_Night_SFX", "Wasteland_Night_S_P", "wasteland_night_s_p_MapImage_SF", "Wasteland_Night_S_VFX", "Wasteland_Night_VFX_P", "Wasteland_P", "wasteland_p_MapImage_SF", "Wasteland_SFX", "Wasteland_S_P", "wasteland_s_p_MapImage_SF", "Wasteland_S_VFX", "Wasteland_VFX" });
            lstBoxPackagesToGenerate.Location = new System.Drawing.Point(8, 27);
            lstBoxPackagesToGenerate.Name = "lstBoxPackagesToGenerate";
            lstBoxPackagesToGenerate.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            lstBoxPackagesToGenerate.Size = new System.Drawing.Size(258, 289);
            lstBoxPackagesToGenerate.TabIndex = 4;
            // 
            // txtBoxConsole
            // 
            txtBoxConsole.BackColor = System.Drawing.Color.White;
            txtBoxConsole.Location = new System.Drawing.Point(10, 27);
            txtBoxConsole.Name = "txtBoxConsole";
            txtBoxConsole.ReadOnly = true;
            txtBoxConsole.Size = new System.Drawing.Size(522, 374);
            txtBoxConsole.TabIndex = 0;
            txtBoxConsole.Text = "";
            txtBoxConsole.TextChanged += TxtBoxConsole_TextChanged;
            // 
            // bgWorkerPackageGen
            // 
            bgWorkerPackageGen.DoWork += BgWorkerPackageGen_DoWork;
            bgWorkerPackageGen.RunWorkerCompleted += BgWorkerPackageGen_RunWorkerCompleted;
            // 
            // bgWorkerAlexandriaGen
            // 
            bgWorkerAlexandriaGen.DoWork += BgWorkerAlexandriaGen_DoWork;
            bgWorkerAlexandriaGen.RunWorkerCompleted += BgWorkerAlexandriaGen_RunWorkerCompleted;
            // 
            // folderBrowserDialogCookedPCConsole
            // 
            folderBrowserDialogCookedPCConsole.Description = "Select Rocket League CookedPCConsole folder";
            folderBrowserDialogCookedPCConsole.SelectedPath = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\rocketleague\\TAGame\\CookedPCConsole";
            folderBrowserDialogCookedPCConsole.UseDescriptionForTitle = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(821, 412);
            Controls.Add(splitContainer1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "UDK Object Generator";
            Load += MainForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
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
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogCookedPCConsole;
    }
}

