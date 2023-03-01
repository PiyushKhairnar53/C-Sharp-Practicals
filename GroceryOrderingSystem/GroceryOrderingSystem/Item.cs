using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GroceryOrderingSystem
{
    public class Item
    {
        int item_id;
        int item_price;
        string? item_name;
        int item_qty;
        string? unit_of_measure;


        public int ItemId // property
        {
            get { return item_id; }   // get method
            set { item_id = value; }  // set method
        }

        public int ItemPrice // property
        {
            get { return item_price; }   // get method
            set { item_price = value; }  // set method
        }

        public string ItemName // property
        {
            get { return item_name; }   // get method
            set { item_name = value; }  // set method
        }

        public string UnitOfMeasure // property
        {
            get { return unit_of_measure; }   // get method
            set { unit_of_measure = value; }  // set method
        }

        public int ItemQty // property
        {
            get { return item_qty; }   // get method
            set { item_qty = value; }  // set method
        }


    }
}
