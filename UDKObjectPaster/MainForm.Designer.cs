
namespace UDKObjectPaster
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
            this.chkLstBoxTypesToGenerate = new System.Windows.Forms.CheckedListBox();
            this.lblTypesToGenerate = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
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
            this.btnGenerate.Location = new System.Drawing.Point(179, 316);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
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
            // chkLstBoxTypesToGenerate
            // 
            this.chkLstBoxTypesToGenerate.FormattingEnabled = true;
            this.chkLstBoxTypesToGenerate.Items.AddRange(new object[] {
            "DynamicMeshActor_TA",
            "InterpActor",
            "PlayerStart_TA",
            "StaticMeshActor",
            "StaticMeshActor_SMC"});
            this.chkLstBoxTypesToGenerate.Location = new System.Drawing.Point(13, 92);
            this.chkLstBoxTypesToGenerate.Name = "chkLstBoxTypesToGenerate";
            this.chkLstBoxTypesToGenerate.Size = new System.Drawing.Size(241, 94);
            this.chkLstBoxTypesToGenerate.TabIndex = 1;
            // 
            // lblTypesToGenerate
            // 
            this.lblTypesToGenerate.AutoSize = true;
            this.lblTypesToGenerate.Location = new System.Drawing.Point(13, 74);
            this.lblTypesToGenerate.Name = "lblTypesToGenerate";
            this.lblTypesToGenerate.Size = new System.Drawing.Size(99, 15);
            this.lblTypesToGenerate.TabIndex = 2;
            this.lblTypesToGenerate.Text = "Types to generate";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
            this.splitContainer1.Panel1.Controls.Add(this.chkLstBoxTypesToGenerate);
            this.splitContainer1.Panel1.Controls.Add(this.lblFileName);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenerate);
            this.splitContainer1.Panel1.Controls.Add(this.btnBrowse);
            this.splitContainer1.Panel1.Controls.Add(this.lblTypesToGenerate);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtBoxConsole);
            this.splitContainer1.Size = new System.Drawing.Size(822, 349);
            this.splitContainer1.SplitterDistance = 274;
            this.splitContainer1.TabIndex = 5;
            // 
            // txtBoxConsole
            // 
            this.txtBoxConsole.BackColor = System.Drawing.Color.White;
            this.txtBoxConsole.Location = new System.Drawing.Point(10, 12);
            this.txtBoxConsole.Name = "txtBoxConsole";
            this.txtBoxConsole.ReadOnly = true;
            this.txtBoxConsole.Size = new System.Drawing.Size(522, 325);
            this.txtBoxConsole.TabIndex = 0;
            this.txtBoxConsole.Text = "";
            this.txtBoxConsole.TextChanged += new System.EventHandler(this.TxtBoxConsole_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 348);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "UDK Object Paster";
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
        private System.Windows.Forms.CheckedListBox chkLstBoxTypesToGenerate;
        private System.Windows.Forms.Label lblTypesToGenerate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txtBoxConsole;
    }
}

