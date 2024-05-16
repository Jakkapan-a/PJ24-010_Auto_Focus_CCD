using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ24_010_Auto_Focus_CCD.Utilities
{
    public static class CopyFile
    {
        public static async Task CopyFileWithProgressAsync(string sourcePath, string destinationPath, IProgress<int> progress)
        {
            byte[] buffer = new byte[1024 * 1024]; // 1MB buffer
            int bytesRead;
            long totalBytesRead = 0;

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                long fileSize = sourceStream.Length;

                using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                {
                    while ((bytesRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        byte[] tempBuffer = new byte[bytesRead];
                        Buffer.BlockCopy(buffer, 0, tempBuffer, 0, bytesRead);
                        await destinationStream.WriteAsync(tempBuffer, 0, bytesRead);

                        totalBytesRead += bytesRead;

                        int progressPercentage = (int)(((double)totalBytesRead / fileSize) * 100);
                        progress.Report(progressPercentage);
                    }
                }
            }
        }
    }
}
