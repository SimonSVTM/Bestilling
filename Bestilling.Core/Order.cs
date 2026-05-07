using System;
using System.Collections.Generic;
using System.Text;

namespace Bestilling.Core
{
   
    public class Order
    {
        private List<MenuItem> orders = new List<MenuItem>();
        private int tableId;
        public int TableID { get => tableId; }

        public Order(int tableId)
        {
            this.tableId = tableId;
        }

        public void addMenuItem(MenuItem menuItem)
        {
            orders.Add(menuItem);
        }

        override
        public string ToString()
        {
            string str = "Ordre for bord " + tableId.ToString() + ":\n";
            foreach (MenuItem item in orders)
            {
                str += item.ToString() + "\n";
            }
            return str + "\n";
        }





    }
}
