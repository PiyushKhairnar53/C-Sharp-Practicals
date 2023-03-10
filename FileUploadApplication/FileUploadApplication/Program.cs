namespace FileUploadApplication
{
    internal class FileUploadClass
    {
        public static void Main(string[] args) 
        {

            MultipleFiles multipleFiles = new MultipleFiles();
            multipleFiles.CopyMultipleFiles();

            FileUploadProgress fileUploadProgress = new FileUploadProgress();
            fileUploadProgress.FileUploadProgressMethod();

        } 
    }
}