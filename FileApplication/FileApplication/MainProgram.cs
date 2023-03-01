namespace FileApplication
{
    public class FileMain
    {

        public static void Main()
        {
            string? wantToChangeFile;
            do
            {
                FileOperations fileOperations = new FileOperations();
                fileOperations.CreateNewFile();

                Console.WriteLine("\nDo you want to Create file again (y/yes or n/no) : ");
                wantToChangeFile = Console.ReadLine().ToLower();
            } while (wantToChangeFile.Equals("y") || wantToChangeFile.Equals("yes"));
        }

    }
}