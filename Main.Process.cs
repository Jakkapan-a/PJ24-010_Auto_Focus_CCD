using Emgu.CV.Dnn;
using PJ24_010_Auto_Focus_CCD.Forms;
using PJ24_010_Auto_Focus_CCD.SQLite;
using PJ24_010_Auto_Focus_CCD.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using YamlDotNet.Serialization;
using Yolonet;

namespace PJ24_010_Auto_Focus_CCD
{
    partial class Main
    {
        private int onnx_model_id = -1;
        private Product? product;
        private double currentVoltage = 0;
        private double currentCurrent = 0;
        private System.Windows.Forms.Timer timerCountStart = new System.Windows.Forms.Timer();
        IDeserializer deserializer;
        IPredictor predictor;
        private Prediction[]? predictions;

        private History history;
        private void InitializeProcess()
        {
            timerCountStart?.Dispose();

            timerCountStart = new System.Windows.Forms.Timer();
            timerCountStart.Interval = 100;
            timerCountStart.Tick += TimerCountStart_Tick;

            deserializer = new DeserializerBuilder().Build();
            //IPredictor predictor = await Task.Run(() => { return YoloV5Predictor.Create(pathModel, classobjPredic); });
            history = new History();
        }



        /**
         * Process
         * 1. Check if the product is valid
         * 2. Check if the product is in the database
         * 3. Check if the product->onnx_model_id is valid
         * 4. 
         * 5. 
         */
        private ProcessStatus processStatus = ProcessStatus.none;
        Product? _product = null;
        Dictionary<string, ItemResults> templatePredictor = new Dictionary<string, ItemResults>();
        private async void ProcessValidatedData()
        {
            try
            {
                lbTitle.Text = "Loading...";
                lbTitle.ForeColor = Color.Black;
                lbTitle.BackColor = Color.YellowGreen;
                await Task.Delay(500);
                txtLog.Text = "";
                this.history.re_judgment = "Null";

                // Validate Data 
                string txtQr = this.txtQr.Text;
                SetLog("QR Code: " + txtQr);
                // 721TMCHxxxxxxx
                // Slice the QR code to get the product name
                string productName = txtQr.Substring(0, 7);

                SetLog("Sort Name: " + productName);

                Debug.WriteLine("Product Name: " + productName);

                _product = Product.Get(productName);
                SetLog("Is Found: " + (_product != null ? "Yes" : "No"));

                if (_product != null)
                {
                    this.txtQr.ReadOnly = true;
                    if (_product.onnx_model_id != onnx_model_id)
                    {
                        // Load model
                        onnx_model_id = _product.onnx_model_id;
                        OnnxModel onnx = OnnxModel.Get(onnx_model_id);

                        string pathModel = Path.Combine(Properties.Resources.path_models, onnx.path_model);
                        string pathLabel = Path.Combine(Properties.Resources.path_models, onnx.path_label);
                        if (!File.Exists(pathModel) && !File.Exists(pathLabel))
                        {
                            throw new Exception("Model or Label not found");
                        }
                        string[] labels = System.IO.File.ReadAllLines(pathLabel);
                        predictor = YoloV5Predictor.Create(pathModel, labels);

                        string pathTemplate = Path.Combine(Properties.Resources.path_models, onnx.path_template);
                        if (!File.Exists(pathTemplate))
                        {
                            throw new Exception("Template not found");
                        }
                        templatePredictor.Clear();
                        // Yaml
                        string[] linesTemplate = Extensions.ReadFile(pathTemplate);
                        var yamlObject = deserializer.Deserialize<TemplateList>(string.Join("\n", linesTemplate));
                        foreach (var item in yamlObject.Template)
                        {
                            if (!templatePredictor.ContainsKey(item.name))
                            {
                                templatePredictor.Add(item.name, ItemResults.none);
                            }
                        }

                        SetLog("Load Model: " + onnx.name);
                        SetLog("Load Label: " + onnx.path_label);
                        SetLog("Load Template: " + onnx.path_label + "\n");

                    }

                    this.product = _product;
                    history.product_id = this.product.id;
                    history.employee = txtEmp.Text;
                    history.qr_code = txtQr;
                    history.onnx_model_id = product.onnx_model_id;
                    history.model_name = product.name;

                    processStatus = ProcessStatus.wait_start;
                    this.lbTitle.Text = _product.name + " - Wait Testing";
                    this.lbTitle.ForeColor = Color.Black;

                    string _dataSerialType = $"RAY:{(product.type == 1 ? "PVM1" : "NOT1")}";
                    SetLog("Send Data: " + _dataSerialType);

                    this.SendDataBuffer(_dataSerialType);
                    // Clear template predictor to 0
                    foreach (var item in templatePredictor)
                    {
                        templatePredictor[item.Key] = ItemResults.none;
                    }
                    this.txtQr.ReadOnly = false;
                    this.ActiveControl = this.txtQr;
                    this.txtQr.Focus();
                }
                else
                {
                    product = null;
                    processStatus = ProcessStatus.none;
                    this.lbTitle.Text = "QR Code Invalid, Please scan again";
                    this.lbTitle.ForeColor = Color.Black;
                    this.lbTitle.BackColor = Color.Orange;

                    // ------------------- Reset ------------------- //
                    this.txtQr.Text = "";
                    this.ActiveControl = this.txtQr;
                    this.txtQr.Focus();
                }
            }
            catch (Exception ex)
            {
                this.lbTitle.Text = ex.Message;
                this.lbTitle.ForeColor = Color.Black;
                this.lbTitle.BackColor = Color.Orange;

                // ------------------- Reset ------------------- //
                this.txtQr.Text = "";
                this.ActiveControl = this.txtQr;
                this.txtQr.Focus();
            }
        }

        private void StartProcess()
        {
            if (processStatus == ProcessStatus.none)
            {
                // MessageBox.Show("Invalid Product, Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbTitle.Text = "QR Code Invalid, Please scan again";
                lbTitle.ForeColor = Color.Black;
                this.lbTitle.BackColor = Color.Orange;
                return;
            }

            if (processStatus != ProcessStatus.wait_start)
            {
                // MessageBox.Show("Invalid Process, Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string message = "QR Code Invalid, Please scan again";
                if (txtQr.Text.Length > 0)
                {
                    message = "Please wait for the current process to finish";
                }
                else
                {
                    message = "QR Code is empty!, Please scan again";
                }
                this.lbTitle.Text = message;
                this.lbTitle.ForeColor = Color.Black;
                this.lbTitle.BackColor = Color.Orange;
                return;
            }
            // Code...
            // Count 1.5 sec for test
            countDownStart = Properties.Settings.Default.CountDownStart;
            timerCountStart.Start();
        }
        private bool isClone = false; // Clone ImagePredict
        private const string OK_SUFFIX = "_OK";
        private const string NG_SUFFIX = "_NG";
        private string pathFolder = "";
        private Stopwatch stopwatchTestProcess = new Stopwatch();

        private async void TestProcess()
        {
            stopwatchTestProcess.Restart();
            // code...
            await Task.Run(async () =>
            {
                SetLog("+++ Start Testing +++");
                isClone = false;
                int count_error = 20;
                while (!isClone)
                {
                    Thread.Sleep(100);
                    count_error--;
                    if (count_error < 0)
                    {
                        break;
                    }
                }
                if (count_error < 0)
                {
                    processStatus = ProcessStatus.error;
                    return;
                }


                // Process Prediction
                predictions = predictor.Predict(imagePredict);
                // stopwatchTestProcess.Stop();
                SetLog("Prediction Time: " + stopwatchTestProcess.ElapsedMilliseconds + "ms\n");
                // stopwatchTestProcess.Start();
                // Validate
                Debug.WriteLine(predictions);
                if (predictions != null)
                {
                    foreach (var prediction in predictions)
                    {
                        string? labelName = prediction?.Label?.Name;
                        if (labelName == null) continue;
                        if (prediction.Score < Properties.Settings.Default.Score)
                        {
                            continue;
                        }
                        string baseName = System.Text.RegularExpressions.Regex.Replace(labelName, $"({OK_SUFFIX}|{NG_SUFFIX})", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                        if (templatePredictor.ContainsKey(baseName))
                        {
                            if (labelName.Contains(OK_SUFFIX, StringComparison.OrdinalIgnoreCase))
                            {
                                templatePredictor[baseName] = ItemResults.pass;
                            }
                            else if (labelName.Contains(NG_SUFFIX, StringComparison.OrdinalIgnoreCase))
                            {
                                templatePredictor[baseName] = ItemResults.fail;
                            }

                            SetLog($"Check : {baseName} = {(templatePredictor[baseName] == ItemResults.pass ? "PASS" : "NG")}");
                        }
                    }
                }

                // Check Template
                bool isPass = true;
                bool isResultNone = false;
                foreach (var item in templatePredictor)
                {
                    if (item.Value == ItemResults.none)
                    {
                        isPass = false;
                        isResultNone = true;
                        SetLog($"Check : {item.Key} = NULL");
                    }
                    else if (item.Value == ItemResults.fail)
                    {
                        isPass = false;
                    }

                }
                SetLog("\n+++-------------+++");

                history.voltage = (int)(currentVoltage * 1000);
                history.current = (int)(currentCurrent * 1000);
                // Check Voltage and Current
                if (this.currentVoltage < (product?.voltage_min / 1000) || this.currentVoltage > (product?.voltage_max / 1000))
                {
                    isPass = false;
                    SetLog($"Voltage: {this.currentVoltage}V - {product?.voltage_min / 1000}-{product?.voltage_max / 1000}V - Out of range");
                }
                else
                {
                    SetLog($"Voltage: {this.currentVoltage}V - {product?.voltage_min / 1000}-{product?.voltage_max / 1000}V - OK");
                }

                if (this.currentCurrent < (product?.current_min / 1000) || this.currentCurrent > (product?.current_max / 1000))
                {
                    isPass = false;
                    SetLog($"Current: {this.currentCurrent}A - {product?.current_min / 1000}-{product?.current_max / 1000}mA - Out of range");
                }
                else
                {
                    SetLog($"Current: {this.currentCurrent}A - {product?.current_min / 1000}-{product?.current_max / 1000}mA - OK");
                }

                if (isPass)
                {
                    processStatus = ProcessStatus.pass;
                    history.result = "PASS";
                    string _dataSerialType = $"KBD:{txtQr.Text}";
                    this.SendDataBuffer(_dataSerialType);
                    await Task.Delay(500);
                    _dataSerialType = $"LED:G";
                    this.SendDataBuffer(_dataSerialType);
                }
                else
                {
                    processStatus = ProcessStatus.fail;
                    history.result = "NG";
                    // Send Data If Allow Send Data
                    if (Properties.Settings.Default.IsAllowSendData && !isResultNone)
                    {
                        string _dataSerialTypeKyeNG = $"KBD:{Properties.Settings.Default.KeyNG}";
                        this.SendDataBuffer(_dataSerialTypeKyeNG);
                        await Task.Delay(Properties.Settings.Default.KeyNGDelay);
                        string _dataSerialType = $"KBD:{txtQr.Text}";
                        this.SendDataBuffer(_dataSerialType);
                    }

                    await Task.Delay(500);
                    string _dataLED = $"LED:R";
                    this.SendDataBuffer(_dataLED);
                }
            });

            SetLog("+++ Test Completed +++");
            if (processStatus == ProcessStatus.error)
            {
                this.lbTitle.Text = "ERROR - " + product?.name;
                this.lbTitle.ForeColor = Color.White;
                this.lbTitle.BackColor = Color.Red;
                SetLog("+++ ERROR +++");
                return;
            }
            if (processStatus == ProcessStatus.pass)
            {
                this.lbTitle.Text = "PASS";
                this.lbTitle.ForeColor = Color.White;
                this.lbTitle.BackColor = Color.Green;
                SetLog("+++ PASS +++");
            }
            else
            {
                this.lbTitle.Text = "NG";
                this.lbTitle.ForeColor = Color.White;
                this.lbTitle.BackColor = Color.Red;
                SetLog("+++ NG +++");
            }

            // Save Image and Data
            string date = DateTime.Now.ToString("yyyyMMdd");
            string time = DateTime.Now.ToString("HHmmss");

            history.path_folder = $"{txtQr.Text}_{time}";

            // check folder
            pathFolder = Path.Combine(Properties.Resources.path_predict, date, $"{txtQr.Text}_{time}");
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);
            }

            // Save Image
            string pathImage = Path.Combine(pathFolder, "ORG_" + Guid.NewGuid().ToString().Replace("-", "_") + ".jpg");
            imagePredict.Save(pathImage, System.Drawing.Imaging.ImageFormat.Jpeg);

            using (Image img = (Bitmap)imagePredict.Clone())
            {
                DrawImages.DrawBoxes(img, predictions);
                string pathImagePredict = Path.Combine(pathFolder, "PREDICT_" + Guid.NewGuid().ToString().Replace("-", "_") + ".jpg");
                img.Save(pathImagePredict, System.Drawing.Imaging.ImageFormat.Jpeg);
                img?.Dispose();
            }
            stopwatchTestProcess.Stop();
            SetLog("End Process Time: " + stopwatchTestProcess.ElapsedMilliseconds + "ms\n");
        }

        private void StopProcess()
        {
            if (timerCountStart.Enabled)
            {
                timerCountStart.Stop();
                processStatus = ProcessStatus.wait_start;
                this.lbTitle.Text = _product?.name + " - Wait Testing";
                this.lbTitle.ForeColor = Color.Black;
                return;
            }

            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);
            }

            // Save Data
            string pathData = Path.Combine(pathFolder, "log.txt");
            txtLog.SaveFile(pathData, RichTextBoxStreamType.PlainText);

            history.Save();

            // Title
            this.lbTitle.Text = "Ready";
            this.lbTitle.ForeColor = Color.Black;
            this.lbTitle.BackColor = Color.Yellow;

            // End Process 
            this.txtQr.Text = "";
            this.ActiveControl = this.txtQr;
            this.txtQr.Focus();
            this.txtQr.ReadOnly = false;
            predictions = null;

            processStatus = ProcessStatus.ready;
            string _dataSerialType = $"RAY:RST";
            this.SendDataBuffer(_dataSerialType);
            // await Task.Delay(500);
            _dataSerialType = $"LED:0";
            this.SendDataBuffer(_dataSerialType);
            // Save Log
            // txtLog.Text.SaveLog("log.txt");
            // Clear log
            txtLog.Text = "";
        }
        private bool togglePause = false;
        private void TimerOnSecond_Tick(object? sender, EventArgs e)
        {
            if (processStatus == ProcessStatus.pass || processStatus == ProcessStatus.fail)
            {
                // //Debug.WriteLine("On Report");
                // if(predictions != null)
                // {

                // }
                togglePause = !togglePause;
            }
            else
            {
                togglePause = true;
            }
        }
        private int countDownStart = 15;
        private void TimerCountStart_Tick(object? sender, EventArgs e)
        {
            if (countDownStart > 0)
            {
                countDownStart--;
                double down = (double)countDownStart / 10;
                this.lbTitle.Text = "Test in " + down.ToString() + "s";
                this.lbTitle.ForeColor = Color.Black;
                this.lbTitle.BackColor = Color.YellowGreen;
            }
            else
            {
                this.lbTitle.Text = "Testing...";
                this.lbTitle.ForeColor = Color.Black;
                this.lbTitle.BackColor = Color.YellowGreen;
                timerCountStart.Stop();
                TestProcess();
            }
        }

        private void SetLog(string message)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() =>
                {
                    txtLog.Text += message + "\n";
                }));
            }
            else
            {
                txtLog.Text += message + "\n";
            }
        }
    }

    public enum ProcessStatus
    {
        none,
        ready,
        wait_start,
        running,
        prediction,
        paused,
        stopped,
        error, // ERROR
        pass, // PASS
        fail, // NG
    }

    public enum ItemResults
    {
        none,
        pass,
        fail // NG
    }
}
