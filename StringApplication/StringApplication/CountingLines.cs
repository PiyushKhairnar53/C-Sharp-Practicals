
using System;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace StringApplication
{
    internal class StringFuctions 
    {
        string? enterString;

        public void CountLines() 
        {

            Console.WriteLine("Counting lines \nPlease enter input : ");
            enterString = Console.ReadLine();
            enterString!.ToLower();

//            char function = @"\." + " ";

            int spaceCount = enterString.Count(s => (s == '.' && s++ == ' '));
            Console.WriteLine("\nNumber of lines:" + spaceCount);



            //int result=0;

            //try
            //{
            //    result = Regex.Matches(enterString,"^((?:\\d+(?:\\.\\d+)*|[A-Z]+))\\.\\s+(.+)\r\n").Count + 1;
            //    result = result + Regex.Matches(enterString, @"\? " + @"\s+").Count + 1;
            //    result = result + Regex.Matches(enterString, @"\! " + @"\s+").Count + 1;
            //}
            //catch { }

            //Console.WriteLine("\nNumber of new lines:" + result);

            int count = 0;

            for (int i = 0; i < enterString!.Length; i++)
            {
                if (i == enterString.Length - 1)
                {
                    if (enterString[i] == '.' || enterString[i] == '?' || enterString[i] == '!')
                    {
                        count++;
                    }
                }

                else if (enterString[i] == '.' && enterString[i + 1] == ' ')
                {
                    count++;
                }

                else if (enterString[i] == '?' && enterString[i + 1] == ' ')
                {
                    count++;
                }

                else if (enterString[i] == '!' && enterString[i + 1] == ' ')
                {
                    count++;
                }
            }
            Console.WriteLine("\nNumber of new lines:" + count);
        }

        public void ReverseWords()
        {

            Console.WriteLine("Reverse of words in Line \nPlease enter : ");
            enterString = Console.ReadLine();
            enterString.ToLower();

            string result = string.Join(" ", enterString
            .Split(' ')
            .Select(x => new String(x.Reverse().ToArray())));
            Console.WriteLine(result);

        }

        public void RemoveDuplicates() 
        {
            Console.WriteLine("Remove duplicates \nPlease enter : ");
            
            enterString = Console.ReadLine();
            enterString.ToLower();

            var uniqueCharArray = enterString.ToCharArray().Distinct().ToArray();
            var resultString = new string(uniqueCharArray);
            Console.WriteLine("String After Removing Duplicate Characters: " + resultString);
        }

        public void LongestCommonPrefix()
        {
            Console.WriteLine("Longest Common Prefix \nPlease enter input : ");  
            enterString = Console.ReadLine();
            string[] wordsArr = enterString!.Split(" ");

            var longestCommonPrefix = Enumerable.Range(1, wordsArr.Max(_ => _)!.Length)
            .Select(i =>
            {
                var grouped = wordsArr.Where(x => x.Length >= i)
                    .GroupBy(x => x[..i])
                    .Where(x => x.Count() > 1)
                    .OrderByDescending(x => x.Count())
                    .Select(x => new { LongestCommonPrefix = x.Key })
                    .FirstOrDefault();

                return grouped?.LongestCommonPrefix ?? string.Empty;
            }).Max();

            Console.WriteLine("Longest common prefix : "+longestCommonPrefix);
        }
    }
}
