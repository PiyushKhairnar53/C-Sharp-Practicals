
namespace FileUploadApplication
{
    internal class MultipleFiles
    {

        private static string destinationDir = @"D:\UploadFiles";

        public async Task CopyMultipleFiles()
        {
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }

            Console.WriteLine("Please Enter multiple file path separated by comma  : ");
            string? filePath = Console.ReadLine();
            if (!string.IsNullOrEmpty(filePath!.Trim()))
            {
                string[] fileArray = filePath!.Split(",");
                List<string> fileList = new();
                fileList.AddRange(fileArray);

                List<Task> copyTasks = new List<Task>();
                for (int i = 0; i < fileList.Count; i++)
                {
                    Task task = UploadFile(fileArray[i]);
                    copyTasks.Add(task);
                }

                await Task.WhenAll(copyTasks);
                Console.WriteLine("All files copied successfully");
            }
            Console.WriteLine("\nPlease Enter file path to copy with progress : ");
        }

        public static async Task UploadFile(string filepath)
        {
            FileInfo fileInfo = new FileInfo(filepath);
            string destinationOfFile = Path.Combine(destinationDir, fileInfo.Name);
            using (Stream source = File.OpenRead(filepath))
            {
                using (Stream destination = File.Create(destinationOfFile))
                {
                    await source.CopyToAsync(destination);
                    Console.WriteLine(fileInfo.Name);
                }
            }
        }
    }
}
