
namespace FileApplication
{
    internal class FileOperations
    {
        FileInfo[] Files;
        string? filePath, fileExt;
        string? directoryPath, newFilePath;
        bool dirNotFound = false;

        public void CreateNewFile()
        {
            bool isFileNameValid = true;

            do
            {
                Console.WriteLine("Selecting location.... ");
                GetDirectory();

                if (dirNotFound == false)
                {
                    Console.WriteLine("Please enter name of file you want to create : ");
                    string? inputFileName = Console.ReadLine();

                    if (File.Exists(inputFileName))
                    {
                        Console.WriteLine("File already exists");
                        isFileNameValid = false;
                    }
                    else
                    {
                        GetFile();
                        if (fileExt.Equals(".txt"))
                        {
                            newFilePath = directoryPath + inputFileName + ".txt";
                            try
                            {
                                File.Copy(filePath!, newFilePath);
                                ReplaceWord();

                                var lastLine = File.ReadLines(newFilePath).Last();
                                Console.WriteLine("\nLast line of " + newFilePath + " :");
                                Console.WriteLine(lastLine);

                                isFileNameValid = true;
                            }
                            catch (UnauthorizedAccessException unAuthException)
                            {
                                Console.WriteLine(unAuthException.Message);
                            }
                            catch (Exception excption)
                            {
                                Console.WriteLine(excption.Message);
                            }
                        }
                        else 
                        {
                            Console.WriteLine("You entered wrong file");
                        }
                    }
                }
            } while (isFileNameValid == false);
        }

        public void ReplaceWord() 
        {
            Console.WriteLine("\n"+File.ReadAllText(newFilePath!));
            Console.WriteLine("\nPlease enter word to which you want to replace : ");
            string? oldWord = Console.ReadLine();
            oldWord = " " + oldWord + " ";

            Console.WriteLine("Please enter new word to replace : ");
            string? newWord = Console.ReadLine();
            newWord = " " + newWord + " ";

            string strFile = File.ReadAllText(newFilePath!);
            strFile = strFile.Replace(oldWord!, newWord);

            File.WriteAllText(newFilePath!, strFile);
            Console.WriteLine("\nFile after replacement...\n");
            Console.WriteLine(File.ReadAllText(newFilePath!));          
        }

        public void GetDirectory()
        {
            try
            {
                Console.WriteLine(@"Please enter directory name it should be appended by (:\) : ");
                directoryPath = Console.ReadLine();

                if (Directory.Exists(directoryPath))
                {
                    Console.WriteLine("Directory exists");
                    DirectoryInfo place = new DirectoryInfo(directoryPath);
                    Files = place.GetFiles();

                    foreach (FileInfo i in Files)
                    {
                        Console.WriteLine(@"File Name - " + directoryPath + i.Name);
                    }
                }
                Directory.SetCurrentDirectory(directoryPath!);
            }
            catch (DirectoryNotFoundException dirException)
            {
                Console.WriteLine("Directory not found: " + dirException.Message);
                dirNotFound = true;
            }
        }

        public void GetFile()
        {
            try
            {
                Console.WriteLine("Please Enter filename or Drag and Drop a file to copy at new file : ");
                filePath = Console.ReadLine();
                fileExt = System.IO.Path.GetExtension(filePath);

                if (File.Exists(filePath)) 
                {    
                    File.ReadAllLines(filePath);               
                }
            }
            catch (FileNotFoundException fileException)
            {
                Console.WriteLine("File not found: " + fileException.Message);
            }
        }
    }
}
