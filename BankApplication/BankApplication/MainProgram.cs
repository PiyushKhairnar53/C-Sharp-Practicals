﻿using System.Text;

namespace BankApplication
{
    public class Bank 
    {
        static UserDetails? userDetails;
        static BankOperations? bankDetails ;
        public static void Main(string[] args)
        {
            string? newUser;
            do
            {
                userDetails = new UserDetails();
                bankDetails = new BankOperations();
                Console.WriteLine("Welcome to ABC Bank \nFor creating new Bank Account please enter following details ");
                userDetails.GetDetails();
                bankDetails.GetBankDetails();

                ShowUserDetails();
                ShowBankDetails();


                Console.WriteLine("Do you want to create new user (y/Y or n/N) : ");
                newUser = Console.ReadLine();
                newUser!.ToLower();

            } while (newUser == "y" || newUser == "yes");
        }
        public static void ShowUserDetails()
        {
            for (int i = 0; i < 100;i++) 
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.WriteLine("\nDetails of the user -> ");
            Console.WriteLine("User id : "+userDetails!.userId);
            Console.WriteLine("First Name : "+userDetails.firstName);
            Console.WriteLine("Last Name : "+userDetails.lastName);
            Console.WriteLine("Email id : "+userDetails.email);
            Console.WriteLine("Contact number : "+userDetails.contactNumber);
            Console.WriteLine("Gender : "+userDetails.gender);
            Console.WriteLine("Maritual status : "+userDetails.maritualStatus);
            if (userDetails.maritualStatus == "married")
            {
                Console.WriteLine("Name of spouse : " + userDetails.spouseName);
                Console.WriteLine("Does user have childs : " + userDetails.haveChilds);
                if (userDetails.haveChilds)
                {
                    Console.WriteLine("Number of childerns have : " + userDetails.numberOfChilds);
                    if (userDetails.haveChilds == true)
                    {
                        foreach (string nm in userDetails.childNames!)
                        {
                            int i = 1;
                            Console.WriteLine($"Name of child {i} : " + nm);
                        }
                    }
                }
            }
        }

        public static void ShowBankDetails()
        {
            Console.WriteLine("\nBank details entered by user - ");
            Console.WriteLine("Autogenerated Bank Account Number : "+bankDetails!.accountNumber);
            Console.WriteLine("Permanant address : "+bankDetails.permanantAddress);
            Console.WriteLine("Communication address : "+bankDetails.communicationAddress);
            Console.WriteLine("Does user want credit card : " + bankDetails.wantCreditCard);
            if (bankDetails.wantCreditCard)
            {
                Console.WriteLine("Upto Credit allowed : " + bankDetails.creditAllowed);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bankDetails.creditCardNumber!.Length; i++)
                {
                    if (i % 4 == 0)
                        sb.Append(' ');
                    sb.Append(bankDetails.creditCardNumber[i]);
                }
                string crdNo = sb.ToString(); 
                Console.WriteLine("Credit card number : " + crdNo);
            }

            bankDetails.UpdateBalacne();
        }

    }

}
