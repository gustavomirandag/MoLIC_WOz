namespace MoLIC_WOz_Desktop_Designer
{
    partial class FormInteractionSimulation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInteractionSimulation));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbInteractionPosition = new System.Windows.Forms.GroupBox();
            this.txtUserNote = new System.Windows.Forms.TextBox();
            this.lbLastTransition = new System.Windows.Forms.Label();
            this.lbSpeaker = new System.Windows.Forms.Label();
            this.lbTopic = new System.Windows.Forms.Label();
            this.gbNextStep = new System.Windows.Forms.GroupBox();
            this.txtDesignerNote = new System.Windows.Forms.TextBox();
            this.lbDesignerNote = new System.Windows.Forms.Label();
            this.btnProceed = new System.Windows.Forms.Button();
            this.listBoxOptions = new System.Windows.Forms.ListBox();
            this.lbNextStep = new System.Windows.Forms.Label();
            this.lblSpeaker = new System.Windows.Forms.Label();
            this.listBoxDialogsAndSigns = new System.Windows.Forms.ListBox();
            this.gbInteractionHistory = new System.Windows.Forms.GroupBox();
            this.panelWaitForDesigner = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbWaitingForConnection = new System.Windows.Forms.ProgressBar();
            this.dataGridHistory = new System.Windows.Forms.DataGridView();
            this.Column_UserLegend = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column_UserDialog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DesignerLegend = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column_DesignerDialog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designer_note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dialogDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgListLegends = new System.Windows.Forms.ImageList(this.components);
            this.imgListSpeakers = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbInteractionPosition.SuspendLayout();
            this.gbNextStep.SuspendLayout();
            this.gbInteractionHistory.SuspendLayout();
            this.panelWaitForDesigner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbInteractionPosition);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbInteractionHistory);
            this.splitContainer1.Size = new System.Drawing.Size(860, 562);
            this.splitContainer1.SplitterDistance = 286;
            this.splitContainer1.TabIndex = 9;
            // 
            // gbInteractionPosition
            // 
            this.gbInteractionPosition.Controls.Add(this.txtUserNote);
            this.gbInteractionPosition.Controls.Add(this.lbLastTransition);
            this.gbInteractionPosition.Controls.Add(this.lbSpeaker);
            this.gbInteractionPosition.Controls.Add(this.lbTopic);
            this.gbInteractionPosition.Controls.Add(this.gbNextStep);
            this.gbInteractionPosition.Controls.Add(this.lblSpeaker);
            this.gbInteractionPosition.Controls.Add(this.listBoxDialogsAndSigns);
            this.gbInteractionPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInteractionPosition.Location = new System.Drawing.Point(0, 0);
            this.gbInteractionPosition.Name = "gbInteractionPosition";
            this.gbInteractionPosition.Size = new System.Drawing.Size(286, 562);
            this.gbInteractionPosition.TabIndex = 0;
            this.gbInteractionPosition.TabStop = false;
            this.gbInteractionPosition.Text = "Interaction State";
            // 
            // txtUserNote
            // 
            this.txtUserNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserNote.Location = new System.Drawing.Point(13, 214);
            this.txtUserNote.Multiline = true;
            this.txtUserNote.Name = "txtUserNote";
            this.txtUserNote.ReadOnly = true;
            this.txtUserNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUserNote.Size = new System.Drawing.Size(260, 59);
            this.txtUserNote.TabIndex = 42;
            // 
            // lbLastTransition
            // 
            this.lbLastTransition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbLastTransition.AutoSize = true;
            this.lbLastTransition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLastTransition.ForeColor = System.Drawing.Color.Navy;
            this.lbLastTransition.Location = new System.Drawing.Point(18, 193);
            this.lbLastTransition.Name = "lbLastTransition";
            this.lbLastTransition.Size = new System.Drawing.Size(0, 13);
            this.lbLastTransition.TabIndex = 39;
            // 
            // lbSpeaker
            // 
            this.lbSpeaker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbSpeaker.AutoSize = true;
            this.lbSpeaker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpeaker.Location = new System.Drawing.Point(11, 169);
            this.lbSpeaker.Name = "lbSpeaker";
            this.lbSpeaker.Size = new System.Drawing.Size(99, 17);
            this.lbSpeaker.TabIndex = 38;
            this.lbSpeaker.Text = "The user said:";
            // 
            // lbTopic
            // 
            this.lbTopic.AutoSize = true;
            this.lbTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTopic.ForeColor = System.Drawing.Color.Navy;
            this.lbTopic.Location = new System.Drawing.Point(18, 53);
            this.lbTopic.Name = "lbTopic";
            this.lbTopic.Size = new System.Drawing.Size(0, 13);
            this.lbTopic.TabIndex = 37;
            // 
            // gbNextStep
            // 
            this.gbNextStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNextStep.Controls.Add(this.txtDesignerNote);
            this.gbNextStep.Controls.Add(this.lbDesignerNote);
            this.gbNextStep.Controls.Add(this.btnProceed);
            this.gbNextStep.Controls.Add(this.listBoxOptions);
            this.gbNextStep.Controls.Add(this.lbNextStep);
            this.gbNextStep.Location = new System.Drawing.Point(6, 283);
            this.gbNextStep.Name = "gbNextStep";
            this.gbNextStep.Size = new System.Drawing.Size(274, 273);
            this.gbNextStep.TabIndex = 15;
            this.gbNextStep.TabStop = false;
            this.gbNextStep.Text = "Next Step";
            // 
            // txtDesignerNote
            // 
            this.txtDesignerNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesignerNote.Location = new System.Drawing.Point(9, 36);
            this.txtDesignerNote.Multiline = true;
            this.txtDesignerNote.Name = "txtDesignerNote";
            this.txtDesignerNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesignerNote.Size = new System.Drawing.Size(259, 59);
            this.txtDesignerNote.TabIndex = 2;
            // 
            // lbDesignerNote
            // 
            this.lbDesignerNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDesignerNote.AutoSize = true;
            this.lbDesignerNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDesignerNote.Location = new System.Drawing.Point(6, 16);
            this.lbDesignerNote.Name = "lbDesignerNote";
            this.lbDesignerNote.Size = new System.Drawing.Size(263, 17);
            this.lbDesignerNote.TabIndex = 24;
            this.lbDesignerNote.Text = "Notes to user (you can leave it in blank):";
            // 
            // btnProceed
            // 
            this.btnProceed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProceed.Location = new System.Drawing.Point(136, 244);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(131, 23);
            this.btnProceed.TabIndex = 23;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // listBoxOptions
            // 
            this.listBoxOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxOptions.FormattingEnabled = true;
            this.listBoxOptions.Location = new System.Drawing.Point(9, 118);
            this.listBoxOptions.Name = "listBoxOptions";
            this.listBoxOptions.Size = new System.Drawing.Size(259, 121);
            this.listBoxOptions.TabIndex = 21;
            this.listBoxOptions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBoxOptions_KeyPress);
            this.listBoxOptions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxOptions_MouseDoubleClick);
            // 
            // lbNextStep
            // 
            this.lbNextStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbNextStep.AutoSize = true;
            this.lbNextStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNextStep.Location = new System.Drawing.Point(10, 98);
            this.lbNextStep.Name = "lbNextStep";
            this.lbNextStep.Size = new System.Drawing.Size(194, 17);
            this.lbNextStep.TabIndex = 20;
            this.lbNextStep.Text = "What do you want to answer?";
            // 
            // lblSpeaker
            // 
            this.lblSpeaker.AutoSize = true;
            this.lblSpeaker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeaker.Location = new System.Drawing.Point(12, 28);
            this.lblSpeaker.Name = "lblSpeaker";
            this.lblSpeaker.Size = new System.Drawing.Size(151, 17);
            this.lblSpeaker.TabIndex = 8;
            this.lblSpeaker.Text = "You asked the user to:";
            // 
            // listBoxDialogsAndSigns
            // 
            this.listBoxDialogsAndSigns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxDialogsAndSigns.FormattingEnabled = true;
            this.listBoxDialogsAndSigns.Location = new System.Drawing.Point(14, 75);
            this.listBoxDialogsAndSigns.Name = "listBoxDialogsAndSigns";
            this.listBoxDialogsAndSigns.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxDialogsAndSigns.Size = new System.Drawing.Size(259, 82);
            this.listBoxDialogsAndSigns.TabIndex = 35;
            // 
            // gbInteractionHistory
            // 
            this.gbInteractionHistory.Controls.Add(this.panelWaitForDesigner);
            this.gbInteractionHistory.Controls.Add(this.dataGridHistory);
            this.gbInteractionHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInteractionHistory.Location = new System.Drawing.Point(0, 0);
            this.gbInteractionHistory.Name = "gbInteractionHistory";
            this.gbInteractionHistory.Size = new System.Drawing.Size(570, 562);
            this.gbInteractionHistory.TabIndex = 9;
            this.gbInteractionHistory.TabStop = false;
            this.gbInteractionHistory.Text = "Interaction History";
            // 
            // panelWaitForDesigner
            // 
            this.panelWaitForDesigner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWaitForDesigner.BackColor = System.Drawing.Color.LightGray;
            this.panelWaitForDesigner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWaitForDesigner.Controls.Add(this.label1);
            this.panelWaitForDesigner.Controls.Add(this.pbWaitingForConnection);
            this.panelWaitForDesigner.Location = new System.Drawing.Point(24, 244);
            this.panelWaitForDesigner.Name = "panelWaitForDesigner";
            this.panelWaitForDesigner.Size = new System.Drawing.Size(520, 100);
            this.panelWaitForDesigner.TabIndex = 41;
            this.panelWaitForDesigner.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Please, wait...";
            // 
            // pbWaitingForConnection
            // 
            this.pbWaitingForConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbWaitingForConnection.Location = new System.Drawing.Point(10, 41);
            this.pbWaitingForConnection.Name = "pbWaitingForConnection";
            this.pbWaitingForConnection.Size = new System.Drawing.Size(502, 31);
            this.pbWaitingForConnection.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbWaitingForConnection.TabIndex = 24;
            // 
            // dataGridHistory
            // 
            this.dataGridHistory.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_UserLegend,
            this.Column_UserDialog,
            this.user_note,
            this.Column_DesignerLegend,
            this.Column_DesignerDialog,
            this.designer_note,
            this.dialogDateTime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHistory.Location = new System.Drawing.Point(3, 16);
            this.dataGridHistory.Name = "dataGridHistory";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridHistory.Size = new System.Drawing.Size(564, 543);
            this.dataGridHistory.TabIndex = 1;
            this.dataGridHistory.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridHistory_DataBindingComplete);
            this.dataGridHistory.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridHistory_RowsAdded);
            // 
            // Column_UserLegend
            // 
            this.Column_UserLegend.HeaderText = "User Legend";
            this.Column_UserLegend.Name = "Column_UserLegend";
            this.Column_UserLegend.ReadOnly = true;
            this.Column_UserLegend.Width = 114;
            // 
            // Column_UserDialog
            // 
            this.Column_UserDialog.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_UserDialog.HeaderText = "User Dialog";
            this.Column_UserDialog.Name = "Column_UserDialog";
            this.Column_UserDialog.ReadOnly = true;
            // 
            // user_note
            // 
            this.user_note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.user_note.HeaderText = "User Note";
            this.user_note.Name = "user_note";
            // 
            // Column_DesignerLegend
            // 
            this.Column_DesignerLegend.HeaderText = "Designer Legend";
            this.Column_DesignerLegend.Name = "Column_DesignerLegend";
            this.Column_DesignerLegend.ReadOnly = true;
            this.Column_DesignerLegend.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_DesignerLegend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column_DesignerDialog
            // 
            this.Column_DesignerDialog.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_DesignerDialog.HeaderText = "Designer Dialog";
            this.Column_DesignerDialog.Name = "Column_DesignerDialog";
            this.Column_DesignerDialog.ReadOnly = true;
            // 
            // designer_note
            // 
            this.designer_note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.designer_note.HeaderText = "Designer Note";
            this.designer_note.Name = "designer_note";
            // 
            // dialogDateTime
            // 
            this.dialogDateTime.HeaderText = "Dialog Date Time";
            this.dialogDateTime.Name = "dialogDateTime";
            this.dialogDateTime.ReadOnly = true;
            // 
            // imgListLegends
            // 
            this.imgListLegends.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListLegends.ImageStream")));
            this.imgListLegends.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListLegends.Images.SetKeyName(0, "ico_nothing.JPG");
            this.imgListLegends.Images.SetKeyName(1, "ico_scene.JPG");
            this.imgListLegends.Images.SetKeyName(2, "ico_interaction_state.JPG");
            this.imgListLegends.Images.SetKeyName(3, "ico_opening_point.JPG");
            this.imgListLegends.Images.SetKeyName(4, "ico_closing_point.JPG");
            this.imgListLegends.Images.SetKeyName(5, "ico_system_process.JPG");
            this.imgListLegends.Images.SetKeyName(6, "ico_ubiquitous_access.JPG");
            this.imgListLegends.Images.SetKeyName(7, "ico_utterance.JPG");
            this.imgListLegends.Images.SetKeyName(8, "ico_breakdown.JPG");
            // 
            // imgListSpeakers
            // 
            this.imgListSpeakers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSpeakers.ImageStream")));
            this.imgListSpeakers.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSpeakers.Images.SetKeyName(0, "user.png");
            this.imgListSpeakers.Images.SetKeyName(1, "deputy.png");
            // 
            // FormInteractionSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 562);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormInteractionSimulation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MoLIC WOz - Designer - Interaction Simulation";
            this.TransparencyKey = System.Drawing.Color.Green;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInteractionSimulation_FormClosing);
            this.Load += new System.EventHandler(this.FormInteractionSimulation_Load);
            this.Shown += new System.EventHandler(this.FormInteractionSimulation_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbInteractionPosition.ResumeLayout(false);
            this.gbInteractionPosition.PerformLayout();
            this.gbNextStep.ResumeLayout(false);
            this.gbNextStep.PerformLayout();
            this.gbInteractionHistory.ResumeLayout(false);
            this.panelWaitForDesigner.ResumeLayout(false);
            this.panelWaitForDesigner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbInteractionPosition;
        private System.Windows.Forms.GroupBox gbNextStep;
        private System.Windows.Forms.ListBox listBoxOptions;
        private System.Windows.Forms.Label lbNextStep;
        private System.Windows.Forms.Label lblSpeaker;
        private System.Windows.Forms.GroupBox gbInteractionHistory;
        private System.Windows.Forms.DataGridView dataGridHistory;
        private System.Windows.Forms.ImageList imgListLegends;
        private System.Windows.Forms.ImageList imgListSpeakers;
        private System.Windows.Forms.ListBox listBoxDialogsAndSigns;
        private System.Windows.Forms.Label lbTopic;
        private System.Windows.Forms.Label lbLastTransition;
        private System.Windows.Forms.Label lbSpeaker;
        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.Panel panelWaitForDesigner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbWaitingForConnection;
        private System.Windows.Forms.TextBox txtDesignerNote;
        private System.Windows.Forms.Label lbDesignerNote;
        private System.Windows.Forms.TextBox txtUserNote;
        private System.Windows.Forms.DataGridViewImageColumn Column_UserLegend;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_UserDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_note;
        private System.Windows.Forms.DataGridViewImageColumn Column_DesignerLegend;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DesignerDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn designer_note;
        private System.Windows.Forms.DataGridViewTextBoxColumn dialogDateTime;

    }
}