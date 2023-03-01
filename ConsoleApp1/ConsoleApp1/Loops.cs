using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Loops
    {

		public void doWhile() {

			int j = 1;
			string ans = "";
			do
			{
				Console.WriteLine("Would you like to exit (y or Y for yes)?");
				ans = Console.ReadLine();

			}while (!(ans == "Y" || ans == "y"));


		}


		public void whileLoop() {
			int i = 1;
			Console.WriteLine("While loop examples - ");
	
			while (i <= 5)
			{
				int j = 1;
				while (j <= 5)
				{
					Console.Write(j++);
				}
				Console.WriteLine();
				i++;
			}

			while (i <= 5) {
                Console.WriteLine(i++);
            }
			Console.WriteLine();

		}

		public void forLoops() 
		{
			Console.WriteLine("For loop examples - ");
			for (int n = 0; ; n++) 
			{
				Console.WriteLine(n);
				if (n == 10) {
					break;
				}
			}

			Console.WriteLine() ;

			for (int i = 1; i <= 5; i++) {

				for (int j = 0; j < i; j++) { 
					Console.Write(j);
				}
				Console.WriteLine() ;	
			}
			Console.WriteLine();

		}
	}
}
