using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringApplication
{
    internal class StringMethodsClass
    {

        public void StringMethods() 
        {
            string? inputString1,input;
            int inputNumber;

            do
            {
                Console.WriteLine("String Methods\nPlease enter input : ");
                inputString1 = Console.ReadLine();

                Console.WriteLine("1.Upper\n2.Lower\n3.Length\n4.Replace\n5.SubString\n6.Split\n7.Trim\n8.Exit");
                
                Console.WriteLine("Please enter method number : ");
                input = Console.ReadLine();
                bool inputIsNumber = Int32.TryParse(input, out inputNumber);
                if (inputIsNumber && inputNumber > 0)
                {
                    input = inputNumber.ToString();
                }

                switch (input)
                {
                    case "1":
                    case "upper":
                        Console.WriteLine($"Uppercase: {inputString1.ToUpper()}");
                        break;


                    case "2":
                    case "lower":
                        Console.WriteLine($"Lowercase: {inputString1.ToLower()}");
                        break;

                    case "3":
                    case "length":
                        Console.WriteLine($"Length: {inputString1.Length}");
                        break;

                    case "4":
                    case "replace":
                        Console.WriteLine(inputString1);
                        Console.Write("Enter a replacement string: ");
                        string inputString2 = Console.ReadLine();
                        Console.WriteLine($"Replace(\"{inputString1}\", \"{inputString2}\"): {input.Replace(inputString1, inputString2)}");
                        break;

                    case "5":
                    case "substring":
                        Console.Write("Enter starting index : ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter a length: ");
                        int length = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"SubString({index}, {length}) : {input.Substring(index, length)}");
                        break;
                    
                    case "6":   
                    case "split":
                        Console.Write("Enter delimiter: ");
                        string? delimiterString = Console.ReadLine();
                        char[] delimiterArr = delimiterString!.ToCharArray();
                        string[] split = inputString1.Split(delimiterArr);
                        Console.Write("Split:");
                        foreach (string spl in split)
                        {
                            Console.Write($" \"{spl}\"");
                        }
                        Console.WriteLine();
                        break;

                    case "7":
                    case "trim":
                        Console.WriteLine($"Trim: \"{inputString1.Trim()}\"");
                        break;

                    case "8":
                    case "exit":
                        return;

                    default:
                        Console.WriteLine("Invalid string method.");
                        break;
                }


            } while (inputString1!.Length>0);
            
        }

    }
}
