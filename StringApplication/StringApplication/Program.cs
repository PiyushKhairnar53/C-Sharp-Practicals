
namespace StringApplication
{
    public class StringClass
    {
        public static void Main(string[] args)
        {
       
            StringFuctions stringFunctions = new StringFuctions();
            stringFunctions.CountLines();
            stringFunctions.LongestCommonPrefix();
            stringFunctions.RemoveDuplicates();
            stringFunctions.ReverseWords();


            StringMethodsClass stringMethodsClass = new StringMethodsClass();
            stringMethodsClass.StringMethods();

        }
    }
}