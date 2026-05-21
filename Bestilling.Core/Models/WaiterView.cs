using Bestilling.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bestilling.Core.Models
{
    public class WaiterView
    {
        private string waiterName;
        private KitchenView kitchenView;
        private Order current_order = new Order(0);
        private InMemoryMenuRepository menu;
        private bool startedNewOrder = false;
        public WaiterView(KitchenView kitchenView, InMemoryMenuRepository menu, string name)
        {
            this.kitchenView = kitchenView;
            this.menu = menu;
            waiterName = name;
        }

        private void startNewOrder()
        {
            
            current_order = new Order(kitchenView.getWaiterAssignment(waiterName));
            startedNewOrder = true;
        }

        private bool editOrder(int tableID)
        {
            Order order = kitchenView.findOrder(tableID);
            if (order != null) {
                current_order = order;
                startedNewOrder = true;
                return true;
            }
            return false;
        }

        private void addToOrder(MenuItem menuItem) 
        {
            
            current_order.addMenuItem(menuItem);
            
            
        }

        private void sendOrderToKitchen()
        {
            kitchenView.recieveOrder(current_order);
            startedNewOrder = false;
        }

        public bool Start()
        {
            
            bool running = true;
            bool loggedIn = true;
            while(running)
            {
                

                Console.WriteLine("=== Waiter View ===");
                Console.WriteLine("1. Start ny bestilling");
                Console.WriteLine("2. Rediger Bestilling");
                Console.WriteLine("3. Søg og tilføj Menu");
                Console.WriteLine("4. Send til køkken");
                Console.WriteLine("5. Log af");
                Console.WriteLine("0. Exit");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        try
                        {
                            startNewOrder();
                            Console.Clear();
                            Console.WriteLine("Ny bestilling oprettet.");
                        }
                            catch (InvalidOperationException ex)
                        {
                            Console.Clear();
                            Console.WriteLine("Opgaven er ikke blevet oprettet.");
                        }
                        
                        
                        break;

                    case "2":
                        Console.WriteLine("Indtast bord nummer:");
                        int tableID = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (editOrder(tableID))
                            Console.WriteLine($"Bord {tableID}'s bestilling redigeres nu");
                        else
                            Console.WriteLine($"Bestlling til bord {tableID} ikke fundet.");
                        break;
                    case "3":
                        if (startedNewOrder)
                        {
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
                            // 3. Brug int.TryParse i stedet for int.Parse for at undgå crash ved bogstaver
                            if (int.TryParse(Console.ReadLine(), out int j) && j > 0 && j <= list.Count())
                            {
                                addToOrder(list.ElementAt(j - 1));
                                Console.Clear();
                                Console.WriteLine("Tilføjet til bestilling.");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Ugyldigt valg. Menuen blev ikke tilføjet.");
                            }
                        }
                        else { 
                            Console.Clear();
                            Console.WriteLine("Ny bestilling ikke startet.");
                        }
                        break;
                    case "4":
                        if (startedNewOrder)
                        {
                            sendOrderToKitchen();
                            Console.Clear();
                            Console.WriteLine("Sendt til køkken.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Ny bestilling ikke startet.");
                        }
                        break;
                    case "5":
                        
                        Console.Clear();
                        running = false;
                        loggedIn = false;
                        Console.WriteLine("Logget af.");
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
            return loggedIn;
        }

        
    }
}
