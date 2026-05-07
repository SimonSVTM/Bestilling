using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Bestilling.Core
{
    
    public class KitchenView
    {
        private List<Order> current_orders = new List<Order>();
        private CashierView cashierView;
        public KitchenView(CashierView cashierView) 
        { 
            this.cashierView = cashierView;
        }

        public void recieveOrder(Order order)
        {
            current_orders.Add(order);
        }

        public void endOrder(int tableId)
        {
            bool ended = false;
            foreach (Order order in current_orders) 
            {
                if (order.TableID == tableId)
                {
                    ended = true;
                    cashierView.receiveOrder(order);
                    current_orders.Remove(order);
                    break;
                }
            }
            if (!ended) 
            {
                Console.WriteLine("Order ikke fundet!");
            }
        }

        public void printCurrentOrders()
        {
            foreach (Order order in current_orders)
            {
                Console.WriteLine(order.ToString());
            }
        }


        public int getNumberOftables()
        {
            return cashierView.getNumberOfTables();
        }
    }
}
