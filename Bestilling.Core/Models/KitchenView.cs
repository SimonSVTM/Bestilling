using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Bestilling.Core.Models
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

        private bool endOrder(int tableId)
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
            return ended;
        }

        private void printCurrentOrders()
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

        public void Start()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("=== Kitchen View ===");
                Console.WriteLine("1. Vis Bestillinger");
                Console.WriteLine("2. Afslut Bestilling");
                Console.WriteLine("0. Exit");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        printCurrentOrders();
                        Console.WriteLine("Tryk Enter for at afslutte.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        Console.WriteLine("Bordnummer:");
                        int tableid = int.Parse(Console.ReadLine());
                        bool ended = endOrder(tableid);
                        Console.Clear();
                        if (ended)
                            Console.WriteLine($"Bordnummer {tableid} sendt til afregning.");
                        else
                            Console.WriteLine($"Bordnummer {tableid} har ingen bestillinger.");
                        break;

                    case "0":
                        running = false;
                        Console.Clear();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice.");
                        
                        break;
                }
            }
        }
    }
}
