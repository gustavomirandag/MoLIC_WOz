using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using MoLIC_WOz_Core.Control;
using MoLIC_WOz_Core.Model;

namespace MoLIC_WOz_Desktop_User
{
    public partial class FormInteractionSimulation : Form
    {
        private int simulationId;
        private string nextSpeaker;
        private string speaker;
        private bool needToClose = false;
        ComponentsPosition originalComponentsPosition;

        private class ComponentsPosition
        {
            public GroupBox gbNextStep;
            public Label lbNextStep;
            public ListBox listBoxOptions;

            public ComponentsPosition(GroupBox gbNextStepAux, Label lbNextStepAux, ListBox listBoxOptionsAux)
            {
                this.gbNextStep = new GroupBox();
                this.gbNextStep.Height = gbNextStepAux.Height;
                this.gbNextStep.Anchor = gbNextStepAux.Anchor;

                this.lbNextStep = new Label();
                this.lbNextStep.Height = lbNextStepAux.Height;
                this.lbNextStep.Anchor = lbNextStepAux.Anchor;

                this.listBoxOptions = new ListBox();
                this.listBoxOptions.Height = listBoxOptionsAux.Height;
                this.listBoxOptions.Anchor = listBoxOptionsAux.Anchor;
            }
        }

        public FormInteractionSimulation()
        {
            InitializeComponent();
        }

        public void setSimulationId(int simulationId)
        {
            this.simulationId = simulationId;
        }

        public void setSpeaker(string speaker)
        {
            this.speaker = speaker;
        }

        public void setNextSpeaker(string nextSpeaker)
        {
            this.nextSpeaker = nextSpeaker;
        }

        private void callNextSpeakerAndWait()
        {
            gbInteractionPosition.Enabled = false;
            panelWaitForDesigner.Visible = true;

            DbControl.getInstance().callNextSpeaker(simulationId, nextSpeaker);
            while ((!DbControl.getInstance().checkNextSpeaker(simulationId, speaker)) && (!needToClose))
            {
                Application.DoEvents();
            }
            if (needToClose)
                Application.Exit();
            gbInteractionPosition.Enabled = true;
            panelWaitForDesigner.Visible = false;
        }

        private void waitToBeNextSpeaker()
        {
            gbInteractionPosition.Enabled = false;
            panelWaitForDesigner.Visible = true;
            while ((!DbControl.getInstance().checkNextSpeaker(simulationId, speaker)) && (!needToClose))
            {
                Application.DoEvents();
            }
            if (needToClose)
                Application.Exit();
            gbInteractionPosition.Enabled = true;
            panelWaitForDesigner.Visible = false;
        }

        private void refreshHistory(THistory tHistory)
        {
            /*dataGridHistory.DataSource = null;
            dataGridHistory.Refresh();
            this.tB_HISTORYSTableAdapter.Connection = new System.Data.OleDb.OleDbConnection(DbControl.getInstance().getDataBaseConnectionString());
            this.tB_HISTORYSTableAdapter.Fill(this.dbMoLIC_WOz_TB_HISTORY.TB_HISTORYS, simulationId);
            dataGridHistory.DataSource = dbMoLIC_WOz_TB_HISTORY.TB_HISTORYS;
            dataGridHistory.Refresh();*/
            TTransitionUtterance tTransactionUtterance;
            if (tHistory.user_tu_id >= 0)
            {
                tTransactionUtterance = DbControl.getInstance().getTransitionUtterance(tHistory.user_tu_id);
                //------ Set Last Transition ------
                lbSpeaker.Text = "You said:";
                lbLastTransition.Text = tTransactionUtterance.description;
                lbTopic.Text = tTransactionUtterance.source_topic;
                if (tHistory.designer_note != "")
                {
                    lbHeAlsoAdded.Text = "And the designer added:";
                    txtDesignerNote.Text = tHistory.designer_note;
                    lbHeAlsoAdded.Visible = true;
                    txtDesignerNote.Visible = true;
                }
                else
                {
                    lbHeAlsoAdded.Text = "";
                    lbHeAlsoAdded.Visible = false;
                    txtDesignerNote.Visible = false;
                }
                //pbLocation.Image = imgListLegends.Images[1];
                //---------------------------------

                //------ Add Dialogs & Signs ------
                listBoxDialogsAndSigns.Items.Clear();
                if (tTransactionUtterance.legend == 1)
                {
                    List<TDialog> tDialogs = DbControl.getInstance().getUserTransitionUtteranceDialogs(tTransactionUtterance.id);
                    if (tDialogs != null)
                    {
                        showDialogsAndSigns(true);
                        for (int countDialogs = 0; countDialogs < tDialogs.Count; countDialogs++)
                        {
                            listBoxDialogsAndSigns.Items.Add(tDialogs[countDialogs].dialog);
                            if (tDialogs[countDialogs].signs != null)
                            {
                                for (int countSigns = 0; countSigns < tDialogs[countDialogs].signs.Count; countSigns++)
                                {
                                    listBoxDialogsAndSigns.Items.Add("  " + tDialogs[countDialogs].signs[countSigns].sign);
                                }
                            }
                        }
                    }
                    else
                    {
                        showDialogsAndSigns(false);
                    }
                }
                else
                {
                    showDialogsAndSigns(false);
                }
                //---------------------------------
            }
            else
            {
                tTransactionUtterance = DbControl.getInstance().getTransitionUtterance(tHistory.designer_tu_id);
                //------ Set Last Transition ------
                lbSpeaker.Text = "The designer said:";
                lbLastTransition.Text = tTransactionUtterance.description;
                if (tHistory.designer_note != "")
                {
                    lbHeAlsoAdded.Text = "He also added:";
                    txtDesignerNote.Text = tHistory.designer_note;
                    lbHeAlsoAdded.Visible = true;
                    txtDesignerNote.Visible = true;
                }
                else
                {
                    lbHeAlsoAdded.Text = "";
                    lbHeAlsoAdded.Visible = false;
                    txtDesignerNote.Visible = false;
                }
                Image imgLegend = null;
                if (tTransactionUtterance.target.Contains("scene"))
                    imgLegend = imgListLegends.Images[1];
                if (tTransactionUtterance.target.Contains("system"))
                    imgLegend = imgListLegends.Images[5];
                if (tTransactionUtterance.target.Contains("op"))
                    imgLegend = imgListLegends.Images[3];
                //pbLocation.Image = imgLegend;
                //pbAnswer.Image = imgListLegends.Images[5];
                //---------------------------------
                //dataGridHistory.Rows.Add(imgListLegends.Images[0], "", "", imgListLegends.Images[tTransactionUtterance.legend], tTransactionUtterance.description, "", tHistory.dialogDateTime.ToString());
            }

        }

        private void FormInteractionSimulation_FormClosing(object sender, FormClosingEventArgs e)
        {
            needToClose = true;
            Application.DoEvents();
            //DbControl.getInstance().closeConnection();
            Application.Exit();
        }

        private void FormInteractionSimulation_Shown(object sender, EventArgs e)
        {
            originalComponentsPosition = new ComponentsPosition(gbNextStep, lbNextStep, listBoxOptions);
            chooseOpeningPoint();
        }

        private void chooseOpeningPoint()
        {
            waitToBeNextSpeaker();

            //Show only the first step
            listBoxDialogsAndSigns.Visible = false;
            lbHeAlsoAdded.Visible = false;
            txtDesignerNote.Visible = false;
            lbDesignerNote.Visible = false;
            txtUserNote.Visible = false;
            gbNextStep.Top = 20;
            gbNextStep.Height = gbInteractionPosition.Height - 35;
            gbNextStep.Anchor = listBoxDialogsAndSigns.Anchor;
            listBoxOptions.Anchor = listBoxDialogsAndSigns.Anchor;
            listBoxOptions.Height = gbNextStep.Height - 75;
            listBoxOptions.Top = 35;
            lbNextStep.Top = 15;
            lbNextStep.Anchor = lbSpeaker.Anchor;
            gbNextStep.Text = "First Step";
            lbNextStep.Text = "What would you like to say?";
            lbYouMayNow.Visible = false;

            listBoxOptions.Items.Clear();
            //###### Add Dialog Options ######
            List<TTransitionUtterance> userTransitionUtteranceOptions = DbControl.getInstance().getUserTransitionUtteranceOptions(simulationId);
            //List Of Opening Points
            for (int count = 0; count < userTransitionUtteranceOptions.Count; count++)
            {
                //this.addDialogOption(userDialogOptions[count].dialog, userDialogOptions[count].id.ToString());
                listBoxOptions.Items.Add(userTransitionUtteranceOptions[count]);
            }

            if (userTransitionUtteranceOptions.Count <= 0)
            {
                MessageBox.Show("Could not find any opening point in this XML file. The simulation will be aborted.");
                Application.Exit();
            }
            listBoxOptions.SelectedIndex = 0;
            //################################
        }

        private void doDialog(int transitionId, string userNote)
        {
            DbControl.getInstance().selectUserTransitionUtteranceOption(transitionId, userNote);
        }


        void showSignsAndImgLegend(string interactionModel)
        {
        }

        //############# FORM INTERACTION DIALOG ###############
        public class DialogOption
        {
            private string _dialogDetails;
            private string _dialogValue;

            public string dialogDetails
            {
                get { return _dialogDetails; }
                set { _dialogDetails = value; }
            }

            public string dialogValue
            {
                get { return _dialogValue; }
                set { _dialogValue = value; }
            }

            public DialogOption(string dialogDetails, string dialogValue)
            {
                this.dialogDetails = dialogDetails;
                this.dialogValue = dialogValue;
            }

            public override string ToString()
            {
                return dialogDetails;
            }
        }

        private DialogOption _dialogOptionChoosed = null;
        private TTransitionUtterance _transitionUtteranceChoosed = null;

        public DialogOption dialogOptionChoosed
        {
            get { return _dialogOptionChoosed; }
            set { _dialogOptionChoosed = value; }
        }

        public TTransitionUtterance transitionUtteranceChoosed
        {
            get { return _transitionUtteranceChoosed; }
            set { _transitionUtteranceChoosed = value; }
        }

        public void addDialogOption(string dialogDetails, string dialogValue)
        {
            listBoxOptions.Items.Add(new DialogOption(dialogDetails, dialogValue));
        }

        public void addDialogOption(TTransitionUtterance transitionUtterance)
        {
            listBoxOptions.Items.Add(transitionUtterance);
        }

        private void FormInteractionDialog_Shown(object sender, EventArgs e)
        {
        }

        void showDialogOptions()
        {
            List<TTransitionUtterance> userTransitionUtteranceOptions = DbControl.getInstance().getUserTransitionUtteranceOptions(simulationId);

            if (userTransitionUtteranceOptions.Count <= 0)
            {
                listBoxOptions.Items.Clear();
                listBoxOptions.Enabled = false;
                gbInteractionPosition.Visible = false;
                MessageBox.Show("You have reached a closing point, the interaction has been completed. Press 'OK' to close the application.");
                this.Close();
            }

            //###### Add Scene elements ######
            //---- Set Location ----
            /*Image imgLegend = null;
            if (userTransitionUtteranceOptions[0].source.Contains("scene"))
                imgLegend = imgListLegends.Images[1];
            if (userTransitionUtteranceOptions[0].source.Contains("system"))
                imgLegend = imgListLegends.Images[5];
            if (userTransitionUtteranceOptions[0].source.Contains("op"))
                imgLegend = imgListLegends.Images[3];
            pbLocation.Image = imgLegend;*/
            //----------------------
            //################################

            listBoxOptions.Items.Clear();
            //###### Add Dialog Options ######
            //List Of Opening Points
            for (int count = 0; count < userTransitionUtteranceOptions.Count; count++)
            {
                //this.addDialogOption(userDialogOptions[count].dialog, userDialogOptions[count].id.ToString());
                listBoxOptions.Items.Add(userTransitionUtteranceOptions[count]);
            }
            if (userTransitionUtteranceOptions.Count > 0)
            {
                listBoxOptions.SelectedIndex = 0;
                listBoxOptions.Focus();
            }

            //################ TEMP TO FIX ##################
            //------ Add Dialogs & Signs ------
            listBoxDialogsAndSigns.Items.Clear();
            lbTopic.Text = userTransitionUtteranceOptions[0].source_topic;
            if (userTransitionUtteranceOptions[0].legend == 1)
            {
                List<TDialog> tDialogs = DbControl.getInstance().getUserTransitionUtteranceDialogs(userTransitionUtteranceOptions[0].id);
                if (tDialogs != null)
                {
                    showDialogsAndSigns(true);
                    for (int countDialogs = 0; countDialogs < tDialogs.Count; countDialogs++)
                    {
                        listBoxDialogsAndSigns.Items.Add(tDialogs[countDialogs].dialog);
                        if (tDialogs[countDialogs].signs != null)
                        {
                            for (int countSigns = 0; countSigns < tDialogs[countDialogs].signs.Count; countSigns++)
                            {
                                listBoxDialogsAndSigns.Items.Add("  - " + tDialogs[countDialogs].signs[countSigns].sign);
                            }
                        }
                    }
                }
                else
                {
                    showDialogsAndSigns(false);
                }
            }
            else
            {
                showDialogsAndSigns(false);
            }
            //---------------------------------
            //###############################################
            //################################
        }

/*        private void dataGridHistory_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int index = dataGridHistory.Rows.Count - 1;

            //First is to scroll down the DataGridView so the row is visible in the screen:
            dataGridHistory.FirstDisplayedScrollingRowIndex = index;
            dataGridHistory.Refresh();

            //Then you must select the row so that binding sources update their Current item:
            //dataGridHistory.CurrentCell = dataGridHistory.Rows[index].Cells[0];  //Disabled to enable SELECT something and don't lose the selection!

            //Finally, you can visually select the row with C#:
            if (index > 0)
                dataGridHistory.Rows[index - 1].Selected = false;
            dataGridHistory.Rows[index].Selected = true;
        }*/

        private void dgSigns_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridHistory_AutoSizeColumnModeChanged(object sender, DataGridViewAutoSizeColumnModeEventArgs e)
        {

        }

        private void listBoxOptions_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxOptions.SelectedIndex < 0)
                return;
            int transactionId = ((TTransitionUtterance)listBoxOptions.SelectedItem).id;
            doDialog(transactionId, txtUserNote.Text);
            txtUserNote.Text = "";

            THistory tLastHistory = DbControl.getInstance().getLastHistory(simulationId);
            refreshHistory(tLastHistory);

            callNextSpeakerAndWait();

            tLastHistory = DbControl.getInstance().getLastHistory(simulationId);
            refreshHistory(tLastHistory);

            showDialogOptions();
        }

        private void listBoxOptions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                listBoxOptions_DoubleClick(this, e);
        }

 /*       private void dataGridHistory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewCell valueCell = null;
            DataGridViewImageCell displayCell = null;
            for (int row = 0; row < dataGridHistory.Rows.Count; row++)
            {
                valueCell = dataGridHistory["user_legend", row];
                displayCell = (DataGridViewImageCell)dataGridHistory["UserLegend", row];
                int n = (int)valueCell.Value;
                displayCell.Value = imgListLegends.Images[n];
            }
        }*/

        private void showDialogsAndSigns(bool show)
        {
            if (show)
            {
                //Show Dialogs And Signs
                listBoxDialogsAndSigns.Visible = true;
                lbDesignerNote.Visible = true;
                txtUserNote.Visible = true;
                gbNextStep.Top = listBoxDialogsAndSigns.Top + listBoxDialogsAndSigns.Height + 20;
                gbNextStep.Height = originalComponentsPosition.gbNextStep.Height;
                gbNextStep.Anchor = originalComponentsPosition.gbNextStep.Anchor;
                listBoxOptions.Anchor = listBoxDialogsAndSigns.Anchor;
                listBoxOptions.Height = originalComponentsPosition.listBoxOptions.Height;
                listBoxOptions.Top = 109;
                lbNextStep.Top = 89;
                lbNextStep.Anchor = originalComponentsPosition.lbNextStep.Anchor;
                gbNextStep.Text = "Next Step";
                lbNextStep.Text = "What would you like to say now?";
                lbYouMayNow.Visible = true;
            }
            else
            {
                //Hide Dialogs And Signs
                listBoxDialogsAndSigns.Visible = false;
                lbDesignerNote.Visible = true;
                txtUserNote.Visible = true;
                gbNextStep.Top = listBoxDialogsAndSigns.Top;
                gbNextStep.Height = gbNextStep.Height + listBoxDialogsAndSigns.Height;
                gbNextStep.Anchor = listBoxDialogsAndSigns.Anchor;
                listBoxOptions.Anchor = listBoxDialogsAndSigns.Anchor;
                listBoxOptions.Height = originalComponentsPosition.listBoxOptions.Height + listBoxDialogsAndSigns.Height;
                listBoxOptions.Top = 45;
                lbNextStep.Top = 17;
                lbNextStep.Anchor = lbSpeaker.Anchor;
                gbNextStep.Text = "Next Step";
                lbNextStep.Text = "What would you like to say now?";
                lbYouMayNow.Visible = true;
            }
        }


    }
}
