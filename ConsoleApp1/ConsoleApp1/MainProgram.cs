// See https://aka.ms/new-console-template for more information

using System;
using ConsoleApp1;

namespace project
{
	internal class MainProgram
	{

		static void Main(string[] args)
		{
			Console.WriteLine("Enter a string - ");

			string var = Console.ReadLine();
			Console.WriteLine($"Entered string - {var}");

			Console.WriteLine("Enter char for ascii value");
			int var2 = Console.Read();
			Console.WriteLine($"Ascii string - {var2}");

			Console.WriteLine("Enter char for readkey");
			ConsoleKeyInfo var3 = Console.ReadKey();
			Console.WriteLine();
			Console.WriteLine($"Key pressed - {var3.Key} and Ascii string - {(int)var3.KeyChar}");


			DataTypes cl = new DataTypes();
			cl.print();

			EnumProgram ep = new EnumProgram();
			ep.getEnum();

			Console.WriteLine();

			TypeCasting ts = new TypeCasting();
			ts.cast(323.03f);

			Loops lps = new Loops();
			lps.doWhile();
			lps.whileLoop();
			lps.forLoops();

			ControlStmts cs = new ControlStmts();
			cs.ifElse(10);
			cs.switchExample(0);
			cs.switchExample(1);
			cs.gotoExample();
			Console.WriteLine("Enter number to skip - ");
			string st = Console.ReadLine();
			int no = Convert.ToInt32(st);
			cs.continueExample(no); 
			

		}

	}
}
