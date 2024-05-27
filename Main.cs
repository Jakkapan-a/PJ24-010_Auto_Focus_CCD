using DirectShowLib;
using PJ24_010_Auto_Focus_CCD.Forms;
using PJ24_010_Auto_Focus_CCD.SQLite;
using System.Diagnostics;
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
            InitializeSerialPort();
            InitializeProcess();
        }
        public string[] baudList = { "9600", "19200", "38400", "57600", "115200" };

        private void Main_Load(object sender, EventArgs e)
        {
            this.btnReload.PerformClick();
            timer.Start();

            Task.Run(() =>
            {
                OnnxModel.CreateTable();
                Product.CreateTable();
            });
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine($"Format ->> {((double)10110/1000):f2}");
            RefreshVideoDevices();
            RefreshComboBoxWithList(comBaudRate, this.baudList, false);
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
        private bool is_connect = false;
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                is_connect = !is_connect;
                btnConnect.Enabled = false;
                if (is_connect)
                {
                    // Connect camera
                    if (capture.IsRunning)
                    {
                        btnConnect.Text = "Stopping...";
                        await capture.StopAsync();

                        this.pictureBox.Image?.Dispose();
                        this.pictureBox.Image = null;
                        DisconnectSerial();
                    }

                    btnConnect.Text = "Connecting...";
                    this.pictureBox.Image?.Dispose();
                    this.pictureBox.Image = null;
                    this.pictureBox.Image = Properties.Resources.loading_1;
                    int deviceSelect = comDevice.SelectedIndex;
                    if (deviceSelect == -1)
                    {
                        btnConnect.Text = "Connect";
                        throw new Exception("Please select a video device.");
                    }
                    // Connect camera
                    await capture.StartAsync(deviceSelect);

                    // Connect serial port
                    SerialPortConnect(comPort.SelectedItem?.ToString(), int.Parse(comBaudRate.SelectedItem?.ToString()));

                }
                else
                {
                    // Disconnect
                    if (capture.IsRunning)
                    {
                        btnConnect.Text = "Stopping...";
                        await capture.StopAsync();
                        this.pictureBox.Image?.Dispose();
                        this.pictureBox.Image = null;
                    }

                    DisconnectSerial();
                }
            }
            catch
            {
                is_connect = false;
                DisconnectSerial();
                if (capture.IsRunning)
                {
                    await capture.StopAsync();
                    this.pictureBox.Image?.Dispose();
                    this.pictureBox.Image = null;
                }
            }
            finally
            {
                btnConnect.Enabled = true;
                if (capture.IsRunning && serialPort.IsOpen)
                {
                    btnConnect.Text = "Disconnect";
                    is_connect = true;
                }
                else
                {
                    btnConnect.Text = "Connect";
                    is_connect = false;
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            capture?.StopAsync();
        }


        private void txtEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtEmp.Text))
                {
                    MessageBox.Show("Please enter employee.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Code ....
                this.ActiveControl = txtQr;
                this.txtQr.Focus();
            }
        }

        private void txtQr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtQr.Text) || txtQr.Text.Length < 7)
                {
                    MessageBox.Show("Please enter QR code.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Code ....
                ProcessValiidateData();
            }
        }
        private OnnxModels onnxModels;
        private void oNNXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            onnxModels?.Dispose();

            onnxModels = new OnnxModels();

            onnxModels.ShowDialog();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lbDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private Products products;
        private void modelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            products?.Dispose();

            products = new Products();

            products.ShowDialog();
        }

        private Options options;
        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            options?.Dispose();
            options = new Options();
            options.ShowDialog();
        }

        private async void clearMESToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clearMESToolStripMenuItem1.Enabled = false;
            SendDataBuffer($"KBD:{Properties.Settings.Default.ClearMessage}");
            await Task.Delay(Properties.Settings.Default.ClearDelay);
            SendDataBuffer($"KBD:{txtEmp.Text}");
            clearMESToolStripMenuItem1.Enabled = true;
        }
    }
}