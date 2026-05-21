using Bestilling.Core.Models;
using Bestilling.Core.Repositories;

namespace Bestilling.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuItem m1 = new MenuItem("Spaghetti Carbonara", 109);
            MenuItem m2 = new MenuItem("Saltimbocca", 150);
            MenuItem m3 = new MenuItem("Pizza Margherita", 125);
            InMemoryMenuRepository menu = new InMemoryMenuRepository();
            menu.Add(m1);
            menu.Add(m2);
            menu.Add(m3);
            bool loggedIn = false;

            List<string> acceptedWaiterNames = new List<string>() {"Bo", "Lars", "Knud", "Sara", "Mia"};
            
            
            int numberOftables = 10;
            
            CashierView cview = new CashierView(numberOftables);
            KitchenView kview = new KitchenView(cview);
            WaiterView wview = new WaiterView(kview, menu);

            bool running = true;

            while (running)
            {

                Console.WriteLine("=== Restaurant System ===");
                Console.WriteLine("1. Waiter View");
                Console.WriteLine("2. Kitchen View");
                Console.WriteLine("3. Cashier View");
                Console.WriteLine("0. Exit");
                Console.Write("Choose a view: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        string name;
                        if (!loggedIn)
                            Console.WriteLine("Indtast navn på tjener:");
                            name = Console.ReadLine();
                        if (loggedIn || acceptedWaiterNames.Contains(name))
                        {
                            loggedIn = true;
                            Console.Clear();
                            Console.WriteLine("Opening Waiter View...");
                            loggedIn = wview.Start(name);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Forkert navn indtastet");
                        }
                        
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Opening Kitchen View...");
                        kview.Start(); 
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Opening Cashier View...");
                        cview.Start(); 
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
