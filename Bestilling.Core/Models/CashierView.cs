using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Bestilling.Core.Models
{
    public class CashierView
    {
        private int numberOfTables;
        public int NumberOfTables { get => numberOfTables;  }
        private List<Order> preparedOrders = new List<Order>();

        private Dictionary<int, string> waiterAssignments = new Dictionary<int, string>();
        public Dictionary<int, string> WaiterAssignments { get => waiterAssignments; }
        public CashierView(int numberOfTables) 
        { 
            this.numberOfTables = numberOfTables;
        }
        

        private void assignWaiter(int tableId, string waiterName)
        {
            if (tableId > 0 && tableId <= numberOfTables)
            {
                waiterAssignments[tableId] = waiterName;
                Console.WriteLine("Opgave Oprettet.");
            }
            else
            {
                Console.WriteLine("Ugyldigt bordtal givet.");
            }
        }

        public void receiveOrder(Order order)
        {
            preparedOrders.Add(order);
        }

        private bool finishOrder(int tableId)
        {
            bool ended = false;
            foreach (Order order in preparedOrders)
            {
                if (order.TableID == tableId)
                {
                    
                    bool payed = credit(order);
                    if (payed)
                    {
                        waiterAssignments.Remove(order.TableID);
                        preparedOrders.Remove(order);
                        ended = true;
                    }
                    break;
                }
            }
            return ended;
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
