using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PJ24_010_Auto_Focus_CCD.Forms
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            this.IsAllowSendData.Checked = Properties.Settings.Default.IsAllowSendData;

            this.txtClearMessage.Text = Properties.Settings.Default.ClearMessage;
            this.txtClearDelay.Value = Properties.Settings.Default.ClearDelay;

            this.txtKeyNG.Text = Properties.Settings.Default.KeyNG;
            this.txtKeyNGDelay.Value = Properties.Settings.Default.KeyNGDelay;
            this.txtKeyNGDescription.Text = Properties.Settings.Default.KeyNGDescription;

            this.txtScore.Value = (decimal)Properties.Settings.Default.Score;
            this.txtCountTest.Value = Properties.Settings.Default.CountDownStart / 10;


            this.cbByPass.Checked = Properties.Settings.Default.IsByPass;
        }

        private void txtScore_ValueChanged(object sender, EventArgs e)
        {
            // Save the value to the settings
            Properties.Settings.Default.Score = (float)this.txtScore.Value;
            Properties.Settings.Default.Save();
        }

        private void txtCountTest_ValueChanged(object sender, EventArgs e)
        {
            // Save the value to the settings
            Properties.Settings.Default.CountDownStart = (int)this.txtCountTest.Value * 10;
            Properties.Settings.Default.Save();
        }

        private void IsAllowSendData_CheckedChanged(object sender, EventArgs e)
        {
            // Save the value to the settings
            Properties.Settings.Default.IsAllowSendData = this.IsAllowSendData.Checked;
            Properties.Settings.Default.Save();
        }

        private void txtClearMessage_TextChanged(object sender, EventArgs e)
        {
            // Save the value to the settings
            Properties.Settings.Default.ClearMessage = this.txtClearMessage.Text;
            Properties.Settings.Default.Save();
        }

        private void txtClearDelay_ValueChanged(object sender, EventArgs e)
        {
            // Save the value to the settings
            Properties.Settings.Default.ClearDelay = (int)this.txtClearDelay.Value;
            Properties.Settings.Default.Save();
        }

        private void txtKeyNG_TextChanged(object sender, EventArgs e)
        {
            // Save the value to the settings
            Properties.Settings.Default.KeyNG = this.txtKeyNG.Text;
            Properties.Settings.Default.Save();
        }

        private void txtKeyNGDelay_ValueChanged(object sender, EventArgs e)
        {
            // Save the value to the settings
            Properties.Settings.Default.KeyNGDelay = (int)this.txtKeyNGDelay.Value;
            Properties.Settings.Default.Save();
        }

        private void txtKeyNGDescription_TextChanged(object sender, EventArgs e)
        {
            // Save the value to the settings
            Properties.Settings.Default.KeyNGDescription = this.txtKeyNGDescription.Text;
            Properties.Settings.Default.Save();
        }

        private void cbByPass_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsByPass = this.cbByPass.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
