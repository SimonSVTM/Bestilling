using System;
using System.Collections.Generic;
using System.Text;

namespace Bestilling.Core
{
    public class CashierView
    {
        private int numberOftables;
        private List<Order> preparedOrders = new List<Order>();
        public CashierView(int numberOftables) 
        { 
            this.numberOftables = numberOftables;
        }

        public int getNumberOfTables()
        {
            return numberOftables; 
        }

        public void receiveOrder(Order order)
        {
            preparedOrders.Add(order);
        }

        public void finishOrder(int tableId)
        {
            bool ended = false;
            foreach (Order order in preparedOrders)
            {
                if (order.TableID == tableId)
                {
                    ended = true;
                    preparedOrders.Remove(order);
                    break;
                }
            }
            if (!ended)
            {
                Console.WriteLine("Ordre ikke fundet!");
            }
        }
    }
}
