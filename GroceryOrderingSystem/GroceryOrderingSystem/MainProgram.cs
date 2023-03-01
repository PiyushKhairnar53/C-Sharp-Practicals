// See https://aka.ms/new-console-template for more information
using System.Text;

namespace GroceryOrderingSystem
{
    public class MainProgram
    {

        public static void Main(string[] args)
        {

            Console.WriteLine("Welcome to ABC Grocery the products we sell are as follows ->");
            Console.WriteLine();

            AdminGrocery? adminGrocery = new AdminGrocery();
            adminGrocery.showList();

            Console.WriteLine();
            Console.WriteLine("Please enter the following details ->");
            Console.WriteLine();

            UserGrocery user = new UserGrocery();
            user.GetUserDetails();
          

        }
    }

}
