using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GroceryOrderingSystem
{

    public class UserGrocery
    {
        int userId,item_id;
        string? fName, lName, contNo, address, item_name;

        int totalQty;
        int totalAmt;
        static int totalBill;
        int itemId = 0;
        string? itemName;
        public static AdminGrocery ag = new AdminGrocery();
        List<Item> mList = ag.GiveList();

        public void GetUserDetails() 
        {

            CheckDetail("fName");
            CheckDetail("lName");
            CheckDetail(1);
            CheckDetail("address");

            Console.WriteLine("First name - "+fName);
            Console.WriteLine("Last name - " + lName);
            Console.WriteLine("Contact no - " + contNo);
            Console.WriteLine("Address - " + address);

            AddToCart();


        }

        private void AddToCart() 
        {
            string? valid;
            do
            {
                Console.WriteLine("Enter item no or name you want to add to cart : ");
                string? input = Console.ReadLine();
                AddSingleItem(input!);

                Console.WriteLine("Do you want to add one more product (y/Y or n/N) : ");
                valid = Console.ReadLine();

            } while (valid == "y" || valid == "Y" || valid == "Yes" || valid == "yes" || valid == "YES");


            string? checkout;

            Console.WriteLine("Do you want to checkout (y/Y/yes) or (n/N/No) : ");
            checkout = Console.ReadLine();

            if(checkout == "y" || checkout == "Y" || checkout == "yes" || checkout == "Yes" || checkout == "YES")
            {
                Console.WriteLine("Order out for delivery to you location : "+address);
                
            }

            if (checkout == "n" || checkout == "N" || checkout == "no" || checkout == "No" || checkout == "NO")
            {
                Console.WriteLine("Order is dissmissed ");

            }

        }

        public void CheckDetail(int contact) 
        {
            if(contact == 1) {
                GetContact();
            }

        }

        public void CheckDetail(string type) 
        {

            bool? valid;
            if (type == "fName")
            {
                do
                {
                    Console.WriteLine("First name - ");
                    fName = Console.ReadLine();
                    valid = String.IsNullOrWhiteSpace(fName);

                } while (valid == true);

            }

            if (type == "lName")
            {
                do
                {
                    Console.WriteLine("Last name - ");
                    lName = Console.ReadLine();
                    valid = String.IsNullOrWhiteSpace(lName);

                } while (valid == true);

            }

            if (type == "address")
            {
                do
                {
                    Console.WriteLine("Address - ");
                    address = Console.ReadLine();
                    valid = String.IsNullOrWhiteSpace(address);

                } while (valid == true);

            }

        }

        public void AddSingleItem(string input) 
        {

           

            string finalType = "String";
            if (!string.IsNullOrEmpty(input))
            {

                // Check integer before Decimal
                int tryInt;
                if (Int32.TryParse(input, out tryInt))
                {
                    finalType = "Integer";
                }
                else
                {
                    finalType = "String";

                }

            }

            Console.WriteLine(finalType);



            if (finalType == "Integer")
            {

                foreach (Item i in mList)
                {
                    if (i.ItemId == Convert.ToInt32(input))
                    {
                        Console.WriteLine("Enter qty - ");
                        totalQty = Convert.ToInt32(Console.ReadLine());
                        totalAmt = i.ItemPrice * totalQty;
                        Console.WriteLine("Amount = " + totalAmt);
                        totalBill = totalBill + totalAmt;
                        Console.WriteLine("Bill = " + totalBill);
                        break;
                    }
                }
            }
            string? valid = "false";
            if (finalType == "String")
            {

                    if (input == "Cinthol" || input == "Sugar" || input == "Dettol" || input == "Peanuts" || input == "Shampoo" || input == "Wheat")
                    {

                        foreach (Item i in mList)
                        {
                            if (i.ItemName == input)
                            {
                                Console.WriteLine("Enter qty - ");
                                totalQty = Convert.ToInt32(Console.ReadLine());
                                totalAmt = i.ItemPrice * totalQty;
                                Console.WriteLine("Amount = " + totalAmt);
                                totalBill = totalBill + totalAmt;
                                Console.WriteLine("Amount = " + totalBill);
                                valid = "true";
                                break;
                            }
                        }
                    }
                    else {
                        Console.WriteLine("You have enter wrong input please re enter - ");
                    }
                
            } 
        }

        public void GetContact()
        {

            string valid;
            do
            {

                Console.WriteLine("Please enter a valid Contact No : ");
                contNo = Console.ReadLine();

                bool isContNo = Regex.IsMatch(contNo!, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", RegexOptions.IgnoreCase);
                valid = isContNo ? "true" : "false";

            } while (valid == "false");

        }

        //public int getDetail(int detail)
        //{

        //    do
        //    {
        //        item = Convert.ToInt32(Console.ReadLine());
        //    } while (item == 0 || item == null);

        //    return item;

        //}

        public string checkItem(string? item)
        {

            if (item == null)
            {
                do
                {
                    Console.WriteLine("Enter Valid first name : ");
                    item = Console.ReadLine();
                } while (item == null);

            }
            return item;
        }

    }

}
