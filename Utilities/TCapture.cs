//using System;
//using System.Diagnostics;
//using System.Drawing;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Timers;
//using Emgu.CV;
//using Emgu.CV.CvEnum;
//using Emgu.CV.Structure;
//using OpenCvSharp;
//using Mat = Emgu.CV.Mat;
//using VideoCapture = Emgu.CV.VideoCapture;

using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Diagnostics;

namespace PJ24_010_Auto_Focus_CCD.Utilities
{
    public class TCapture : IDisposable
    {
        private OpenCvSharp.VideoCapture _videoCapture;
        private readonly object _lockObj = new object();

        public delegate void VideoCaptureError(string messages);
        public event VideoCaptureError OnError;

        public delegate void VideoFrameHeader(Bitmap bitmap);
        public event VideoFrameHeader OnFrameHeader;

        public delegate void VideoFrameHeaderMat(Mat mat);
        public event VideoFrameHeaderMat OnFrameHeaderMat;

        public delegate void VideoCaptureStop();
        public event VideoCaptureStop OnVideoStop;

        public delegate void VideoCaptureStarted();
        public event VideoCaptureStarted OnVideoStarted;

        private bool _onStarted = false;
        public bool IsRunning { get; private set; }
        private int _frameRate = 50;

        public int Width { get; set; }
        public int Height { get; set; }

        public void SetSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int FrameRate
        {
            get { return _frameRate; }
            set { _frameRate = 1000 / value; }
        }

        public bool IsOpened => _videoCapture?.IsOpened() ?? false;

        //public TCapture()
        //{
        //    Width = 1920;
        //    Height = 1080;
        //}

        private System.Threading.Timer _timer;

        public async Task StartAsync(int device)
        {
            await Task.Run(() => Start(device));
        }

        public void Start(int device)
        {
            lock (_lockObj)
            {
                try
                {
                    _videoCapture?.Dispose();

                    _videoCapture = new VideoCapture(device);

                    var width = _videoCapture.Get(VideoCaptureProperties.FrameWidth);
                    var height = _videoCapture.Get(VideoCaptureProperties.FrameHeight);
                    Debug.WriteLine($"Resolution: {width}x{height}");


                    Width = 1920;
                    Height = 1080;

                    _videoCapture?.Set(VideoCaptureProperties.FrameWidth, Width);
                    _videoCapture?.Set(VideoCaptureProperties.FrameHeight, Height);

                    if (!_videoCapture.IsOpened())
                    {
                        OnError?.Invoke("Cannot open the video capture device.");
                        return;
                    }

                    //SetFrame(Width, Height);

                    //var frameRate = _videoCapture.Fps;
                    //Thread.Sleep(200);
                    //int frameInterval = (int)(1000.0 / frameRate);

                    //frameInterval = Math.Max(frameInterval, 20);
                    width = _videoCapture.Get(VideoCaptureProperties.FrameWidth);
                    height = _videoCapture.Get(VideoCaptureProperties.FrameHeight);
                    Debug.WriteLine($"Resolution 2: {width}x{height}");
                    IsRunning = true;
                    _onStarted = true;

                    _timer?.Dispose();
                    _timer = new System.Threading.Timer(FrameCapture, null, 0, 100);
                }
                catch (Exception ex)
                {
                    OnError?.Invoke($"Error while starting video capture: {ex.Message}");
                }
            }
        }

        private void FrameCapture(object state)
        {
            lock (_lockObj)
            {
                try
                {
                    if (_videoCapture.IsOpened())
                    {
                        if (_onStarted)
                        {
                            OnVideoStarted?.Invoke();
                            _onStarted = false;
                        }

                        using (Mat frame = _videoCapture.RetrieveMat())
                        {
                            if (frame.Empty())
                            {
                                OnError?.Invoke("Frame is empty");
                            }
                            else
                            {
                                using (Bitmap bitmap = BitmapConverter.ToBitmap(frame))
                                {
                                    OnFrameHeader?.Invoke(bitmap);
                                }
                                OnFrameHeaderMat?.Invoke(frame);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    OnError?.Invoke(ex.Message);
                    Stop();
                }
            }
        }

        public void SetFrame(int width, int height)
        {
            _videoCapture?.Set(VideoCaptureProperties.FrameWidth, width);
            _videoCapture?.Set(VideoCaptureProperties.FrameHeight, height);
        }

        public async Task StopAsync()
        {
            await Task.Run(() => Stop());
        }

        public void Stop()
        {

            IsRunning = false;
            _videoCapture?.Release();
            _timer?.Dispose();
            _timer = null;
            OnVideoStop?.Invoke();

        }

        public void Dispose()
        {
            lock (_lockObj)
            {
                IsRunning = false;
                _videoCapture?.Dispose();
                _videoCapture = null;
            }
        }
    }
}