using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class EnumProgram
    {
		enum cars { Ford, Tata, Tesla }

		public void getEnum() {

			Console.WriteLine();
			Console.WriteLine("Enum - ");

			foreach (string name in Enum.GetNames(typeof(cars)))
			{
				Console.WriteLine(name);
			}
		}
    }
}
