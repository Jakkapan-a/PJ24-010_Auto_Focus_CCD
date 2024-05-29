using PJ24_010_Auto_Focus_CCD.Utilities;
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
        private TCapture capture;

        private void InitializeTCapture()
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

        private Image imagePredict = null;
        private Image imageCapture = null;
        private void Capture_OnFrameHeader(Bitmap bitmap)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Capture_OnFrameHeader(bitmap)));
                return;
            }
            pictureBox.Image?.Dispose();
            
            if (processStatus == ProcessStatus.pass || processStatus == ProcessStatus.fail)
            {
                if(imagePredict != null)
                {
                    pictureBox.Image = (Image?)imagePredict.Clone();
                }
            }
            else
            {
                pictureBox.Image = new Bitmap(bitmap);

            }
            // 
            if (processStatus == ProcessStatus.pass || processStatus == ProcessStatus.fail)
            {
                if (predictions != null)
                {
                    DrawImages.DrawBoxes(pictureBox.Image, predictions, togglePause);
                }
            }
            if (!isClone)
            {
                imagePredict?.Dispose();
                imagePredict = new Bitmap(bitmap);
                isClone = true;
            }

            if (!IsCaptureImage)
            {
                imageCapture?.Dispose();
                imageCapture = new Bitmap(bitmap);
                IsCaptureImage = true;
            }
        }
    }
}
