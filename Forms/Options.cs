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
            this.txtClearMessage.Text = Properties.Settings.Default.ClearMessage;
            this.txtClearDelay.Value = Properties.Settings.Default.ClearDelay;

            this.txtKeyNG.Text = Properties.Settings.Default.KeyNG;
            this.txtKeyNGDelay.Value = Properties.Settings.Default.KeyNGDelay;
            this.txtKeyNGDescription.Text = Properties.Settings.Default.KeyNGDescription;
        }
    }
}
