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

         private void Process()
         {
            string txtQr = this.txtQr.Text;

            // 721TMCHxxxxxxx
            // Slice the QR code to get the product name
            string productName = txtQr.Substring(0, 7);

            Debug.WriteLine("Product Name: " + productName);
         }
    }

    public enum ProcessStatus
    {
        none,
        ready,
        running,
        paused,
        stopped,
        error,
        pass,
        fail,
    }
}
