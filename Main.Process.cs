using PJ24_010_Auto_Focus_CCD.SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ24_010_Auto_Focus_CCD
{
    partial class Main
    {
        private int onnx_model_id = -1;
        private Product? product;
        private void InitializeProcess()
        {

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
        private void ProcessValiidateData()
        {
            // Validate Data 
            string txtQr = this.txtQr.Text;
            // 721TMCHxxxxxxx
            // Slice the QR code to get the product name
            string productName = txtQr.Substring(0, 7);
            Debug.WriteLine("Product Name: " + productName);

            var _product = Product.Get(productName);
            if (_product != null)
            {
                this.product = _product;
                processStatus = ProcessStatus.ready;
                this.txtQr.ReadOnly = true;
                this.lbTitle.Text = _product.name + " - Waiting for Test";

                if (_product.onnx_model_id != onnx_model_id)
                {
                    // Load model


                }
                this.txtQr.ReadOnly = false;
                this.ActiveControl = this.txtQr;
                this.txtQr.Focus();
            }
            else
            {
                product = null;
                processStatus = ProcessStatus.none;
                MessageBox.Show("Invalid Product, Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtQr.Text = "";
                this.ActiveControl = this.txtQr;
                this.txtQr.Focus();
            }
        }

        private void StartProcess()
        {
            if(processStatus == ProcessStatus.none)
            {
                //MessageBox.Show("Invalid Product, Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // code...


            // Pass
            this.lbTitle.Text = "PASS - " + product?.name;
            this.lbTitle.ForeColor = Color.White;
            this.lbTitle.BackColor = Color.Green;
            processStatus = ProcessStatus.ready;
        }

        private void StopProcess()
        {
            // code...
             // Title
            this.lbTitle.Text = "Ready";
            this.lbTitle.ForeColor = Color.Black;
            this.lbTitle.BackColor = Color.Yellow;


             // End Process
            this.txtQr.Text = "";
            this.ActiveControl = this.txtQr;
            this.txtQr.Focus();
            this.txtQr.ReadOnly = false;
        }

    }

    public enum ProcessStatus
    {
        none,
        ready,
        wait_sensor,
        running,
        prediction,
        paused,
        stopped,
        error,
        pass,
        fail,
    }
}
