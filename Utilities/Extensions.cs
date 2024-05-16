using OpenCvSharp.Extensions;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PJ24_010_Auto_Focus_CCD.Utilities
{
    public static class Extensions
    {
        public static string ReadFileOnce(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
        public static string[] ReadFile(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(stream))
            {
                var content = reader.ReadToEnd();
                return content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            }
        }
        public static Bitmap ReScale(Bitmap bmp, System.Drawing.Size newSize)
        {
            // สร้าง object Bitmap ใหม่ที่มีขนาดตามที่ระบุ
            Bitmap scaledBitmap = new Bitmap(newSize.Width, newSize.Height);

            // ใช้งาน Graphics จาก Bitmap ที่สร้างขึ้นเพื่อวาดภาพ
            using (Graphics graphics = Graphics.FromImage(scaledBitmap))
            {
                // ตั้งค่าพารามิเตอร์ต่างๆ สำหรับการวาด
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;

                // วาดภาพ Bitmap ต้นฉบับลงใน Bitmap ใหม่ที่มีขนาดที่เปลี่ยนไป
                graphics.DrawImage(bmp, 0, 0, newSize.Width, newSize.Height);
            }

            // คืนค่า Bitmap ที่ได้ย่อขนาดแล้ว
            return scaledBitmap;
        }
        public static Bitmap ReScale(Bitmap bmp, float percentage)
        {

            if (bmp == null) throw new ArgumentNullException("bmp cannot be null.");
            if (percentage <= 0 || percentage > 1) throw new ArgumentOutOfRangeException("percentage must be between 0 and 1.");

            // คำนวณขนาดใหม่จากเปอร์เซ็นต์ที่ระบุ โดยรักษาอัตราส่วนด้านของภาพ
            int newWidth = (int)(bmp.Width * percentage);
            int newHeight = (int)(bmp.Height * percentage);

            // ป้องกันการสร้าง Bitmap ที่มีขนาดไม่ถูกต้อง
            if (newWidth <= 0 || newHeight <= 0)
            {
                throw new InvalidOperationException("Scaled dimensions are too small or negative.");
            }

            // ใช้ฟังก์ชันการย่อขนาดด้วยขนาดที่คำนวณได้
            return ReScale(bmp, new System.Drawing.Size(newWidth, newHeight));

        }

        public static int GetSelectedRowIndex(DataGridView dataGrid)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                return dataGrid.SelectedRows[0].Index;
            }
            return -1;
        }

        public static void SelectedRow(DataGridView dataGrid, int rowIndex)
        {
            dataGrid.ClearSelection();
            if (rowIndex >= 0 && rowIndex < dataGrid.Rows.Count)
            {
                dataGrid.Rows[rowIndex].Selected = true;
            }
        }

        public static bool IsValidIP(string ip)
        {
            // Regular expression pattern to match valid IPv4 addresses.
            string pattern = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
            return Regex.IsMatch(ip, pattern);
        }

        public static bool IsValidPort(string port)
        {
            int portNumber;
            if (int.TryParse(port, out portNumber))
            {
                return portNumber >= 0 && portNumber <= 65535;
            }
            return false;
        }
        public static Bitmap ConvertToGrayscale(Bitmap inputBitmap)
        {
            using (Mat src = BitmapConverter.ToMat(inputBitmap))
            using (Mat gray = new Mat())
            {
                Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
                return BitmapConverter.ToBitmap(gray);
            }
        }

        public static float? StringToFloat(string input)
        {
            float result;
            if (float.TryParse(input, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public static float? StringToInt(string input)
        {
            int result;
            if (int.TryParse(input, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public static bool IsFloat(string input)
        {
            float result;
            return float.TryParse(input, out result);
        }

        public static bool IsInt(string input)
        {
            int result;
            return int.TryParse(input, out result);
        }
        public static bool IsDigits(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;

            return s.All(char.IsDigit);
        }
        public static bool IsHexadecimal(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex)) return false;

            return Regex.IsMatch(hex, @"^[0-9A-Fa-f]+$");
        }

    }
}
