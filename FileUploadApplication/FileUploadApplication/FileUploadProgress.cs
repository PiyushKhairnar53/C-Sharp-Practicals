using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using static System.Net.Mime.MediaTypeNames;

namespace FileUploadApplication
{
    internal class FileUploadProgress
    {
        private static string destinationDir = @"D:\UploadFiles\CopyFiles";
        private static string? filePath;

        const char _block = '■';
        const string _back = "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b";

        public void FileUploadProgressMethod() 
        {
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }
           
            filePath = Console.ReadLine();
            
            Task<string> task =  CopyFileAsync(filePath!,destinationDir);
            Task.WhenAll(task);
            Console.WriteLine(task.Result);
        }

        async Task<string> CopyFileAsync(string _source,string destination)
        {
            await Task.Run(() =>
            {
                FileInfo fileInfo = new FileInfo(filePath!);
                string _target = Path.Combine(destinationDir, fileInfo.Name);

                int bufferSize = 1024 * 512;
                using (FileStream inStream = new FileStream(_source, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (FileStream fileStream = new FileStream(_target, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    int bytesRead = -1;
                    var totalReads = 0;
                    var totalBytes = inStream.Length;
                    byte[] bytes = new byte[bufferSize];
                    int prevPercent = 0;

                    while ((bytesRead = inStream.Read(bytes, 0, bufferSize)) > 0)
                    {
                        fileStream.Write(bytes, 0, bytesRead);
                        totalReads += bytesRead;
                        int percent = Convert.ToInt32(((decimal)totalReads / (decimal)totalBytes) * 100);
                        if (percent != prevPercent)
                        {
                            WriteProgressBar(percent, true);
                            prevPercent = percent;
                        }
                    }
                }
            });
            return "\nUpload success";
        }

        public static void WriteProgressBar(int percent, bool update = false)
        {
            if (update)
                Console.Write(_back);
            Console.Write("[");
            var p = (int)((percent / 10f) + .5f);
            for (var i = 0; i < 10; ++i)
            {
                if (i >= p)
                    Console.Write(' ');
                else
                    Console.Write(_block);
            }
            Console.Write("] {0,3:##0}%", percent);
        }
    }
}
