namespace MoLIC_WOz_Desktop_User
{
    partial class FormWaitConnection
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbWait = new System.Windows.Forms.GroupBox();
            this.pbWaitingForConnection = new System.Windows.Forms.ProgressBar();
            this.lbSelect = new System.Windows.Forms.Label();
            this.toolTipWait = new System.Windows.Forms.ToolTip(this.components);
            this.btnWait = new System.Windows.Forms.Button();
            this.openDatabaseFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.gbDatafile = new System.Windows.Forms.GroupBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseDatabase = new System.Windows.Forms.Button();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbWait.SuspendLayout();
            this.gbDatafile.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(465, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbWait
            // 
            this.gbWait.Controls.Add(this.pbWaitingForConnection);
            this.gbWait.Controls.Add(this.lbSelect);
            this.gbWait.Location = new System.Drawing.Point(12, 12);
            this.gbWait.Name = "gbWait";
            this.gbWait.Size = new System.Drawing.Size(528, 132);
            this.gbWait.TabIndex = 7;
            this.gbWait.TabStop = false;
            this.gbWait.Text = "Starting Simulation";
            this.gbWait.Visible = false;
            // 
            // pbWaitingForConnection
            // 
            this.pbWaitingForConnection.Location = new System.Drawing.Point(76, 69);
            this.pbWaitingForConnection.Name = "pbWaitingForConnection";
            this.pbWaitingForConnection.Size = new System.Drawing.Size(386, 17);
            this.pbWaitingForConnection.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbWaitingForConnection.TabIndex = 21;
            // 
            // lbSelect
            // 
            this.lbSelect.AutoSize = true;
            this.lbSelect.Location = new System.Drawing.Point(41, 36);
            this.lbSelect.Name = "lbSelect";
            this.lbSelect.Size = new System.Drawing.Size(73, 13);
            this.lbSelect.TabIndex = 6;
            this.lbSelect.Text = "Please, wait...";
            // 
            // toolTipWait
            // 
            this.toolTipWait.IsBalloon = true;
            this.toolTipWait.ShowAlways = true;
            this.toolTipWait.Tag = "";
            this.toolTipWait.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnWait
            // 
            this.btnWait.Enabled = false;
            this.btnWait.Location = new System.Drawing.Point(414, 151);
            this.btnWait.Name = "btnWait";
            this.btnWait.Size = new System.Drawing.Size(127, 23);
            this.btnWait.TabIndex = 3;
            this.btnWait.Text = "Click here to START";
            this.toolTipWait.SetToolTip(this.btnWait, "Click here to START a simulation.");
            this.btnWait.UseVisualStyleBackColor = true;
            this.btnWait.Click += new System.EventHandler(this.btnWait_Click);
            // 
            // openDatabaseFileDialog
            // 
            this.openDatabaseFileDialog.FileName = "mdb";
            this.openDatabaseFileDialog.Filter = "Microsoft Access datafile|*.mdb";
            // 
            // gbDatafile
            // 
            this.gbDatafile.Controls.Add(this.txtUserId);
            this.gbDatafile.Controls.Add(this.label2);
            this.gbDatafile.Controls.Add(this.btnBrowseDatabase);
            this.gbDatafile.Controls.Add(this.txtDatabase);
            this.gbDatafile.Controls.Add(this.label1);
            this.gbDatafile.Location = new System.Drawing.Point(12, 11);
            this.gbDatafile.Name = "gbDatafile";
            this.gbDatafile.Size = new System.Drawing.Size(528, 132);
            this.gbDatafile.TabIndex = 20;
            this.gbDatafile.TabStop = false;
            this.gbDatafile.Text = "User Id && Database";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(22, 41);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(315, 20);
            this.txtUserId.TabIndex = 1;
            this.txtUserId.Tag = "Type a Designer Id for you.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Select the database file that you want to connect:";
            // 
            // btnBrowseDatabase
            // 
            this.btnBrowseDatabase.Location = new System.Drawing.Point(375, 90);
            this.btnBrowseDatabase.Name = "btnBrowseDatabase";
            this.btnBrowseDatabase.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDatabase.TabIndex = 2;
            this.btnBrowseDatabase.Text = "Browse";
            this.btnBrowseDatabase.UseVisualStyleBackColor = true;
            this.btnBrowseDatabase.Click += new System.EventHandler(this.btnBrowseDatabase_Click);
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(22, 92);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.ReadOnly = true;
            this.txtDatabase.Size = new System.Drawing.Size(347, 20);
            this.txtDatabase.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Please, type a User Id for you:";
            // 
            // FormWaitConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 185);
            this.Controls.Add(this.gbDatafile);
            this.Controls.Add(this.btnWait);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbWait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWaitConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MoLIC WOz - User Vision";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWaitConnection_FormClosing);
            this.Shown += new System.EventHandler(this.FormWaitConnection_Shown);
            this.gbWait.ResumeLayout(false);
            this.gbWait.PerformLayout();
            this.gbDatafile.ResumeLayout(false);
            this.gbDatafile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbWait;
        private System.Windows.Forms.ProgressBar pbWaitingForConnection;
        private System.Windows.Forms.Label lbSelect;
        private System.Windows.Forms.ToolTip toolTipWait;
        private System.Windows.Forms.Button btnWait;
        private System.Windows.Forms.OpenFileDialog openDatabaseFileDialog;
        private System.Windows.Forms.GroupBox gbDatafile;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseDatabase;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label1;

    }
}

