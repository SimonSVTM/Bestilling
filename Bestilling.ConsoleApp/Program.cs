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
            
            Console.WriteLine("Hello, World!");
        }
    }
}
