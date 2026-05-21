using System;
using System.Collections.Generic;
using System.Text;

namespace Bestilling.Core.Models
{
    public class CashierView
    {
        

        private KitchenView kitchenView;

        
        public CashierView(KitchenView kitchenView) 
        { 
            this.kitchenView = kitchenView;

        }
        

        private void assignWaiter(int tableId, string waiterName)
        {
            kitchenView.assignWaiter(tableId, waiterName);
        }


        private bool finishOrder(int tableID)
        {
            Order order = kitchenView.findOrder(tableID);
            if (order != null)
            {
                if (credit(order))
                {
                    kitchenView.endOrder(order);
                    return true;
                }
            }
            return false;
        }

        private bool credit(Order order)
        {
            double totalPrice = order.totalPrice();
            Console.WriteLine($"Total price is {totalPrice}");
            Console.WriteLine("Pay now? [Y/N]");
            string ans = Console.ReadLine();
            return (ans.Equals("Y")) ;
                
        }

        public void Start()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("=== Cashier View ===");
                Console.WriteLine("1. Afslut bord");
                Console.WriteLine("2. Opret Tjener Opgave");
                Console.WriteLine("0. Exit");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Bordnummer:");
                        int tableid = int.Parse(Console.ReadLine());
                        bool ended = finishOrder(tableid);
                        Console.Clear();
                        if (ended)
                            Console.WriteLine($"Bordnummer {tableid} afregnet.");
                        else
                            Console.WriteLine($"Bordnummer {tableid} ikke afregnet.");
                        break;

                    case "2":
                        Console.WriteLine("Indtast Bord nummer:");
                        int tableID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Indstast Tjener navn:");
                        string name = Console.ReadLine();
                        
                        Console.Clear();
                        assignWaiter(tableID, name);
                        
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
