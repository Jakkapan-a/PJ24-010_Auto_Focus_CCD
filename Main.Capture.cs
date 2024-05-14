using PJ24_010_Auto_Focus_CCD.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ24_010_Auto_Focus_CCD
{
    partial class Main
    {
        private TCapture capture;
        void InitializeTCapture()
        {
            capture = new TCapture();
            capture.OnError += Capture_OnError;
            capture.OnFrameHeader += Capture_OnFrameHeader;
            capture.OnVideoStarted += Capture_OnVideoStarted;
            capture.OnVideoStop += Capture_OnVideoStop;
        }

        private void Capture_OnVideoStop()
        {

        }

        private void Capture_OnVideoStarted()
        {

        }

        private void Capture_OnError(string obj)
        {

        }

        private void Capture_OnFrameHeader(Bitmap bitmap)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Capture_OnFrameHeader(bitmap)));
                return;
            }

            pictureBox.Image?.Dispose();
            pictureBox.Image = new Bitmap(bitmap);
        }
    }
}
