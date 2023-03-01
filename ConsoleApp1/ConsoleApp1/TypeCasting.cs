using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TypeCasting
    {

        public void cast(float s) {

            double f1 = s;
            Console.WriteLine("Implicit typecast of "+s+" is - "+f1);

            int b1 = (int)s;
			Console.WriteLine("Explicit typecast of " + s + " is - " + b1);

			string str = "12345";
            int n = Convert.ToInt32(str);
            Console.WriteLine("String to int - "+n);
            Console.WriteLine();

		}

	}
}
