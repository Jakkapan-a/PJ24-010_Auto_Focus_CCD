using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace PJ24_010_Auto_Focus_CCD.Utilities
{
    public class TCapture : IDisposable
    {
        private VideoCapture? _videoCapture;
        private CancellationTokenSource? _cancellationTokenSource;

        public event Action<string>? OnError;
        public event Action<Bitmap>? OnFrameHeader;
        public event Action<Mat>? OnFrameHeaderMat;
        public event Action? OnVideoStop;
        public event Action? OnVideoStarted;

        public bool IsRunning { get; private set; }

        public int Width { get; set; } = 1920;
        public int Height { get; set; } = 1080;
        public int FrameRate { get; set; } = 30;

        public bool IsOpened => _videoCapture?.IsOpened ?? false;

        public async Task StartAsync(int device)
        {
            await Task.Run(() => Start(device));
        }

        public void Start(int device)
        {
            try
            {
                _videoCapture?.Dispose();
                _videoCapture = new VideoCapture(device, VideoCapture.API.DShow);

                _videoCapture.Set(CapProp.FrameWidth, Width);
                _videoCapture.Set(CapProp.FrameHeight, Height);
                if (!_videoCapture.IsOpened)
                {
                    OnError?.Invoke("Cannot open the video capture device.");
                    return;
                }

                _videoCapture.ImageGrabbed += ProcessFrame;

                IsRunning = true;
                OnVideoStarted?.Invoke();
                _cancellationTokenSource = new CancellationTokenSource();
                
                _videoCapture.Start();
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Error while starting video capture: {ex.Message}");
            }
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            try
            {
                if (_videoCapture == null) return;

                using var frame = new Mat();
                _videoCapture.Retrieve(frame);

                if (!frame.IsEmpty)
                {
                    Mat frameClone = frame.Clone();
                    OnFrameHeaderMat?.Invoke(frameClone);

                    using var bitmap = frameClone.ToBitmap();
                    OnFrameHeader?.Invoke(bitmap);

                    bitmap?.Dispose();
                    frameClone?.Dispose();
                }
                else
                {
                    OnError?.Invoke("Frame is empty");
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex.Message);
                Stop();
            }
        }

        public async Task StopAsync()
        {
            await Task.Run(() => Stop());
        }

        public void Stop()
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }

            if (_videoCapture != null)
            {
                _videoCapture.ImageGrabbed -= ProcessFrame;
                _videoCapture.Stop();
                _videoCapture.Dispose();
                _videoCapture = null;
            }

            IsRunning = false;
            OnVideoStop?.Invoke();
        }

        public void Dispose()
        {
            Stop();
            _videoCapture?.Dispose();
        }
    }
}
