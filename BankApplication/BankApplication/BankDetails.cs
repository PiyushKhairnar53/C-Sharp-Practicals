using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    internal class BankDetails
    {
        public string? permanantAddress = "", communicationAddress = "" ;
        public bool wantCreditCard,isAddrSame;
        public int? income,creditAllowed;
        public string? accountNumber = "",creditCardNumber = "";

        public void GetBankDetails()
        {
            GetAddress();   
            GenerateAccountNumber();
            GetCreditDetails();
        }

        public void GetCreditDetails() 
        {
            Console.WriteLine("Do you want credit card (y|Y or n|N) ? : ");
            string? creditCard = (Console.ReadLine()).ToLower();

            if (creditCard == "y" || creditCard == "yes")
            {
                wantCreditCard = true;
                if (wantCreditCard) 
                {
                    Console.WriteLine("Please enter your annual income : ");
                    income = Convert.ToInt32(Console.ReadLine());

                    if (income < 300000) 
                    {
                        Console.WriteLine("Sorry you are not eligible for Credit card");
                    }
                    if (income > 300000 && income <500000)
                    {
                        creditAllowed = 50000;
                        Console.WriteLine("You are allowed to use credit upto : "+creditAllowed);
                    }
                    if (income > 500000 && income <700000)
                    {
                        creditAllowed = 75000;
                        Console.WriteLine("You are allowed to use credit upto : " + creditAllowed);
                    }
                    if (income > 700000)
                    {
                        creditAllowed = 100000;
                        Console.WriteLine("You are allowed to use credit upto : " + creditAllowed);
                    }
                }

                Random random = new();
                var builder = new StringBuilder();

                while (builder.Length < 16)
                {
                    builder.Append(random.Next(10)).ToString();
                }
                creditCardNumber = builder.ToString();
            }
        }

        public void GenerateAccountNumber() 
        {
            Random random = new();
            var builder = new StringBuilder();
            while (builder.Length < 14) 
            {
                builder.Append(random.Next(10)).ToString();
            }
            accountNumber = builder.ToString();
        }

        public void GetAddress()
        {
            do
            {
                Console.WriteLine("Please enter your Permanant address - ");
                permanantAddress = Console.ReadLine();
            } while (permanantAddress!.Length == 0);

            Console.WriteLine("Is your permanant address and communication address same(y|Y or n|N) : ");
            string? answer = (Console.ReadLine()).ToLower();

            if (answer == "y" || answer == "yes")
            {
                isAddrSame = true;
                communicationAddress = permanantAddress;
            }
            if (answer == "n" || answer == "no" ) 
            {
                do
                {
                    isAddrSame = false;
                    Console.WriteLine("Please enter your Communication address - ");
                    communicationAddress = Console.ReadLine();
                } while (communicationAddress!.Length == 0);
            }
        }
    }
}
