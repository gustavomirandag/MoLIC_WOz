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

namespace MoLIC_WOz_Desktop_Designer
{
    public partial class FormInteractionSimulation : Form
    {
        private int simulationId;
        private string nextSpeaker;
        private string speaker;
        private bool needToClose = false;
        private static string xmlFile;
        private XmlDocument xmlDocument;
        ComponentsPosition originalComponentsPosition;

        private class ComponentsPosition
        {
            public Label lbTheUserSaid;
            public Label lbLastTransition;
            public GroupBox gbNextStep;
            public Label lbNextStep;
            public ListBox listBoxOptions;

            public ComponentsPosition(Label lbTheUserSaidAux, Label lbLastTransitionAux, GroupBox gbNextStepAux, Label lbNextStepAux, ListBox listBoxOptionsAux)
            {
                this.lbTheUserSaid = new Label();
                this.lbTheUserSaid.Height = lbTheUserSaidAux.Height;
                this.lbTheUserSaid.Anchor = lbTheUserSaidAux.Anchor;

                this.lbLastTransition = new Label();
                this.lbLastTransition.Height = lbLastTransitionAux.Height;
                this.lbLastTransition.Anchor = lbLastTransitionAux.Anchor;

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

        public FormInteractionSimulation()
        {
            InitializeComponent();
        }

        public void setXmlFile(string xmlFileAux)
        {
            xmlFile = xmlFileAux; 
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

        private void callNextSpeaker()
        {
            DbControl.getInstance().callNextSpeaker(simulationId, nextSpeaker);
        }

        private void refresHistory(THistory tHistory)
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
                lbSpeaker.Text = "The user said:";
                lbLastTransition.Text = tTransactionUtterance.description;
                lbTopic.Text = tTransactionUtterance.source_topic;
                if (tHistory.user_note != "")
                {
                    txtUserNote.Text = tHistory.user_note;
                    txtUserNote.Visible = true;
                }
                else
                {
                    txtUserNote.Visible = false;
                }
                Image imgLegend = null;
                if (tTransactionUtterance.source.Contains("scene"))
                    imgLegend = imgListLegends.Images[1];
                if (tTransactionUtterance.source.Contains("system"))
                    imgLegend = imgListLegends.Images[5];
                if (tTransactionUtterance.source.Contains("op"))
                    imgLegend = imgListLegends.Images[3];
                /*pbLocation.Image = imgLegend;
                pbAnswer.Image = imgListLegends.Images[5];*/
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

                dataGridHistory.Rows.Add(imgListLegends.Images[tTransactionUtterance.legend], tTransactionUtterance.source_topic, tHistory.user_note, imgListLegends.Images[0], "", tHistory.designer_note, tHistory.dialogDateTime.ToString());
                if (tTransactionUtterance.isBreakdown)
                    dataGridHistory.Rows.Add(imgListLegends.Images[8], tTransactionUtterance.description, "", imgListLegends.Images[0], "", "", tHistory.dialogDateTime.ToString());
                else
                    dataGridHistory.Rows.Add(imgListLegends.Images[7], tTransactionUtterance.description, "", imgListLegends.Images[0], "", "", tHistory.dialogDateTime.ToString());
                if (tTransactionUtterance.target.Contains("cp"))
                    dataGridHistory.Rows.Add(imgListLegends.Images[4], tTransactionUtterance.target, "", imgListLegends.Images[0], "", "", tHistory.dialogDateTime.ToString());
                

                
            }
            else
            {
                tTransactionUtterance = DbControl.getInstance().getTransitionUtterance(tHistory.designer_tu_id);
                //------ Set Last Transition ------
                lbSpeaker.Text = "You said:";
                lbLastTransition.Text = tTransactionUtterance.description;
                if (tHistory.user_note != "")
                {
                    txtUserNote.Text = tHistory.user_note;
                    txtUserNote.Visible = true;
                }
                else
                {
                    txtUserNote.Visible = false;
                }
                Image imgLegend = null;
                if (tTransactionUtterance.source.Contains("scene"))
                    imgLegend = imgListLegends.Images[1];
                if (tTransactionUtterance.source.Contains("system"))
                    imgLegend = imgListLegends.Images[5];
                if (tTransactionUtterance.source.Contains("op"))
                    imgLegend = imgListLegends.Images[3];
                /*pbLocation.Image = imgLegend;
                pbAnswer.Image = imgListLegends.Images[5];*/
                //---------------------------------
                dataGridHistory.Rows.Add(imgListLegends.Images[0], "", tHistory.user_note, imgListLegends.Images[tTransactionUtterance.legend], tTransactionUtterance.source_topic, tHistory.designer_note, tHistory.dialogDateTime.ToString());
                if (tTransactionUtterance.isBreakdown)
                    dataGridHistory.Rows.Add(imgListLegends.Images[0], "", "", imgListLegends.Images[8], tTransactionUtterance.description, "", tHistory.dialogDateTime.ToString());
                else
                    dataGridHistory.Rows.Add(imgListLegends.Images[0], "", "", imgListLegends.Images[7], tTransactionUtterance.description, "", tHistory.dialogDateTime.ToString());
                if (tTransactionUtterance.target.Contains("cp"))
                    dataGridHistory.Rows.Add(imgListLegends.Images[4], tTransactionUtterance.target, "", imgListLegends.Images[0], "", "", tHistory.dialogDateTime.ToString());
            }
                
        }

/*        private void showDialogOptions(TTransitionUtterance tTransitionUtterance)
        {
            
            pbLocation.Image = imgListLegends.Images[tTransitionUtterance.legend];
            //######## SHOW DIALOG SIGNS #########
            List<TSign> tSigns = DbControl.getInstance().getDialogSigns(tTransitionUtterance.id);
            for (int count = 0; count < tSigns.Count; count++)
            {
                dgSigns.Rows.Add(tSigns[count].sign, tSigns[count].sign_value);
            }
            //####################################


            //####### SHOW DESIGNER OPTIONS ########
            XmlNodeList transitionUtterances = xmlDocument.GetElementsByTagName(tTransitionUtterance.target);
            //List Of Transition Utterances
            for (int countTu = 0; countTu < transitionUtterances.Count; countTu++)
            {
                //Add Dialogs do DIALOGO de ID 
            }
            //######################################
        }*/

        private void FormInteractionSimulation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbMoLIC_WOz_TB_HISTORY.TB_HISTORYS' table. You can move, or remove it, as needed.
            //this.tB_HISTORYSTableAdapter.Fill(this.dbMoLIC_WOz_TB_HISTORY.TB_HISTORYS, simulationId);
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
            //pbUser.Image = imgListSpeakers.Images[0];
            //pbDesigner.Image = imgListSpeakers.Images[1];
            originalComponentsPosition = new ComponentsPosition(lbSpeaker, lbLastTransition, gbNextStep, lbNextStep, listBoxOptions);
            xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlFile);
            chooseOpeningPoint();
        }

        private void chooseOpeningPoint()
        {
            listBoxOptions.Items.Clear();
            //###### Add Dialog Options To User ######
            XmlNodeList openingPointNodes = xmlDocument.GetElementsByTagName("openingPoint");
            //List Of Opening Points
            for (int countOp = 0; countOp < openingPointNodes.Count; countOp++)
            {
                List<TTransitionUtterance> listTransitionUtterances = getXmlTransitionUtterances(openingPointNodes[countOp].Attributes["id"].Value);
                for (int countTu = 0; countTu < listTransitionUtterances.Count; countTu++)
                {
                    listTransitionUtterances[countTu].simulation_id = simulationId;
                    DbControl.getInstance().addUserTransitionUtteranceOption(listTransitionUtterances[countTu], null);
                }
            }
            //########################################

            //Refresh History and do Dialog ######
            //refresHistory();

            //Wait For User Response
            callNextSpeakerAndWait();

            //Continue the Navigation
            continueNavigation();
            /*XmlNodeList openingPointNodes = xmlDocument.GetElementsByTagName("openingPoint");

            //List Of Opening Points
            for (int count = 0; count < openingPointNodes.Count; count++)
            {
                this.addDialogOption("Id - " + openingPointNodes[count].Attributes["id"].Value, openingPointNodes[count].Attributes["id"].Value);
            }
            showInteractionPosition();*/
            //################################
        }

        private void continueNavigation()
        {
            THistory tHistory = DbControl.getInstance().getLastHistory(simulationId);
            TTransitionUtterance tTransitionUtterance;

            refresHistory(tHistory);

            //Get Last Transition Utterance
            if (tHistory.user_tu_id >= 0)
                tTransitionUtterance = DbControl.getInstance().getTransitionUtterance(tHistory.user_tu_id);
            else
                tTransitionUtterance = DbControl.getInstance().getTransitionUtterance(tHistory.designer_tu_id);

            //Get TARGET options from LAST TARGET
            List<TTransitionUtterance> transitionUtterances = getXmlTransitionUtterances(tTransitionUtterance.target);

            //Check EMITTER
            if (transitionUtterances.Count <= 0)
            {
                listBoxOptions.Items.Clear();
                listBoxOptions.Enabled = false;
                gbInteractionPosition.Visible = false;
                splitContainer1.SplitterDistance = 0;
                MessageBox.Show("The user reached a closing point. The interaction has been completed.");
                callNextSpeaker();
                return;
            }
            if (transitionUtterances[0].emitter == "user")
            {
                int queryResult = 0;
                //###### Add Dialog Options To User ######
                for (int countTu = 0; countTu < transitionUtterances.Count; countTu++)
                {
                    transitionUtterances[countTu].simulation_id = simulationId;
                    List<TDialog> tDialogs = null;
                    if (transitionUtterances[countTu].legend == 1)
                         tDialogs = getDialogsFromXml(transitionUtterances[countTu].source);
                    queryResult = DbControl.getInstance().addUserTransitionUtteranceOption(transitionUtterances[countTu], tDialogs);
                }
                //########################################

                //###### Add Ubiquitous Access Options To User ######
                XmlNodeList ubiquitousAccessNodes = xmlDocument.GetElementsByTagName("ubiquitousAccess");
                //List Of Opening Points
                for (int countOp = 0; countOp < ubiquitousAccessNodes.Count; countOp++)
                {
                    List<TTransitionUtterance> listTransitionUtterances = getXmlTransitionUtterances(ubiquitousAccessNodes[countOp].Attributes["id"].Value);
                    for (int countTu = 0; countTu < listTransitionUtterances.Count; countTu++)
                    {
                        listTransitionUtterances[countTu].simulation_id = simulationId;
                        //####### Verify PRECOND #######
                        string precond = getAttributeFromXml("transitionUtterance", listTransitionUtterances[countTu].xml_id, "precond");
                        if (precond != "")
                        {
                            if (tTransitionUtterance.target == precond)
                                continue; //User is in the precond scene
                        }
                        //##############################
                        DbControl.getInstance().addUserTransitionUtteranceOption(listTransitionUtterances[countTu], null);
                    }
                }
                //###################################################

                if (!tTransitionUtterance.isBreakdown)
                    showOnlyNoteOnNextStep(true);
            }
            else
            {
                //Designer choose
                listBoxOptions.Items.Clear();
                //###### Add Transaction Utterance Options ######
                //List Of Opening Points
                for (int count = 0; count < transitionUtterances.Count; count++)
                {
                    listBoxOptions.Items.Add(transitionUtterances[count]);
                }
                if (transitionUtterances.Count > 0)
                {
                    listBoxOptions.SelectedIndex = 0;
                    listBoxOptions.Focus();
                }
                //################################

                showOnlyNoteOnNextStep(false);
            }
        }

        private List<TDialog> getDialogsFromXml(string sceneId)
        {
            List<TDialog> tDialogs = null;
            XPathNavigator nav = xmlDocument.CreateNavigator();
            // Compile a standard XPath expression
            XPathExpression expr;
            expr = nav.Compile("//*[@id='" + sceneId + "']");
            XPathNodeIterator iterator = nav.Select(expr);
            if (iterator.MoveNext())
            {
                XPathNavigator navScene = iterator.Current.Clone();
                if (navScene.InnerXml == "")
                    return null;

                XmlDocument xmlDocumentOfScene = new XmlDocument();
                xmlDocumentOfScene.InnerXml = navScene.InnerXml;
                XmlNodeList dialogNodes = xmlDocumentOfScene.GetElementsByTagName("dialog");
                if (dialogNodes.Count > 0)
                {
                    tDialogs = new List<TDialog>();
                    for (int countDialogs = 0; countDialogs < dialogNodes.Count; countDialogs++)
                    {
                        string dialogXmlId = dialogNodes[countDialogs].Attributes["id"].Value;
                        string dialogDescription = dialogNodes[countDialogs].Attributes["description"].Value;
                        TDialog tDialog = new TDialog(dialogXmlId, dialogDescription);

                        //##### Get signs of dialog #####
                        XmlDocument xmlDocumentOfDialog = new XmlDocument();
                        xmlDocumentOfDialog.InnerXml = "<dialog>" + dialogNodes[countDialogs].InnerXml + "</dialog>";
                        XmlNodeList signNodes = xmlDocumentOfDialog.GetElementsByTagName("situatedSignToken");
                        if (signNodes.Count > 0)
                        {
                            tDialog.signs = new List<TSign>();
                            for (int countSigns = 0; countSigns < signNodes.Count; countSigns++)
                            {
                                //---- Get sign ----
                                string signXmlId = signNodes[countSigns].InnerText;
                                string signName = getAttributeFromXml("situatedSignToken", signXmlId, "name");
                                TSign tSign = new TSign(signName);
                                tDialog.signs.Add(tSign);
                                //------------------
                            }
                        }
                        else
                        {
                            tDialog.signs = null;
                        }
                        //###############################
                        tDialogs.Add(tDialog);
                    }
                }
            }
            return tDialogs;
        }

        /// <summary>
        /// Get XML TransitionUtterances with a specific SOURCE
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private List<TTransitionUtterance> getXmlTransitionUtterances(string source)
        {
            TTransitionUtterance transitionUtteranceAux = null;
            List<TTransitionUtterance> listTransitionUtterances = new List<TTransitionUtterance>();
            listTransitionUtterances.Clear();
            //####### Get TransitionUtterance with SOURCE = source #######
            XmlNodeList transitionUtteranceNodes = xmlDocument.GetElementsByTagName("transitionUtterance");
            for (int count = 0; count < transitionUtteranceNodes.Count; count++)
            {
                //TransitionUtterance with SOURCE = source => AddTransitionUtterance
                if (transitionUtteranceNodes[count].Attributes["source"].Value == source)
                {
                    transitionUtteranceAux = new TTransitionUtterance();
                    transitionUtteranceAux.simulation_id = simulationId;
                    transitionUtteranceAux.xml_id = transitionUtteranceNodes[count].Attributes["id"].Value;
                    transitionUtteranceAux.source = source;
                    transitionUtteranceAux.target = transitionUtteranceNodes[count].Attributes["target"].Value;
                    transitionUtteranceAux.isBreakdown = Convert.ToBoolean(transitionUtteranceNodes[count].Attributes["isBreakdown"].Value);
                    transitionUtteranceAux.emitter = transitionUtteranceNodes[count].Attributes["emitter"].Value;
                    transitionUtteranceAux.description = transitionUtteranceNodes[count].Attributes["description"].Value;
                    //------ Set Transition Legend and Topic/Title ------
                    int legendId = 0;
                    if (transitionUtteranceAux.source.Contains("scene"))
                    {
                        legendId = 1;
                        transitionUtteranceAux.source_topic = getAttributeFromXml("scene", transitionUtteranceAux.source, "topic");
                    }
                    if (transitionUtteranceAux.source.Contains("system"))
                    {
                        legendId = 5;
                        transitionUtteranceAux.source_topic = transitionUtteranceAux.source;
                    }
                    if (transitionUtteranceAux.source.Contains("op"))
                    {
                        legendId = 3;
                        transitionUtteranceAux.source_topic = "Choose the first dialog";
                    }
                    //---------------------------------
                    transitionUtteranceAux.legend = legendId;

                    listTransitionUtterances.Add(transitionUtteranceAux);
                }
            }
            return listTransitionUtterances;
            //##############################################################
        }

/*        void showSignsAndImgLegend(string interactionModel)
        {
            string targetTagName;
            Image imgLegend = imgListLegends.Images[0];
            listBoxLocation.Items.Clear();
            //###### Set Img Legend ######
            XPathNavigator nav = xmlDocument.CreateNavigator();
            // Compile a standard XPath expression
            XPathExpression expr;
            expr = nav.Compile("//*[@id='" + interactionModel + "']");
            XPathNodeIterator iterator = nav.Select(expr);
            if (iterator.MoveNext())
            {
                XPathNavigator nav2 = iterator.Current.Clone();
                switch (nav2.Name)
                {
                    case "scene":
                        targetTagName = "scene";
                        imgLegend = imgListLegends.Images[1];
                        break;
                    case "closingPoint":
                        targetTagName = "closingPoint";
                        imgLegend = imgListLegends.Images[4];
                        break;
                    case "systemProcess":
                        targetTagName = "systemProcess";
                        imgLegend = imgListLegends.Images[5];
                        break;
                    case "ubiquitousAccess":
                        targetTagName = "ubiquitousAccess";
                        imgLegend = imgListLegends.Images[6];
                        break;
                }

                if (((this.transitionUtteranceChoosed.emitter == "user") && (interactionModel != "systemProcess")) || (interactionModel == "scene"))
                    dataGridHistory.Rows.Add(imgLegend, "ID - " + interactionModel, imgListLegends.Images[0], "");
                else
                    dataGridHistory.Rows.Add(imgListLegends.Images[0], "", imgLegend, "ID - " + interactionModel);

                //if (nav2.InnerXml == "")
                //    return;
                listBoxLocation.Items.Clear();
                dgSigns.Rows.Clear();
                if (nav2.InnerXml == "")
                    return;
                XmlDocument xmlDocumentLocal = new XmlDocument();
                xmlDocumentLocal.InnerXml = nav2.InnerXml;
                XmlNodeList situatedSignTokenNodes = xmlDocumentLocal.GetElementsByTagName("situatedSignToken");
                for (int countSigns = 0; countSigns < situatedSignTokenNodes.Count; countSigns++)
                {
                    //Get sign
                    string sign = getAttributeFromXml("situatedSignToken", situatedSignTokenNodes[countSigns].InnerXml, "name");
                    listBoxLocation.Items.Add("Sign: " + sign);
                    dgSigns.Rows.Add(sign, "");
                    //#######################
                }
                if (situatedSignTokenNodes.Count <= 0)
                {
                    listBoxLocation.Items.Add("No signs found!");
                    dgSigns.Enabled = false;
                }
            }
        }*/

        void showInteractionPosition()
        {
            try
            {
                TTransitionUtterance transitionUtterance = (TTransitionUtterance)listBoxOptions.Items[0];
                Image imgLegend = imgListLegends.Images[0];

                //####### Set Location ########
                if (transitionUtterance.source.Contains("scene"))
                    imgLegend = imgListLegends.Images[1];
                if (transitionUtterance.source.Contains("system"))
                    imgLegend = imgListLegends.Images[5];
                if (transitionUtterance.source.Contains("op"))
                    imgLegend = imgListLegends.Images[3];
                //pbLocation.Image = imgLegend;
                //#############################
            }
            catch
            {
                //Set Location
                //pbLocation.Image = imgListLegends.Images[3];
                lblSpeaker.Text = "Please, choose a Opening Point to START.";
            }
        }

        private void dataGridHistory_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int index = dataGridHistory.Rows.Count - 1;

            //First is to scroll down the DataGridView so the row is visible in the screen:
            dataGridHistory.FirstDisplayedScrollingRowIndex = index;
            dataGridHistory.Refresh();

            //Then you must select the row so that binding sources update their Current item:
            //dataGridHistory.CurrentCell = dataGridHistory.Rows[index].Cells[0];  //Disabled to enable SELECT something and don't lose the selection!

            //Finally, you can visually select the row with C#:
            if (index > 0)
                dataGridHistory.Rows[index-1].Selected = false;
            dataGridHistory.Rows[index].Selected = true;
        }

        private void dataGridHistory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            /*TTransitionUtterance tTransitionUtterance;

            for (int row = 0; row < dataGridHistory.Rows.Count; row++)
            {
                //######### SHOW DIALOG LEGEND ##########
                if (Convert.ToInt32(dataGridHistory["Column_UserDialogId", row].Value) >= 0)
                {
                    tTransitionUtterance = DbControl.getInstance().getTransitionUtterance(Convert.ToInt32(dataGridHistory["Column_UserDialogId", row].Value));
                    ((DataGridViewImageCell)dataGridHistory["Column_UserLegend", row]).Value = imgListLegends.Images[tTransitionUtterance.legend];
                    ((DataGridViewImageCell)dataGridHistory["Column_DesignerLegend", row]).Value = imgListLegends.Images[0];
                    dataGridHistory["Column_UserDialog", row].Value = tTransitionUtterance.description;
                }
                else
                {
                    tTransitionUtterance = DbControl.getInstance().getTransitionUtterance(Convert.ToInt32(dataGridHistory["Column_DesignerDialogId", row].Value));
                    ((DataGridViewImageCell)dataGridHistory["Column_DesignerLegend", row]).Value = imgListLegends.Images[tTransitionUtterance.legend];
                    ((DataGridViewImageCell)dataGridHistory["Column_UserLegend", row]).Value = imgListLegends.Images[0];
                    dataGridHistory["Column_DesignerDialog", row].Value = tTransitionUtterance.description;
                }
                //######################################
            }*/
        }

        private string getAttributeFromXml(string elementTagName, string elementId, string attribute)
        {
            XmlNodeList elementNodes = xmlDocument.GetElementsByTagName(elementTagName);
            for (int count = 0; count < elementNodes.Count; count++)
            {
                if (elementNodes[count].Attributes["id"].Value == elementId)
                    return elementNodes[count].Attributes[attribute].Value;
            }
            return null;
        }

        private void listBoxOptions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                proceedConversation();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            proceedConversation();
        }

        private void listBoxOptions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            proceedConversation();
        }

        private void proceedConversation()
        {
            if (listBoxOptions.Items.Count <=0)
            {
                //##### USER TURN #####
                THistory tHistory = DbControl.getInstance().getLastHistory(simulationId);
                tHistory.designer_note = txtDesignerNote.Text;
                DbControl.getInstance().setHistory(tHistory);
                dataGridHistory.Rows[dataGridHistory.Rows.Count - 2].Cells[5].Value = tHistory.designer_note;

                //Wait For User Response
                callNextSpeakerAndWait();

                txtDesignerNote.Text = "";
                continueNavigation();
                //#####################
            }
            else
            {
                //##### DESIGNER TURN #####
                if (listBoxOptions.SelectedIndex < 0)
                    return;
                TTransitionUtterance tTransitionUtterance = (TTransitionUtterance)listBoxOptions.SelectedItem;
                int transitionId = DbControl.getInstance().addTransitionUtterance(tTransitionUtterance, null);
                THistory tHistory = new THistory(tTransitionUtterance.simulation_id, -1, "", transitionId, txtDesignerNote.Text, DateTime.Now);

                DbControl.getInstance().addHistory(tHistory);

                txtDesignerNote.Text = "";
                //Continue...
                continueNavigation();

                //Clear "listBoxOptions" with the Designer's selected Option
                listBoxOptions.Items.Clear();

                //Wait For User Response
                callNextSpeakerAndWait();
                //Continue...
                continueNavigation();
                //#########################
            }
        }

        private void showDialogsAndSigns(bool show)
        {
 /*         if (show)
            {
                //Show Dialogs And Signs
                listBoxDialogsAndSigns.Visible = true;
                lbSpeaker.Top = listBoxDialogsAndSigns.Top + listBoxDialogsAndSigns.Height + 5;
                lbSpeaker.Anchor = originalComponentsPosition.lbTheUserSaid.Anchor;
                lbLastTransition.Top = lbSpeaker.Top + 24;
                lbLastTransition.Anchor = originalComponentsPosition.lbLastTransition.Anchor;
                gbNextStep.Top = lbLastTransition.Top + 24;
                gbNextStep.Height = originalComponentsPosition.gbNextStep.Height;
                gbNextStep.Anchor = originalComponentsPosition.gbNextStep.Anchor;
                listBoxOptions.Anchor = listBoxDialogsAndSigns.Anchor;
                listBoxOptions.Height = originalComponentsPosition.listBoxOptions.Height;
                listBoxOptions.Top = 118;
                lbNextStep.Top = 98;
                lbNextStep.Anchor = originalComponentsPosition.lbNextStep.Anchor;
            }
            else
            {
                //Hide Dialogs And Signs
                listBoxDialogsAndSigns.Visible = false;
                lbSpeaker.Top = listBoxDialogsAndSigns.Top;
                lbSpeaker.Anchor = lblSpeaker.Anchor;
                lbLastTransition.Top = lbSpeaker.Top + 24;
                lbLastTransition.Anchor = lblSpeaker.Anchor;
                gbNextStep.Top = lbLastTransition.Top + 24;
                gbNextStep.Height = gbNextStep.Height + listBoxDialogsAndSigns.Height;
                gbNextStep.Anchor = listBoxDialogsAndSigns.Anchor;
                listBoxOptions.Anchor = listBoxDialogsAndSigns.Anchor;
                listBoxOptions.Height = listBoxOptions.Height + listBoxDialogsAndSigns.Height;
                listBoxOptions.Top = 53;
                lbNextStep.Top = 17;
                lbNextStep.Anchor = lblSpeaker.Anchor;
            }*/
        }

        private void showOnlyNoteOnNextStep(bool show)
        {
            if (show)
            {
                lbNextStep.Visible = false;
                listBoxOptions.Visible = false;
                txtDesignerNote.Height = 59 + listBoxOptions.Height + lbNextStep.Height;
            }
            else
            {
                lbNextStep.Visible = true;
                listBoxOptions.Visible = true;
                txtDesignerNote.Height = 59;
            }
        }
    }
}
