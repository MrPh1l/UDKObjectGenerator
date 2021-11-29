
namespace AlexandriaLibraryGenerator
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
            this.lstBoxPackagesToGenerate = new System.Windows.Forms.ListBox();
            this.btnGetLevelCode = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnGetKismetCode = new System.Windows.Forms.Button();
            this.txtBoxConsole = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.lstBoxPackagesToGenerate.Location = new System.Drawing.Point(13, 65);
            this.lstBoxPackagesToGenerate.Name = "lstBoxPackagesToGenerate";
            this.lstBoxPackagesToGenerate.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstBoxPackagesToGenerate.Size = new System.Drawing.Size(156, 94);
            this.lstBoxPackagesToGenerate.TabIndex = 0;
            // 
            // btnGetLevelCode
            // 
            this.btnGetLevelCode.Enabled = false;
            this.btnGetLevelCode.Location = new System.Drawing.Point(13, 194);
            this.btnGetLevelCode.Name = "btnGetLevelCode";
            this.btnGetLevelCode.Size = new System.Drawing.Size(75, 23);
            this.btnGetLevelCode.TabIndex = 1;
            this.btnGetLevelCode.Text = "Get level";
            this.btnGetLevelCode.UseVisualStyleBackColor = true;
            this.btnGetLevelCode.Click += new System.EventHandler(this.BtnGetLevelCode_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer1.Location = new System.Drawing.Point(-1, -1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnGenerate);
            this.splitContainer1.Panel1.Controls.Add(this.btnGetKismetCode);
            this.splitContainer1.Panel1.Controls.Add(this.btnGetLevelCode);
            this.splitContainer1.Panel1.Controls.Add(this.lstBoxPackagesToGenerate);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtBoxConsole);
            this.splitContainer1.Size = new System.Drawing.Size(822, 413);
            this.splitContainer1.SplitterDistance = 274;
            this.splitContainer1.TabIndex = 2;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(13, 165);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(156, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // btnGetKismetCode
            // 
            this.btnGetKismetCode.Enabled = false;
            this.btnGetKismetCode.Location = new System.Drawing.Point(94, 194);
            this.btnGetKismetCode.Name = "btnGetKismetCode";
            this.btnGetKismetCode.Size = new System.Drawing.Size(75, 23);
            this.btnGetKismetCode.TabIndex = 2;
            this.btnGetKismetCode.Text = "Get kismet";
            this.btnGetKismetCode.UseVisualStyleBackColor = true;
            this.btnGetKismetCode.Click += new System.EventHandler(this.BtnGetKismetCode_Click);
            // 
            // txtBoxConsole
            // 
            this.txtBoxConsole.BackColor = System.Drawing.Color.White;
            this.txtBoxConsole.Location = new System.Drawing.Point(11, 12);
            this.txtBoxConsole.Name = "txtBoxConsole";
            this.txtBoxConsole.ReadOnly = true;
            this.txtBoxConsole.Size = new System.Drawing.Size(522, 389);
            this.txtBoxConsole.TabIndex = 1;
            this.txtBoxConsole.Text = "";
            this.txtBoxConsole.TextChanged += new System.EventHandler(this.TxtBoxConsole_TextChanged);
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
            this.Text = "Librairie d\'Alexandrie generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxPackagesToGenerate;
        private System.Windows.Forms.Button btnGetLevelCode;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txtBoxConsole;
        private System.Windows.Forms.Button btnGetKismetCode;
        private System.Windows.Forms.Button btnGenerate;
    }
}

