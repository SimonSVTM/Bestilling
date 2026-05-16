using System;
using System.Collections.Generic;
using System.Text;

namespace Bestilling.Core
{
    public class WaiterView
    {
        private KitchenView kitchenView;
        private Order current_order = new Order(0);
        private InMemoryMenuRepository menu;
        public WaiterView(KitchenView kitchenView, InMemoryMenuRepository menu)
        {
            this.kitchenView = kitchenView;
            this.menu = menu;
        }

        private void startNewOrder(int tableId)
        {
            if (0 < tableId && tableId <= kitchenView.getNumberOftables())
            {
                current_order = new Order(tableId);
            }
            else 
            {
                Console.WriteLine("Ugyldigt bordtal givet.");
            }
            
        }

        private void addToOrder(MenuItem menuItem) 
        {
            current_order.addMenuItem(menuItem);
        }

        private void sendOrderToKitchen()
        {
            kitchenView.recieveOrder(current_order);
        }

        public void Start()
        {
            bool running = true;

            while(running)
            {
                

                Console.WriteLine("=== Waiter View ===");
                Console.WriteLine("1. Start bestilling");
                Console.WriteLine("2. Søg og tilføj Menu");
                Console.WriteLine("3. Send til køkken");
                Console.WriteLine("0. Exit");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Skriv bordnummer:");
                        int tableid = int.Parse(Console.ReadLine());
                        startNewOrder(tableid);
                        Console.Clear();
                        Console.WriteLine("Bestilling oprettet.");
                        break;
                    case "2":
                        Console.WriteLine("Søgefelt: ");
                        string order = Console.ReadLine();
                        int i = 0;
                        IEnumerable<MenuItem> list = menu.SearchByName(order);
                        foreach (MenuItem m in list)
                        {
                            Console.WriteLine((i + 1).ToString() + ": " + m.Name);
                            i += 1;
                        }
                        Console.WriteLine("Vælg menu:");
                        int j = int.Parse(Console.ReadLine());
                        addToOrder(list.ElementAt(j - 1));
                        Console.Clear();
                        Console.WriteLine("Tilføjet til bestilling.");
                        break;
                    case "3":
                        sendOrderToKitchen();
                        Console.Clear();
                        Console.WriteLine("Sendt til køkken.");
                        break;

                    case "0":
                        running = false;
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            }
        }
        
    }
}
