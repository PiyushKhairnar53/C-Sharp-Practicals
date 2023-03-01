using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GroceryOrderingSystem
{
    public class AdminGrocery
    {
        static int item_id;

        public static List<Item> item_list = new List<Item>();

        //public static ArrayList itemList ;
        //public static ArrayList items;

        public AdminGrocery() 
        {
            //items = new ArrayList();

            AddNewItem("Cinthol",50,100,"unit");
            AddNewItem("Sugar", 38, 100,"kg");
            AddNewItem("Dettol", 45, 100,"unit");
            AddNewItem("Peanuts", 120, 100,"kg");
            AddNewItem("Shampoo", 80, 100,"unit");
            AddNewItem("Wheat", 40, 100, "kg");


        }


        private void AddNewItem(string item_name,int item_price,int item_qty,string unit_of_measure)
        {
            //itemList = new ArrayList();

            item_id++;

            var item = new Item();
            item.ItemId = item_id;
            item.ItemName = item_name;
            item.ItemPrice = item_price;
            item.ItemQty = item_qty;
            item.UnitOfMeasure = unit_of_measure;


            item_list.Add(item);
  
        }

        public List<Item> GiveList()
        {
            return item_list;
        }

        public void showList() 
        {
            Console.Write("Item id \tItem name\tItem price\tItem quantity\tUnit of Measure");
            Console.WriteLine();

            foreach (Item i in item_list)
            {
                Console.WriteLine(i.ItemId + "\t\t" + i.ItemName + "\t\t" + i.ItemPrice + "\t\t" + i.ItemQty + "\t\t" + i.UnitOfMeasure);
            }


        }

        public int checkItem(int item) 
        {

            do
            {
                item = Convert.ToInt32(Console.ReadLine());
            } while (item == 0 || item == null);

            return item;

        }

        public string checkItem(string item)
        {

            do
            {
                item = Console.ReadLine();
            } while (item!.Length == 0);

            return item;
        }

    }

}
