using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using MoLIC_WOz_Core.Control;
using MoLIC_WOz_Core.Model;

namespace MoLIC_WOz_Desktop_User
{
    public partial class FormWaitConnection : Form
    {

        int simulationId;
        string speaker = "user";
        string nextSpeaker = "designer";

        public FormWaitConnection()
        {
            InitializeComponent();
        }

        private void waitToBeNextSpeaker()
        {
            while (!DbControl.getInstance().checkNextSpeaker(simulationId, speaker))
                Application.DoEvents();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DbControl.getInstance().cancelSimulation(simulationId);
            Application.Exit();
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
                    btnWait.Enabled = true;
                    btnWait.Focus();
                }
                else
                {
                    MessageBox.Show("Invalid database! Please, choose a valid database file.");
                    btnBrowseDatabase.Focus();
                }
            }
        }

        private void btnWait_Click(object sender, EventArgs e)
        {
            if (txtDatabase.Text == "")
            {
                MessageBox.Show("Please, choose a database file before start the simulation.");
                btnBrowseDatabase.Focus();
                return;
            }

            //Open connection
            //DbControl.getInstance().openConnection();//Now, the connection will be closed only when closed

            //Create Simulation
            simulationId = DbControl.getInstance().createSimulation(txtUserId.Text);

            //Wait for connection
            gbDatafile.Visible = false;
            btnWait.Visible = false;
            gbWait.Visible = true;
            btnCancel.Visible = true;

            waitToBeNextSpeaker();

            //Open FormInteractionSimulation
            FormInteractionSimulation formInteractionSimulation = new FormInteractionSimulation();
            formInteractionSimulation.setSimulationId(simulationId);
            formInteractionSimulation.setSpeaker(speaker);
            formInteractionSimulation.setNextSpeaker(nextSpeaker);
            formInteractionSimulation.Show();
            this.Hide();
        }

        private void FormWaitConnection_Shown(object sender, EventArgs e)
        {
            txtUserId.Focus();
        }

        private void FormWaitConnection_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DbControl.getInstance().closeConnection();
        }
    }
}

