namespace MoLIC_WOz_Desktop_Designer
{
    partial class FormSelectXmlFile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectXmlFile));
            this.openXmlFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTipStart = new System.Windows.Forms.ToolTip(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.gbModel = new System.Windows.Forms.GroupBox();
            this.lbSelect = new System.Windows.Forms.Label();
            this.btnBrowseXml = new System.Windows.Forms.Button();
            this.txtMoLIXFile = new System.Windows.Forms.TextBox();
            this.gbDatabase = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseDatabase = new System.Windows.Forms.Button();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.gbUserId = new System.Windows.Forms.GroupBox();
            this.txtDesignerId = new System.Windows.Forms.TextBox();
            this.lbDesignerId = new System.Windows.Forms.Label();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbStep1 = new System.Windows.Forms.PictureBox();
            this.pbStep2 = new System.Windows.Forms.PictureBox();
            this.pbStep3 = new System.Windows.Forms.PictureBox();
            this.imgListSteps = new System.Windows.Forms.ImageList(this.components);
            this.openDatabaseFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.gbModel.SuspendLayout();
            this.gbDatabase.SuspendLayout();
            this.gbUserId.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStep1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStep2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStep3)).BeginInit();
            this.SuspendLayout();
            // 
            // openXmlFileDialog
            // 
            this.openXmlFileDialog.DefaultExt = "xml";
            this.openXmlFileDialog.FileName = "openFileDialog1";
            this.openXmlFileDialog.Filter = "MoLIX file format|*.xml";
            // 
            // toolTipStart
            // 
            this.toolTipStart.IsBalloon = true;
            this.toolTipStart.ShowAlways = true;
            this.toolTipStart.Tag = "";
            this.toolTipStart.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(449, 411);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(104, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start Simulation";
            this.toolTipStart.SetToolTip(this.btnStart, "Click here to START simulation!");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gbModel
            // 
            this.gbModel.Controls.Add(this.lbSelect);
            this.gbModel.Controls.Add(this.btnBrowseXml);
            this.gbModel.Controls.Add(this.txtMoLIXFile);
            this.gbModel.Location = new System.Drawing.Point(77, 11);
            this.gbModel.Name = "gbModel";
            this.gbModel.Size = new System.Drawing.Size(476, 102);
            this.gbModel.TabIndex = 5;
            this.gbModel.TabStop = false;
            this.gbModel.Text = "MoLIC Model";
            // 
            // lbSelect
            // 
            this.lbSelect.AutoSize = true;
            this.lbSelect.Location = new System.Drawing.Point(25, 30);
            this.lbSelect.Name = "lbSelect";
            this.lbSelect.Size = new System.Drawing.Size(260, 13);
            this.lbSelect.TabIndex = 6;
            this.lbSelect.Text = "Please, select a XML file on MoLIX format to simulate:";
            // 
            // btnBrowseXml
            // 
            this.btnBrowseXml.Location = new System.Drawing.Point(381, 52);
            this.btnBrowseXml.Name = "btnBrowseXml";
            this.btnBrowseXml.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseXml.TabIndex = 5;
            this.btnBrowseXml.Text = "Browse";
            this.btnBrowseXml.UseVisualStyleBackColor = true;
            this.btnBrowseXml.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtMoLIXFile
            // 
            this.txtMoLIXFile.Location = new System.Drawing.Point(28, 55);
            this.txtMoLIXFile.Name = "txtMoLIXFile";
            this.txtMoLIXFile.ReadOnly = true;
            this.txtMoLIXFile.Size = new System.Drawing.Size(347, 20);
            this.txtMoLIXFile.TabIndex = 4;
            // 
            // gbDatabase
            // 
            this.gbDatabase.Controls.Add(this.label1);
            this.gbDatabase.Controls.Add(this.btnBrowseDatabase);
            this.gbDatabase.Controls.Add(this.txtDatabase);
            this.gbDatabase.Enabled = false;
            this.gbDatabase.Location = new System.Drawing.Point(77, 119);
            this.gbDatabase.Name = "gbDatabase";
            this.gbDatabase.Size = new System.Drawing.Size(476, 107);
            this.gbDatabase.TabIndex = 6;
            this.gbDatabase.TabStop = false;
            this.gbDatabase.Text = "Database file";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select the database file that you want to connect:";
            // 
            // btnBrowseDatabase
            // 
            this.btnBrowseDatabase.Location = new System.Drawing.Point(381, 50);
            this.btnBrowseDatabase.Name = "btnBrowseDatabase";
            this.btnBrowseDatabase.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDatabase.TabIndex = 5;
            this.btnBrowseDatabase.Text = "Browse";
            this.btnBrowseDatabase.UseVisualStyleBackColor = true;
            this.btnBrowseDatabase.Click += new System.EventHandler(this.btnBrowseDatabase_Click);
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(28, 53);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.ReadOnly = true;
            this.txtDatabase.Size = new System.Drawing.Size(347, 20);
            this.txtDatabase.TabIndex = 4;
            // 
            // gbUserId
            // 
            this.gbUserId.Controls.Add(this.txtDesignerId);
            this.gbUserId.Controls.Add(this.lbDesignerId);
            this.gbUserId.Controls.Add(this.listBoxUsers);
            this.gbUserId.Controls.Add(this.label2);
            this.gbUserId.Enabled = false;
            this.gbUserId.Location = new System.Drawing.Point(77, 232);
            this.gbUserId.Name = "gbUserId";
            this.gbUserId.Size = new System.Drawing.Size(476, 173);
            this.gbUserId.TabIndex = 7;
            this.gbUserId.TabStop = false;
            this.gbUserId.Text = "Designer && User Id";
            // 
            // txtDesignerId
            // 
            this.txtDesignerId.Location = new System.Drawing.Point(28, 40);
            this.txtDesignerId.Name = "txtDesignerId";
            this.txtDesignerId.Size = new System.Drawing.Size(315, 20);
            this.txtDesignerId.TabIndex = 9;
            this.txtDesignerId.Tag = "Type a Designer Id for you.";
            // 
            // lbDesignerId
            // 
            this.lbDesignerId.AutoSize = true;
            this.lbDesignerId.Location = new System.Drawing.Point(25, 24);
            this.lbDesignerId.Name = "lbDesignerId";
            this.lbDesignerId.Size = new System.Drawing.Size(135, 13);
            this.lbDesignerId.TabIndex = 8;
            this.lbDesignerId.Text = "Type a Designer Id for you:";
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(28, 92);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(428, 69);
            this.listBoxUsers.TabIndex = 7;
            this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select the USER ID from database that you want to connect:";
            // 
            // pbStep1
            // 
            this.pbStep1.Location = new System.Drawing.Point(12, 25);
            this.pbStep1.Name = "pbStep1";
            this.pbStep1.Size = new System.Drawing.Size(61, 75);
            this.pbStep1.TabIndex = 9;
            this.pbStep1.TabStop = false;
            this.pbStep1.Tag = "Step1";
            // 
            // pbStep2
            // 
            this.pbStep2.Location = new System.Drawing.Point(12, 136);
            this.pbStep2.Name = "pbStep2";
            this.pbStep2.Size = new System.Drawing.Size(61, 75);
            this.pbStep2.TabIndex = 9;
            this.pbStep2.TabStop = false;
            this.pbStep2.Tag = "Step2";
            // 
            // pbStep3
            // 
            this.pbStep3.Location = new System.Drawing.Point(12, 256);
            this.pbStep3.Name = "pbStep3";
            this.pbStep3.Size = new System.Drawing.Size(61, 75);
            this.pbStep3.TabIndex = 10;
            this.pbStep3.TabStop = false;
            this.pbStep3.Tag = "Step3";
            // 
            // imgListSteps
            // 
            this.imgListSteps.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSteps.ImageStream")));
            this.imgListSteps.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSteps.Images.SetKeyName(0, "step1.png");
            this.imgListSteps.Images.SetKeyName(1, "step2.png");
            this.imgListSteps.Images.SetKeyName(2, "step3.png");
            this.imgListSteps.Images.SetKeyName(3, "step1_selected.png");
            this.imgListSteps.Images.SetKeyName(4, "step2_selected.png");
            this.imgListSteps.Images.SetKeyName(5, "step3_selected.png");
            // 
            // openDatabaseFileDialog
            // 
            this.openDatabaseFileDialog.FileName = "mdb";
            this.openDatabaseFileDialog.Filter = "Microsoft Access datafile|*.mdb";
            // 
            // FormSelectXmlFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 441);
            this.Controls.Add(this.pbStep3);
            this.Controls.Add(this.pbStep2);
            this.Controls.Add(this.pbStep1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gbUserId);
            this.Controls.Add(this.gbDatabase);
            this.Controls.Add(this.gbModel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectXmlFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MoLIC Wizard Of Oz Simulation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSelectXmlFile_FormClosing);
            this.Load += new System.EventHandler(this.FormSelectXmlFile_Load);
            this.gbModel.ResumeLayout(false);
            this.gbModel.PerformLayout();
            this.gbDatabase.ResumeLayout(false);
            this.gbDatabase.PerformLayout();
            this.gbUserId.ResumeLayout(false);
            this.gbUserId.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStep1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStep2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStep3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openXmlFileDialog;
        private System.Windows.Forms.ToolTip toolTipStart;
        private System.Windows.Forms.GroupBox gbModel;
        private System.Windows.Forms.Label lbSelect;
        private System.Windows.Forms.Button btnBrowseXml;
        private System.Windows.Forms.TextBox txtMoLIXFile;
        private System.Windows.Forms.GroupBox gbDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseDatabase;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.GroupBox gbUserId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.PictureBox pbStep1;
        private System.Windows.Forms.PictureBox pbStep2;
        private System.Windows.Forms.PictureBox pbStep3;
        private System.Windows.Forms.ImageList imgListSteps;
        private System.Windows.Forms.OpenFileDialog openDatabaseFileDialog;
        private System.Windows.Forms.TextBox txtDesignerId;
        private System.Windows.Forms.Label lbDesignerId;
    }
}

