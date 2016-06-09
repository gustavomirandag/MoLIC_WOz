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
    public partial class FormSelectXmlFile : Form
    {
        int simulationId;
        string speaker = "designer";
        string nextSpeaker = "user";

        public FormSelectXmlFile()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult xmlFileSelected = openXmlFileDialog.ShowDialog();
            if (xmlFileSelected == DialogResult.OK)
            {
                //###### Check if the XML file is a MoLIX file ######
                try
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(openXmlFileDialog.FileName);
                    XmlNodeList openingPointNodes = xmlDocument.GetElementsByTagName("openingPoint");
                    if (openingPointNodes.Count <= 0)
                    {
                        MessageBox.Show("Invalid XML file! Please, choose a valid MoLIX XML file.");
                        btnBrowseXml.Focus();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid XML file! Please, choose a valid MoLIX XML file.");
                    btnBrowseXml.Focus();
                    return;
                }
                //###################################################
                txtMoLIXFile.Text = openXmlFileDialog.FileName;

                //Change Step images
                pbStep1.Image = imgListSteps.Images[0];
                pbStep2.Image = imgListSteps.Images[4];
                pbStep3.Image = imgListSteps.Images[2];

                //Enable Next Step
                gbDatabase.Enabled = true;
                txtDatabase.Focus();
            }
        }

        private void FormSelectXmlFile_Load(object sender, EventArgs e)
        {
            pbStep1.Image = imgListSteps.Images[3];
            pbStep2.Image = imgListSteps.Images[1];
            pbStep3.Image = imgListSteps.Images[2];
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStart.Focus();
        }

        private void btnBrowseDatabase_Click(object sender, EventArgs e)
        {
            DialogResult databaseFileSelected = openDatabaseFileDialog.ShowDialog();
            if (databaseFileSelected == DialogResult.OK)
            {
                //Set database path
                if (DbControl.setDataBasePath(openDatabaseFileDialog.FileName))
                {
                    txtDatabase.Text = openDatabaseFileDialog.FileName;

                    //DbControl.getInstance().openConnection();//Now, the connection will be closed only when closed

                    //Get usersId with open simulation
                    List<TSimulation> tSimulations = DbControl.getInstance().getOpenSimulations();

                    if (tSimulations.Count <= 0)
                    {
                        MessageBox.Show("Could not find any open simulation in this datafile. The application will continue waiting for a connection.");
                        //Get usersId with open simulation
                        while (tSimulations.Count <= 0)
                        {
                            Application.DoEvents();
                            tSimulations = DbControl.getInstance().getOpenSimulations();
                        }
                    }

                    //Open Simulation Found
                    listBoxUsers.Items.Clear();
                    for (int cont = 0; cont < tSimulations.Count; cont++)
                        listBoxUsers.Items.Add(tSimulations[cont]);
                    listBoxUsers.SelectedIndex = 0;

                    //Change Step images
                    pbStep1.Image = imgListSteps.Images[0];
                    pbStep2.Image = imgListSteps.Images[1];
                    pbStep3.Image = imgListSteps.Images[5];

                    //Enable Next Step
                    gbUserId.Enabled = true;
                    txtDesignerId.Focus();
                }
                else
                {
                    MessageBox.Show("Invalid database! Please, choose a valid database file.");
                    btnBrowseDatabase.Focus();
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            TSimulation tSimulation = (TSimulation) listBoxUsers.SelectedItem;
            DbControl.getInstance().startSimulation(tSimulation, txtDesignerId.Text);
            simulationId = tSimulation.id;

            FormInteractionSimulation formInteractionSimulation = new FormInteractionSimulation();
            formInteractionSimulation.setXmlFile(txtMoLIXFile.Text);
            formInteractionSimulation.setSimulationId(simulationId);
            formInteractionSimulation.setSpeaker(speaker);
            formInteractionSimulation.setNextSpeaker(nextSpeaker);
            formInteractionSimulation.Show();
            this.Hide();
        }

        private void FormSelectXmlFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DbControl.getInstance().closeConnection();
        }
    }
}
