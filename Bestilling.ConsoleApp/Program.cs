using Bestilling.Core;

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
            
            
            
            int numberOftables = 10;
            
            CashierView cview = new CashierView(numberOftables);
            KitchenView kview = new KitchenView(cview);
            WaiterView wview = new WaiterView(kview, menu);

            bool running = true;

            while (running)
            {
                Console.Clear();

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
                        Console.Clear();
                        Console.WriteLine("Opening Waiter View...");
                        wview.Start(); // or wview.Run()
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Opening Kitchen View...");
                        kview.Start(); // or kview.Run()
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Opening Cashier View...");
                        cview.Start(); // or cview.Run()
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

                Console.WriteLine("Hello, World!");
        }
    }
}
