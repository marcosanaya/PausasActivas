using PausasActivas.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PausasActivas
{
    public partial class frmMain : Form
    {
        private readonly PausasActivasApp app = PausasActivasApp.GetInstance();
        public frmMain()
        {
            InitializeComponent();
            trackBarDelay.Value = app.GetValueinByte("FirstPauseInMinutes");
            txtDelayInitMinutes.Text = trackBarDelay.Value.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (ValidateToStart())
            {
                StartWorkDay();
            }
        }

        private void StartWorkDay()
        {
            throw new NotImplementedException();
        }

        private bool ValidateToStart()
        {
            bool result = false;


            return result;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
