namespace MoLIC_WOz_Desktop_User
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInteractionSimulation));
            this.imgListLegends = new System.Windows.Forms.ImageList(this.components);
            this.imgListSpeakers = new System.Windows.Forms.ImageList(this.components);
            this.gbInteractionPosition = new System.Windows.Forms.GroupBox();
            this.lbHeAlsoAdded = new System.Windows.Forms.Label();
            this.panelWaitForDesigner = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbWaitingForConnection = new System.Windows.Forms.ProgressBar();
            this.lbTopic = new System.Windows.Forms.Label();
            this.lbLastTransition = new System.Windows.Forms.Label();
            this.lbYouMayNow = new System.Windows.Forms.Label();
            this.gbNextStep = new System.Windows.Forms.GroupBox();
            this.txtUserNote = new System.Windows.Forms.TextBox();
            this.lbDesignerNote = new System.Windows.Forms.Label();
            this.listBoxOptions = new System.Windows.Forms.ListBox();
            this.btnProceed = new System.Windows.Forms.Button();
            this.lbNextStep = new System.Windows.Forms.Label();
            this.lbSpeaker = new System.Windows.Forms.Label();
            this.listBoxDialogsAndSigns = new System.Windows.Forms.ListBox();
            this.txtDesignerNote = new System.Windows.Forms.TextBox();
            this.gbInteractionPosition.SuspendLayout();
            this.panelWaitForDesigner.SuspendLayout();
            this.gbNextStep.SuspendLayout();
            this.SuspendLayout();
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
            // gbInteractionPosition
            // 
            this.gbInteractionPosition.Controls.Add(this.panelWaitForDesigner);
            this.gbInteractionPosition.Controls.Add(this.txtDesignerNote);
            this.gbInteractionPosition.Controls.Add(this.lbHeAlsoAdded);
            this.gbInteractionPosition.Controls.Add(this.lbTopic);
            this.gbInteractionPosition.Controls.Add(this.lbLastTransition);
            this.gbInteractionPosition.Controls.Add(this.lbYouMayNow);
            this.gbInteractionPosition.Controls.Add(this.gbNextStep);
            this.gbInteractionPosition.Controls.Add(this.lbSpeaker);
            this.gbInteractionPosition.Controls.Add(this.listBoxDialogsAndSigns);
            this.gbInteractionPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInteractionPosition.Location = new System.Drawing.Point(0, 0);
            this.gbInteractionPosition.Name = "gbInteractionPosition";
            this.gbInteractionPosition.Size = new System.Drawing.Size(556, 507);
            this.gbInteractionPosition.TabIndex = 1;
            this.gbInteractionPosition.TabStop = false;
            this.gbInteractionPosition.Text = "Interaction State";
            // 
            // lbHeAlsoAdded
            // 
            this.lbHeAlsoAdded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHeAlsoAdded.AutoSize = true;
            this.lbHeAlsoAdded.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeAlsoAdded.Location = new System.Drawing.Point(300, 88);
            this.lbHeAlsoAdded.Name = "lbHeAlsoAdded";
            this.lbHeAlsoAdded.Size = new System.Drawing.Size(104, 17);
            this.lbHeAlsoAdded.TabIndex = 44;
            this.lbHeAlsoAdded.Text = "He also added:";
            // 
            // panelWaitForDesigner
            // 
            this.panelWaitForDesigner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWaitForDesigner.BackColor = System.Drawing.Color.LightGray;
            this.panelWaitForDesigner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWaitForDesigner.Controls.Add(this.label1);
            this.panelWaitForDesigner.Controls.Add(this.pbWaitingForConnection);
            this.panelWaitForDesigner.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelWaitForDesigner.Location = new System.Drawing.Point(44, 121);
            this.panelWaitForDesigner.Name = "panelWaitForDesigner";
            this.panelWaitForDesigner.Size = new System.Drawing.Size(467, 104);
            this.panelWaitForDesigner.TabIndex = 25;
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
            this.pbWaitingForConnection.Size = new System.Drawing.Size(449, 31);
            this.pbWaitingForConnection.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbWaitingForConnection.TabIndex = 24;
            // 
            // lbTopic
            // 
            this.lbTopic.AutoSize = true;
            this.lbTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTopic.ForeColor = System.Drawing.Color.Navy;
            this.lbTopic.Location = new System.Drawing.Point(19, 100);
            this.lbTopic.Name = "lbTopic";
            this.lbTopic.Size = new System.Drawing.Size(0, 13);
            this.lbTopic.TabIndex = 40;
            // 
            // lbLastTransition
            // 
            this.lbLastTransition.AutoSize = true;
            this.lbLastTransition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLastTransition.ForeColor = System.Drawing.Color.Navy;
            this.lbLastTransition.Location = new System.Drawing.Point(19, 47);
            this.lbLastTransition.Name = "lbLastTransition";
            this.lbLastTransition.Size = new System.Drawing.Size(0, 13);
            this.lbLastTransition.TabIndex = 39;
            // 
            // lbYouMayNow
            // 
            this.lbYouMayNow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbYouMayNow.AutoSize = true;
            this.lbYouMayNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYouMayNow.Location = new System.Drawing.Point(12, 75);
            this.lbYouMayNow.Name = "lbYouMayNow";
            this.lbYouMayNow.Size = new System.Drawing.Size(96, 17);
            this.lbYouMayNow.TabIndex = 30;
            this.lbYouMayNow.Text = "You may now:";
            // 
            // gbNextStep
            // 
            this.gbNextStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNextStep.Controls.Add(this.txtUserNote);
            this.gbNextStep.Controls.Add(this.lbDesignerNote);
            this.gbNextStep.Controls.Add(this.listBoxOptions);
            this.gbNextStep.Controls.Add(this.btnProceed);
            this.gbNextStep.Controls.Add(this.lbNextStep);
            this.gbNextStep.Location = new System.Drawing.Point(6, 282);
            this.gbNextStep.Name = "gbNextStep";
            this.gbNextStep.Size = new System.Drawing.Size(544, 219);
            this.gbNextStep.TabIndex = 15;
            this.gbNextStep.TabStop = false;
            this.gbNextStep.Text = "Next Step";
            // 
            // txtUserNote
            // 
            this.txtUserNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserNote.Location = new System.Drawing.Point(9, 34);
            this.txtUserNote.Multiline = true;
            this.txtUserNote.Name = "txtUserNote";
            this.txtUserNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUserNote.Size = new System.Drawing.Size(527, 52);
            this.txtUserNote.TabIndex = 25;
            // 
            // lbDesignerNote
            // 
            this.lbDesignerNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDesignerNote.AutoSize = true;
            this.lbDesignerNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDesignerNote.Location = new System.Drawing.Point(6, 14);
            this.lbDesignerNote.Name = "lbDesignerNote";
            this.lbDesignerNote.Size = new System.Drawing.Size(290, 17);
            this.lbDesignerNote.TabIndex = 26;
            this.lbDesignerNote.Text = "Notes to designer (you can leave it in blank):";
            // 
            // listBoxOptions
            // 
            this.listBoxOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxOptions.FormattingEnabled = true;
            this.listBoxOptions.Location = new System.Drawing.Point(9, 109);
            this.listBoxOptions.Name = "listBoxOptions";
            this.listBoxOptions.Size = new System.Drawing.Size(527, 69);
            this.listBoxOptions.TabIndex = 21;
            this.listBoxOptions.DoubleClick += new System.EventHandler(this.listBoxOptions_DoubleClick);
            this.listBoxOptions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBoxOptions_KeyPress);
            // 
            // btnProceed
            // 
            this.btnProceed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProceed.Location = new System.Drawing.Point(381, 184);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(155, 23);
            this.btnProceed.TabIndex = 22;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.listBoxOptions_DoubleClick);
            // 
            // lbNextStep
            // 
            this.lbNextStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbNextStep.AutoSize = true;
            this.lbNextStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNextStep.Location = new System.Drawing.Point(6, 89);
            this.lbNextStep.Name = "lbNextStep";
            this.lbNextStep.Size = new System.Drawing.Size(212, 17);
            this.lbNextStep.TabIndex = 20;
            this.lbNextStep.Text = "What would you like to say now?";
            // 
            // lbSpeaker
            // 
            this.lbSpeaker.AutoSize = true;
            this.lbSpeaker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpeaker.Location = new System.Drawing.Point(12, 22);
            this.lbSpeaker.Name = "lbSpeaker";
            this.lbSpeaker.Size = new System.Drawing.Size(126, 17);
            this.lbSpeaker.TabIndex = 8;
            this.lbSpeaker.Text = "The designer said:";
            // 
            // listBoxDialogsAndSigns
            // 
            this.listBoxDialogsAndSigns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxDialogsAndSigns.FormattingEnabled = true;
            this.listBoxDialogsAndSigns.Location = new System.Drawing.Point(15, 119);
            this.listBoxDialogsAndSigns.Name = "listBoxDialogsAndSigns";
            this.listBoxDialogsAndSigns.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxDialogsAndSigns.Size = new System.Drawing.Size(278, 147);
            this.listBoxDialogsAndSigns.TabIndex = 31;
            // 
            // txtDesignerNote
            // 
            this.txtDesignerNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesignerNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesignerNote.Location = new System.Drawing.Point(299, 119);
            this.txtDesignerNote.Multiline = true;
            this.txtDesignerNote.Name = "txtDesignerNote";
            this.txtDesignerNote.ReadOnly = true;
            this.txtDesignerNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesignerNote.Size = new System.Drawing.Size(251, 147);
            this.txtDesignerNote.TabIndex = 45;
            // 
            // FormInteractionSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 507);
            this.Controls.Add(this.gbInteractionPosition);
            this.MinimumSize = new System.Drawing.Size(266, 38);
            this.Name = "FormInteractionSimulation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MoLIC WOz - User - Interaction Simulation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInteractionSimulation_FormClosing);
            this.Shown += new System.EventHandler(this.FormInteractionSimulation_Shown);
            this.gbInteractionPosition.ResumeLayout(false);
            this.gbInteractionPosition.PerformLayout();
            this.panelWaitForDesigner.ResumeLayout(false);
            this.panelWaitForDesigner.PerformLayout();
            this.gbNextStep.ResumeLayout(false);
            this.gbNextStep.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgListLegends;
        private System.Windows.Forms.ImageList imgListSpeakers;
        private System.Windows.Forms.GroupBox gbInteractionPosition;
        private System.Windows.Forms.Panel panelWaitForDesigner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbWaitingForConnection;
        private System.Windows.Forms.GroupBox gbNextStep;
        private System.Windows.Forms.ListBox listBoxOptions;
        private System.Windows.Forms.Label lbNextStep;
        private System.Windows.Forms.Label lbSpeaker;
        private System.Windows.Forms.Label lbYouMayNow;
        private System.Windows.Forms.ListBox listBoxDialogsAndSigns;
        private System.Windows.Forms.Label lbTopic;
        private System.Windows.Forms.Label lbLastTransition;
        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.TextBox txtUserNote;
        private System.Windows.Forms.Label lbDesignerNote;
        private System.Windows.Forms.Label lbHeAlsoAdded;
        private System.Windows.Forms.TextBox txtDesignerNote;
    }
}