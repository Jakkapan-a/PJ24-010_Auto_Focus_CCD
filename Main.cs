using DirectShowLib;
using PJ24_010_Auto_Focus_CCD.Forms;
using PJ24_010_Auto_Focus_CCD.Helpers;
using PJ24_010_Auto_Focus_CCD.SQLite;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static PJ24_010_Auto_Focus_CCD.Helpers.Notification;

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

        private async void Main_Load(object sender, EventArgs e)
        {
            this.btnReload.PerformClick();
            timer.Tick += TimerOnSecond_Tick;
            timer.Start();

            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Value = 0;

            await Task.Run(() =>
            {
                OnnxModel.CreateTable();
                Product.CreateTable();
                History.CreateTable();

                // Delete old files
                string[] files = Directory.GetFiles(Properties.Resources.path_models, "*.onnx");
                int i = 0;
                foreach (string file in files)
                {
                    FileInfo info = new FileInfo(file);
                    string fileName = Path.GetFileName(file);
                    if (!OnnxModel.IsPathModelExist(fileName))
                    {
                        // Move file to Recycle Bin
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(file, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                    }
                    i++;
                    // Update progress bar
                    SetProcessBar(i * 100 / files.Length);

                    Thread.Sleep(100);
                }

                files = Directory.GetFiles(Properties.Resources.path_models, "*.txt");
                i = 0;
                foreach (string file in files)
                {
                    FileInfo info = new FileInfo(file);
                    string fileName = Path.GetFileName(file);
                    if (!OnnxModel.IsPathLabelExist(fileName))
                    {
                        // Move file to Recycle Bin
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(file, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                    }
                    i++;
                    // Update progress bar
                    SetProcessBar(i * 100 / files.Length);

                    Thread.Sleep(100);
                }

                files = Directory.GetFiles(Properties.Resources.path_models, "*.yaml");
                i = 0;
                foreach (string file in files)
                {
                    FileInfo info = new FileInfo(file);
                    string fileName = Path.GetFileName(file);
                    if (!OnnxModel.IsPathTemplateExist(fileName))
                    {
                        // Move file to Recycle Bin
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(file, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                    }
                    i++;
                    // Update progress bar
                    SetProcessBar(i * 100 / files.Length);

                    Thread.Sleep(100);
                }
                
            });
            
            toolStripProgressBar1.Visible = false;
            toolStripProgressBar1.Value = 0;
        }
        private void SetProcessBar(int value)
        {
            // Check invoke required
            if (InvokeRequired)
            {
                Invoke(new Action(() => { SetProcessBar(value); }));
                return;
            }
            toolStripProgressBar1.Value = value;
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            // Debug.WriteLine($"Format ->> {((double)10110/1000):f2}");
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
                    lbTitle.Text = "Connecting...";
                    lbTitle.ForeColor = Color.Black;
                    lbTitle.BackColor = Color.Yellow;
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
                    if (!SerialPortConnect(comPort.SelectedItem?.ToString(), int.Parse(comBaudRate.SelectedItem?.ToString())))
                    {
                        throw new Exception("Serial port not connected.");
                    }

                }
                else
                {
                    // Disconnect
                    lbTitle.Text = "Disconnecting...";
                    lbTitle.ForeColor = Color.Black;
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
            catch (Exception ex)
            {
                is_connect = false;
                DisconnectSerial();
                if (capture.IsRunning)
                {
                    await capture.StopAsync();
                    this.pictureBox.Image?.Dispose();
                    this.pictureBox.Image = null;
                }
                lbTitle.Text = "Error : " + ex.Message;
                lbTitle.ForeColor = Color.Black;
                lbTitle.BackColor = Color.Red;
            }
            finally
            {
                btnConnect.Enabled = true;
                if (capture.IsRunning && serialPort.IsOpen)
                {
                    btnConnect.Text = "Disconnect";
                    is_connect = true;
                    lbTitle.Text = "Ready";
                    lbTitle.ForeColor = Color.Black;
                    lbTitle.BackColor = Color.Yellow;
                }
                else
                {
                    btnConnect.Text = "Connect";
                    is_connect = false;
                    await Task.Delay(1500);
                    lbTitle.Text = "Disconnected";
                    lbTitle.ForeColor = Color.Black;
                    lbTitle.BackColor = Color.Yellow;
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
                ProcessValidatedData();
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

        private Capture _Capture;
        private void captureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Capture?.Dispose();
            _Capture = new Capture();
            _Capture.btnCapture.Click += BtnCapture_Click;
            _Capture.FormClosing += _Capture_FormClosing;
            _Capture.Show();
        }

        private void _Capture_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _Capture.btnCapture.Click -= BtnCapture_Click;
            _Capture.FormClosing -= _Capture_FormClosing;
        }

        private bool IsCaptureImage = false;
        private async void BtnCapture_Click(object? sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Enabled = false;
            if (capture.IsOpened)
            {
                Debug.WriteLine("Open Capture");
                // Save Image
                string name = "IMG_" + Guid.NewGuid();
                name = name.Replace("-", "_");

                await Task.Run(() =>
                {
                    IsCaptureImage = false;
                    int index = 0;
                    while (!IsCaptureImage)
                    {
                        index++;
                        Thread.Sleep(100);
                        if (index > 3)
                        {
                            break;
                        }
                    }

                    if (imageCapture != null)
                    {
                        string date = DateTime.Now.ToString("yyyyMMdd");
                        // Save image 
                        string path = Path.Combine(Properties.Resources.path_image, "capture", date);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        string file = Path.Combine(path, $"{name}.jpg");
                        imageCapture.Save(file, ImageFormat.Jpeg);
                        toolStripStatusLabel1.Text = $"FILE : {name}";
                    }
                });
            }
            button.Enabled = true;
        }

        private void btnJdmNG_Click(object sender, EventArgs e)
        {
            this.history.re_judgment = "NG";

            Notification notification = new Notification();
            notification.Type = NotificationType.Success;
            notification.ShowNotification("Change to NG", 4000);
        }

        private void btnJdmPASS_Click(object sender, EventArgs e)
        {
            this.history.re_judgment = "PASS";

            Notification notification = new Notification();
            notification.Type = NotificationType.Success;
            notification.ShowNotification("Change to PASS", 4000);
        }

        private Historys _historys;
        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _historys?.Dispose();
            _historys = new Historys();
            _historys.Show();
        }

        private void btnClearMes_Click(object sender, EventArgs e)
        {
            clearMESToolStripMenuItem1_Click(sender, e);
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}