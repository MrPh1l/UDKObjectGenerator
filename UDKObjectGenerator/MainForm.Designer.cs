
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
            this.bgWorkerGeneration = new System.ComponentModel.BackgroundWorker();
            this.lblTypesToGenerate = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstBoxTypesToGenerate = new System.Windows.Forms.ListBox();
            this.chckBoxLayers = new System.Windows.Forms.CheckBox();
            this.chckBoxInvisitek = new System.Windows.Forms.CheckBox();
            this.lblSettings = new System.Windows.Forms.Label();
            this.txtBoxConsole = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Enabled = false;
            this.btnGenerate.Location = new System.Drawing.Point(158, 371);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(96, 30);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // bgWorkerGeneration
            // 
            this.bgWorkerGeneration.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgWorkerGeneration_DoWork);
            this.bgWorkerGeneration.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgWorkerGeneration_RunWorkerCompleted);
            // 
            // lblTypesToGenerate
            // 
            this.lblTypesToGenerate.AutoSize = true;
            this.lblTypesToGenerate.Location = new System.Drawing.Point(13, 160);
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
            this.btnBrowse.Location = new System.Drawing.Point(13, 30);
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
            this.lblFileName.Location = new System.Drawing.Point(13, 12);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(88, 15);
            this.lblFileName.TabIndex = 4;
            this.lblFileName.Text = "No file selected";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(-1, -1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstBoxTypesToGenerate);
            this.splitContainer1.Panel1.Controls.Add(this.chckBoxLayers);
            this.splitContainer1.Panel1.Controls.Add(this.chckBoxInvisitek);
            this.splitContainer1.Panel1.Controls.Add(this.lblSettings);
            this.splitContainer1.Panel1.Controls.Add(this.lblFileName);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenerate);
            this.splitContainer1.Panel1.Controls.Add(this.btnBrowse);
            this.splitContainer1.Panel1.Controls.Add(this.lblTypesToGenerate);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtBoxConsole);
            this.splitContainer1.Size = new System.Drawing.Size(822, 413);
            this.splitContainer1.SplitterDistance = 274;
            this.splitContainer1.TabIndex = 5;
            // 
            // lstBoxTypesToGenerate
            // 
            this.lstBoxTypesToGenerate.FormattingEnabled = true;
            this.lstBoxTypesToGenerate.ItemHeight = 15;
            this.lstBoxTypesToGenerate.Items.AddRange(new object[] {
            "AkAmbientSoundActor",
            "DynamicMeshActor_TA",
            "InterpActor",
            "LensFlareSource",
            "PlayerStart_TA",
            "StaticMeshActor",
            "StaticMeshActor_SMC"});
            this.lstBoxTypesToGenerate.Location = new System.Drawing.Point(13, 178);
            this.lstBoxTypesToGenerate.Name = "lstBoxTypesToGenerate";
            this.lstBoxTypesToGenerate.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstBoxTypesToGenerate.Size = new System.Drawing.Size(241, 109);
            this.lstBoxTypesToGenerate.TabIndex = 8;
            // 
            // chckBoxLayers
            // 
            this.chckBoxLayers.AutoSize = true;
            this.chckBoxLayers.Location = new System.Drawing.Point(13, 118);
            this.chckBoxLayers.Name = "chckBoxLayers";
            this.chckBoxLayers.Size = new System.Drawing.Size(174, 19);
            this.chckBoxLayers.TabIndex = 7;
            this.chckBoxLayers.Text = "Add custom layer to objects";
            this.chckBoxLayers.UseVisualStyleBackColor = true;
            // 
            // chckBoxInvisitek
            // 
            this.chckBoxInvisitek.AutoSize = true;
            this.chckBoxInvisitek.Location = new System.Drawing.Point(13, 96);
            this.chckBoxInvisitek.Name = "chckBoxInvisitek";
            this.chckBoxInvisitek.Size = new System.Drawing.Size(142, 19);
            this.chckBoxInvisitek.TabIndex = 6;
            this.chckBoxInvisitek.Text = "Use invisitek materials";
            this.chckBoxInvisitek.UseVisualStyleBackColor = true;
            // 
            // lblSettings
            // 
            this.lblSettings.AutoSize = true;
            this.lblSettings.Location = new System.Drawing.Point(13, 78);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(49, 15);
            this.lblSettings.TabIndex = 5;
            this.lblSettings.Text = "Settings";
            // 
            // txtBoxConsole
            // 
            this.txtBoxConsole.BackColor = System.Drawing.Color.White;
            this.txtBoxConsole.Location = new System.Drawing.Point(10, 12);
            this.txtBoxConsole.Name = "txtBoxConsole";
            this.txtBoxConsole.ReadOnly = true;
            this.txtBoxConsole.Size = new System.Drawing.Size(522, 389);
            this.txtBoxConsole.TabIndex = 0;
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
            this.Text = "UDK Object Generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.ComponentModel.BackgroundWorker bgWorkerGeneration;
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
    }
}

