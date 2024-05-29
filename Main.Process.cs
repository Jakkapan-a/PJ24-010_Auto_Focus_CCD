using Emgu.CV.Dnn;
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

        private System.Windows.Forms.Timer timerCountStart = new System.Windows.Forms.Timer();
        IDeserializer deserializer;
        IPredictor predictor;
        private Prediction[]? predictions;
        private void InitializeProcess()
        {
            timerCountStart?.Dispose();

            timerCountStart = new System.Windows.Forms.Timer();
            timerCountStart.Interval = 100;
            timerCountStart.Tick += TimerCountStart_Tick;

            deserializer = new DeserializerBuilder().Build();
            //IPredictor predictor = await Task.Run(() => { return YoloV5Predictor.Create(pathModel, classobjPredic); });

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
        Dictionary<string, int> templatePredictor = new Dictionary<string, int>();
        private async void ProcessValidatedData()
        {
            try
            {
                lbTitle.Text = "Loading...";
                lbTitle.ForeColor = Color.Black;
                lbTitle.BackColor = Color.YellowGreen;
                await Task.Delay(500);
                // Validate Data 
                string txtQr = this.txtQr.Text;
                // 721TMCHxxxxxxx
                // Slice the QR code to get the product name
                string productName = txtQr.Substring(0, 7);
                Debug.WriteLine("Product Name: " + productName);

                _product = Product.Get(productName);
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
                        if(!File.Exists(pathTemplate))
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
                                templatePredictor.Add(item.name, 0);
                            }
                        }
                    }
                  
                    this.product = _product;
                    processStatus = ProcessStatus.wait_start;
                    this.lbTitle.Text = _product.name + " - Wait Testing";
                    this.lbTitle.ForeColor = Color.Black;

                    string _dataSerialType = $"RAY:{(product.type == 1 ? "PVM1" : "NOT1")}";
                    this.SendDataBuffer(_dataSerialType);

                    // Clear template predictor to 0
                    foreach (var item in templatePredictor)
                    {
                        templatePredictor[item.Key] = 0;
                    }
                    this.txtQr.ReadOnly = false;
                    this.ActiveControl = this.txtQr;
                    this.txtQr.Focus();

                    //StartProcess();
                }
                else
                {
                    product = null;
                    processStatus = ProcessStatus.none;
                    // MessageBox.Show("Invalid Product, Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                if(txtQr.Text.Length > 0)
                {
                    message = "Please wait for the current process to finish";
                }else{
                    message = "QR Code is empty!, Please scan again";
                }
                this.lbTitle.Text = message;
                this.lbTitle.ForeColor = Color.Black;
                this.lbTitle.BackColor = Color.Orange;
                return;
            }
            // Code...
            // Count 1.5 sec for test
            countDownStart = 15;
            timerCountStart.Start();
        }
        private bool isClone = false;
        private async void TestProcess()
        {
            // code...
            await Task.Run(() =>
            {
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
                // Validate
                Debug.WriteLine(predictions);
                if(predictions != null )
                {

                }
            });

            if (processStatus == ProcessStatus.error)
            {
                this.lbTitle.Text = "ERROR - " + product?.name;
                this.lbTitle.ForeColor = Color.White;
                this.lbTitle.BackColor = Color.Red;
                return;
            }
            // Pass
            this.lbTitle.Text = "PASS - " + product?.name;
            this.lbTitle.ForeColor = Color.White;
            this.lbTitle.BackColor = Color.Green;
            processStatus = ProcessStatus.pass;
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
            // Save Data

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
        }
        private bool togglePause = false;
        private void TimerOnSecond_Tick(object? sender, EventArgs e)
        {
            if (processStatus == ProcessStatus.pass || processStatus == ProcessStatus.fail)
            {
                //Debug.WriteLine("On Report");
                if(predictions != null)
                {

                }
                togglePause = !togglePause;
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
                timerCountStart.Stop();
                TestProcess();
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

    public enum ItemsResutls
    {
        none,
        pass,
        fail
    }
}
