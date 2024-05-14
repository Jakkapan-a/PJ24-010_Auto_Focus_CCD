using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Diagnostics;
using System.Timers;

namespace PJ24_010_Auto_Focus_CCD.Utilities
{
    public class TCapture : IDisposable
    {
        private VideoCapture? _videoCapture;
        private System.Timers.Timer? _timer;
        private readonly object _lockObj = new object();

        public event Action<string>? OnError;
        public event Action<Bitmap>? OnFrameHeader;
        public event Action<Mat>? OnFrameHeaderMat;
        public event Action? OnVideoStop;
        public event Action? OnVideoStarted;

        public bool IsRunning { get; private set; }
        private int _frameRate = 50;

        public int Width { get; set; } = 1920;
        public int Height { get; set; } = 1080;

        public int FrameRate
        {
            get => _frameRate;
            set => _frameRate = 1000 / value;
        }

        public bool IsOpened => _videoCapture?.IsOpened() ?? false;

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

                    _videoCapture.Set(VideoCaptureProperties.FrameWidth, Width);
                    _videoCapture.Set(VideoCaptureProperties.FrameHeight, Height);

                    if (!_videoCapture.IsOpened())
                    {
                        OnError?.Invoke("Cannot open the video capture device.");
                        return;
                    }

                    IsRunning = true;
                    OnVideoStarted?.Invoke();

                    _timer?.Dispose();
                    _timer = new System.Timers.Timer(1000 / _frameRate);
                    _timer.Elapsed += FrameCapture;
                    _timer.Start();
                }
                catch (Exception ex)
                {
                    OnError?.Invoke($"Error while starting video capture: {ex.Message}");
                }
            }
        }

        private void FrameCapture(object? sender, ElapsedEventArgs e)
        {
            lock (_lockObj)
            {
                if (_videoCapture == null) return;

                if (_videoCapture.IsOpened() && IsRunning)
                {
                    try
                    {
                        using (var frame = new Mat())
                        {
                            if (_videoCapture.Read(frame) && !frame.Empty())
                            {
                                OnFrameHeaderMat?.Invoke(frame.Clone());
                                using (var bitmap = BitmapConverter.ToBitmap(frame))
                                {
                                    OnFrameHeader?.Invoke(bitmap);
                                }
                            }
                            else
                            {
                                OnError?.Invoke("Frame is empty");
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
        }

        
        public async Task StopAsync()
        {
            await Task.Run(() => Stop());
        }

        public void Stop()
        {
            lock (_lockObj)
            {
                IsRunning = false;
                _videoCapture?.Release();
                _timer?.Stop();
                OnVideoStop?.Invoke();
            }
        }

        public void Dispose()
        {
            Stop();
            _videoCapture?.Dispose();
            _timer?.Dispose();
        }
    }
}
