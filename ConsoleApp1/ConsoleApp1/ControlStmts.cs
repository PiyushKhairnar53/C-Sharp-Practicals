using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ControlStmts
    {

        public void ifElse(int n)
        {
            if (n>0)
            {
                if (n % 2 == 0)
                {
                    Console.WriteLine(n + " is Even number");
                }
                else
                {
                    Console.WriteLine(n + " is Odd number");
                }
            }
            else {
				Console.WriteLine("You have entered wrong value");
			}
		}

        public void switchExample(int n) {

            switch (n) { 
            
                case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
                    Console.WriteLine("Valid number");
                    break;
                case 0:
					Console.WriteLine("Invalid number");
					break;
                default:
					Console.WriteLine("Default");
					break;

			}

        }

        public void gotoExample() 
        {
            Console.WriteLine("Statement 1");
            goto statement4;
			Console.WriteLine("Statement 2");
			Console.WriteLine("Statement 3");

            statement4:
			Console.WriteLine("Statement 4");
			Console.WriteLine("Statement 5");

		}

        public void continueExample(int n) 
        {

            for (int i = 1; i <= 10;i++) 
            {
                if (i == n) {
                    continue;
                }
                Console.WriteLine("No - "+i);
            }
        }


	}
}
