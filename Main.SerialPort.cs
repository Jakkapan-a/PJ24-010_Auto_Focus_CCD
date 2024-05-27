using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PJ24_010_Auto_Focus_CCD
{
    partial class Main
    {
        private SerialPort serialPort = null;
        private void InitializeSerialPort()
        {
            serialPort = new SerialPort();
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.ErrorReceived += SerialPort_ErrorReceived;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                ReadSerialData();
                ProcessDataBuffer();
            }
            catch (Exception ex)
            {
               Debug.WriteLine("Error: " + ex.Message);
            }

        }

        private ConcurrentQueue<string> _dataBufferString = new ConcurrentQueue<string>();
        private void ReadSerialData()
        {
            try
            {
                // Reading the data from the serial port
                byte[] bytes = new byte[this.serialPort.BytesToRead];
                this.serialPort.Read(bytes, 0, bytes.Length);

                // Logging the ASCII representation
                foreach (byte b in bytes) // Make sure it's 'bytes' not 'bytes1'
                {
                    // For debugging, write the actual bytes being read to the console/output.
                    _dataBufferString.Enqueue(Encoding.ASCII.GetString(new byte[] { b }) + "");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error :" + ex.Message);
            }
        }
        private delegate void UpdateDataReceivedString(string data);
        private string isStartSTR = "$";
        private string isEndSTR = "#";
        private System.Threading.Tasks.Task taskProcessDataBuffer;
        private void ProcessDataBuffer()
        {
            if (taskProcessDataBuffer != null && taskProcessDataBuffer.Status != System.Threading.Tasks.TaskStatus.RanToCompletion)
            {
                return;
            }

            taskProcessDataBuffer = System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    while ((_dataBufferString.Contains(isStartSTR) && _dataBufferString.Contains(isEndSTR)))
                    {
                        //LogReceivedData();
                        ExtractAndProcessMessage();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error processing data buffer: " + ex.Message);
                    // Log the exception or handle it appropriately.
                }
            });
        }
        
        private void ExtractAndProcessMessage()
        {
            var dataStringList = _dataBufferString.ToList();
            int indexStart = dataStringList.IndexOf(isStartSTR);
            int indexEnd = dataStringList.IndexOf(isEndSTR);

            if (indexStart < indexEnd)
            {
                var message = dataStringList.GetRange(indexStart, indexEnd - indexStart + 1).ToArray();
                // Dequeue the processed bytes from _dataBuffer
                for (int i = 0; i <= indexEnd; i++)
                {
                    _dataBufferString.TryDequeue(out _);
                }

                string receive = string.Join("", message).Replace(isStartSTR, string.Empty).Replace(isEndSTR, string.Empty);
                this.Invoke(new UpdateDataReceivedString(DataReceivedString), receive);
            }
            else
            {
                for (int i = 0; i < indexStart; i++)
                {
                    _dataBufferString.TryDequeue(out _);
                }
            }
        }

        private void DataReceivedString(string data)
        {
            string input = data.Trim();
            Debug.WriteLine("Receive : " + input);
            // -------------------- RESET ---------------------- //
            if (input.Contains("RECEIVED"))
            {
                serialDataStatus = SerialStatus.Received;
            }
            else if (input.Contains("SENSOR1:"))
            {
                if (input.Contains("ON"))
                {
                    Debug.WriteLine("SN:ON");
                    StartProcess();
                }
                else if (input.Contains("OFF"))
                {
                    Debug.WriteLine("SN:OFF");
                    StopProcess();
                }
            }

            serialDataStatus = SerialStatus.Received;
        }
        
        private void SerialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {

        }

        private bool SerialPortConnect(string com_port, int baudrate)
        {
            try
            {
                // Check serial, if connect to disconnect
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }

                serialPort.PortName = com_port;
                serialPort.BaudRate = baudrate;

                serialPort.Open();
                if(serialPort.IsOpen)
                {
                    this.SendDataBuffer("CONN:1");
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private bool DisconnectSerial(){
            try
            {
                if(serialPort.IsOpen)
                {
                    serialPort.Close();
                }
            }catch
            {
                return false;
            }
            return true;
        }
        private ConcurrentQueue<string> serialDataQueue = new ConcurrentQueue<string>();
        private Task taskSendDataBuffer;

        private AutoResetEvent dataReadySignal = new AutoResetEvent(false); // A signaling mechanism
        private CancellationTokenSource cts = new CancellationTokenSource(); // Cancellation token source

        private SerialStatus serialDataStatus = SerialStatus.Unknown;

        public void SendDataBuffer(string data)
        {
            // Add data to buffer 
            lock (serialDataQueue)
            {
                // Add data to queue
                serialDataQueue.Enqueue(data);
            }
            dataReadySignal.Set(); // Signal that there's data to process

            if (taskSendDataBuffer != null && !taskSendDataBuffer.IsCompleted)
            {
                return;
            }
            // Create a new task to process the data
            cts = new CancellationTokenSource();
            taskSendDataBuffer = Task.Run(()=>{
                try{
                    while(!cts.Token.IsCancellationRequested)
                    {
                        if(serialDataQueue.Count == 0)
                        {
                            // Wait for data to process
                            dataReadySignal.WaitOne();
                        }

                        // Process data
                        string? dataToSend = "";
                        lock(serialDataQueue)
                        {
                            if(serialDataQueue.Count > 0)
                            {
                                serialDataQueue.TryDequeue(out dataToSend);
                            }
                        }

                        // Check if data is empty
                        if(string.IsNullOrEmpty(dataToSend)) continue;
                        serialDataStatus = SerialStatus.Sent;
                        int count = 0;
                        while (serialDataStatus != SerialStatus.Received && !cts.Token.IsCancellationRequested)
                        {
                            count++;
                            // Send data to serial port
                            if(serialPort.IsOpen && dataToSend.Contains("$") && dataToSend.Contains("#"))
                            {
                                serialPort.Write(dataToSend);
                            }else
                            if (serialPort.IsOpen)
                            {
                                serialPort.Write($"${dataToSend}#");
                            }

                            if (count > 3)
                            {
                                serialDataStatus = SerialStatus.Received;
                            }

                            // Sleep for a short duration, considering a possible cancellation request
                            if (!cts.Token.WaitHandle.WaitOne(20)) // 
                            {
                                break; // Exit if a cancellation was requested
                            }

                        }
                    }
                }catch(Exception ex)
                {
                    // LogWriter.SaveLog("Error: " + ex.Message);
                    Debug.WriteLine("Error data: " + ex.Message);
                }
            });
        }
    }

    public enum SerialStatus
    {
        Unknown,
        Ready,
        Busy,
        Error,
        Received,
        Sent
    }
}
