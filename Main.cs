using DirectShowLib;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PJ24_010_Auto_Focus_CCD
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            InitializeTCapture();
        }
        public string[] baudList = { "9600", "19200", "38400", "57600", "115200" };

        private void Main_Load(object sender, EventArgs e)
        {
            this.btnReload.PerformClick();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            RefreshVideoDevices();
            RefreshComboBoxWithList(comBaudRate, this.baudList, true);
            RefreshComboBoxWithList(comPort, System.IO.Ports.SerialPort.GetPortNames(), true);
        }

        private void RefreshVideoDevices()
        {
            var videoDevices = DirectShowLib.DsDevice.GetDevicesOfCat(DirectShowLib.FilterCategory.VideoInputDevice).Select(device => device.Name).ToList();
            RefreshComboBoxWithList(comDevice, videoDevices, true);
        }

        private void RefreshComboBoxWithList(System.Windows.Forms.ComboBox comboBox, IList<string> items, bool selectLast = false)
        {
            int oldSelectedIndex = comboBox.SelectedIndex;
            comboBox.Items.Clear();
            comboBox.Items.AddRange(items.ToArray());

            if (comboBox.Items.Count <= 0) return;

            if (oldSelectedIndex > 0 && oldSelectedIndex < comboBox.Items.Count)
            {
                comboBox.SelectedIndex = oldSelectedIndex;
            }
            else
            {
                comboBox.SelectedIndex = selectLast ? comboBox.Items.Count - 1 : 0;
            }
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            if(capture.IsRunning)
            {
                btnConnect.Text = "Stopping...";
                await capture.StopAsync();

                this.pictureBox.Image?.Dispose();
                this.pictureBox.Image = null;

                btnConnect.Text = "Connect";
                btnConnect.Enabled = true;
                return;
            }

            btnConnect.Text = "Connecting...";
            this.pictureBox.Image?.Dispose();
            this.pictureBox.Image = null;
            this.pictureBox.Image = Properties.Resources.loading_1;

             await Task.Delay(1000);

            int deviceSelect = comDevice.SelectedIndex;
            if (deviceSelect == -1) {
                MessageBox.Show("Please select a video device.");
                btnConnect.Text = "Connect";
                return;
            }
            await capture.StartAsync(deviceSelect);
            
            // Connect serial port

            btnConnect.Text = "Disconnect";
            btnConnect.Enabled = true;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            capture?.StopAsync();
        }
    }
}
