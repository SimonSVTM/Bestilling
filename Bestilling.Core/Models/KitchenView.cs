using System;
using System.Collections.Generic;
using System.Text;

namespace Bestilling.Core.Models
{
    
    public class KitchenView
    {
        private List<Order> current_orders = new List<Order>();
        private CashierView cashierView;
        private Dictionary<int, string> waiterAssignments = new Dictionary<int, string>();
        public Dictionary<int, string> WaiterAssignments { get => waiterAssignments; }
        private int numberOfTables;
        public int NumberOfTables { get => numberOfTables; }
        public KitchenView(int numberOfTables) 
        { 
            this.numberOfTables = numberOfTables;
        }

        public void recieveOrder(Order current_order)
        {
            if(!current_orders.Any(order => order.TableID == current_order.TableID))
                current_orders.Add(current_order);
        }

        public void assignWaiter(int tableID, string waiterName)
        {
            if (tableID > 0 && tableID <= numberOfTables)
            {
                waiterAssignments[tableID] = waiterName;
                Console.WriteLine("Opgave Oprettet.");
            }
            else
            {
                Console.WriteLine("Ugyldigt bordtal givet.");
            }
        }

        public Order findOrder(int tableID)
        {
            Order final = null;
            if (tableID > 0 && tableID <= numberOfTables)
            {
                foreach (Order order in current_orders)
                {
                    if (order.TableID == tableID)
                    {
                        final = order;
                        break;
                    }
                }
            }
            return final;
        }
        

        public bool endOrder(Order order)
        {
           
            if (order != null)
            {
                waiterAssignments.Remove(order.TableID);
                current_orders.Remove(order);
                return true;
            }
            return false;
        }

        private void printCurrentOrders()
        {
            foreach (Order order in current_orders)
            {
                Console.WriteLine(order.ToString());
            }
        }

        private void printWaiterAssignments()
        {
            Dictionary<int, string> assignments = waiterAssignments;
            foreach ((int tableID, string waitername) in assignments)
                Console.WriteLine($"{waitername} betjener bord {tableID}");
        }

        public int getLatestWaiterAssignment(string name)
        {
            return waiterAssignments.Last(x => x.Value.Equals(name)).Key;
        }


        public void Start()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("=== Kitchen View ===");
                Console.WriteLine("1. Vis Bestillinger");
                Console.WriteLine("2. Vis Tjener Opgaver");
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
                        Console.WriteLine("");
                        printWaiterAssignments();
                        Console.WriteLine("Tryk Enter for at afslutte.");
                        Console.ReadKey();
                        Console.Clear();
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
