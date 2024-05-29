using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yolonet;

namespace PJ24_010_Auto_Focus_CCD.Utilities
{
    public class DrawImages
    {
        public static void DrawBoxes(Image image, Prediction[]? predictions)
        {
            if (image == null || predictions == null) return;

            var originalImageHeight = image.Height;
            var originalImageWidth = image.Width;

            var ratio = Math.Max(image.Size.Width, image.Size.Height) / 640F;

            using (Graphics g = Graphics.FromImage(image))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                float fontSize = 4F * ratio;
                float textPadding = 1F * ratio; // Adjust the '5F' value to increase or decrease padding.
                using (Font font = new Font("Consolas", fontSize))
                {
                    foreach (var pred in predictions)
                    {
                        if (pred.Score <= Properties.Settings.Default.Score) continue;

                        var x = Math.Max(pred.Rectangle.X, 0);
                        var y = Math.Max(pred.Rectangle.Y, 0);
                        var width = Math.Min(originalImageWidth - x, pred.Rectangle.Width);
                        var height = Math.Min(originalImageHeight - y, pred.Rectangle.Height);

                        // Bounding Box Text
                        string text = $"{pred.Label.Name} [{pred.Score}]";


                        System.Drawing.PointF point = new System.Drawing.PointF(x + textPadding, y - font.Height - textPadding);
                        SizeF textSize = g.MeasureString(text, font);
                        System.Drawing.RectangleF textBackground = new System.Drawing.RectangleF(point.X - textPadding, point.Y, textSize.Width + 2 * textPadding, textSize.Height);

                        Color color = Color.Orange;
                        if (text.Contains("ok", StringComparison.OrdinalIgnoreCase))
                        {
                            color = Color.Green;
                        }
                        else if (text.Contains("ng", StringComparison.OrdinalIgnoreCase))
                        {
                            color = Color.Red;
                        }

                        using (Brush textBrush = new SolidBrush(Color.Black))
                        using (Brush bgBrush = new SolidBrush(Color.FromArgb(127, color))) // semi-transparent background
                        using (Pen pen = new Pen(color, 2))
                        {
                            // Draw Text Background
                            g.FillRectangle(bgBrush, textBackground);

                            // Draw Text
                            g.DrawString(text, font, textBrush, point);

                            // Draw Rectangle
                            g.DrawRectangle(pen, x, y, width, height);
                        }
                    }
                }
            }
        }

        public static void DrawBoxes(Image image, Prediction[] predictions, bool isToggle = false)
        {
            if (image == null || predictions == null) return;

            const string OK_TEXT = "ok";
            const string NG_TEXT = "ng";

            var originalImageHeight = image.Height;
            var originalImageWidth = image.Width;
            var ratio = Math.Max(image.Size.Width, image.Size.Height) / 640F;

            using (Graphics g = Graphics.FromImage(image))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                float fontSize = 4F * ratio;
                float textPadding = 1F * ratio;

                using (Font font = new Font("Consolas", fontSize))
                {
                    foreach (var pred in predictions)
                    {

                        if (pred.Score <= Properties.Settings.Default.Score) continue;

                        var x = Math.Max(pred.Rectangle.X, 0);
                        var y = Math.Max(pred.Rectangle.Y, 0);
                        var width = Math.Min(originalImageWidth - x, pred.Rectangle.Width);
                        var height = Math.Min(originalImageHeight - y, pred.Rectangle.Height);

                        string text = $"{pred.Label.Name} [{pred.Score}]";
                        Color color;

                        if (text.Contains(OK_TEXT, StringComparison.OrdinalIgnoreCase))
                        {
                            color = Color.Green;
                        }
                        else if (text.Contains(NG_TEXT, StringComparison.OrdinalIgnoreCase))
                        {
                            color = Color.Red;
                        }
                        else
                        {
                            color = Color.Orange;
                        }

                        if ((isToggle && text.Contains(NG_TEXT, StringComparison.OrdinalIgnoreCase)))
                        {
                            System.Drawing.PointF point = new System.Drawing.PointF(x + textPadding, y - font.Height - textPadding);
                            SizeF textSize = g.MeasureString(text, font);
                            System.Drawing.RectangleF textBackground = new System.Drawing.RectangleF(point.X - textPadding, point.Y, textSize.Width + 2 * textPadding, textSize.Height);

                            using (Brush textBrush = new SolidBrush(Color.Black))
                            using (Brush bgBrush = new SolidBrush(Color.FromArgb(127, color))) // semi-transparent background
                            using (Pen pen = new Pen(color, 2))
                            {
                                g.FillRectangle(bgBrush, textBackground);
                                g.DrawString(text, font, textBrush, point);
                                g.DrawRectangle(pen, x, y, width, height);
                            }
                        }
                        if (!text.Contains(NG_TEXT, StringComparison.OrdinalIgnoreCase))
                        {
                            System.Drawing.PointF point = new System.Drawing.PointF(x + textPadding, y - font.Height - textPadding);
                            SizeF textSize = g.MeasureString(text, font);
                            System.Drawing.RectangleF textBackground = new System.Drawing.RectangleF(point.X - textPadding, point.Y, textSize.Width + 2 * textPadding, textSize.Height);

                            using (Brush textBrush = new SolidBrush(Color.Black))
                            using (Brush bgBrush = new SolidBrush(Color.FromArgb(127, color))) // semi-transparent background
                            using (Pen pen = new Pen(color, 2))
                            {
                                g.FillRectangle(bgBrush, textBackground);
                                g.DrawString(text, font, textBrush, point);
                                g.DrawRectangle(pen, x, y, width, height);
                            }
                        }
                    }
                }
            }
        }


        public static Bitmap? DrawImage(Image image, Prediction[] predictions, string labelName)
        {
            if (image == null || predictions == null) return null;

            var pred = predictions.FirstOrDefault(x => x.Label.Name.Replace("_ok", "").Replace("_OK", "").Replace("_ng", "").Replace("_NG", "").Contains(labelName, StringComparison.OrdinalIgnoreCase));
            if (pred != null)
            {
                var originalImageHeight = image.Height;
                var originalImageWidth = image.Width;

                var x = Math.Max(pred.Rectangle.X, 0);
                var y = Math.Max(pred.Rectangle.Y, 0);
                var width = Math.Min(originalImageWidth - x, pred.Rectangle.Width);
                var height = Math.Min(originalImageHeight - y, pred.Rectangle.Height);

                Bitmap bmp = new Bitmap((int)width, (int)height);
                using (Graphics graphics = Graphics.FromImage(bmp))
                {
                    graphics.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), new Rectangle((int)x, (int)y, (int)width, (int)height), GraphicsUnit.Pixel);
                }
                return bmp;
            }
            return null;
        }

    }
}
