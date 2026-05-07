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

        public void startNewOrder(int tableId)
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

        public void addToOrder(int menuId) 
        {
            current_order.addMenuItem(menu.GetById(menuId));
        }

        public void sendOrderToKitchen()
        {
            kitchenView.recieveOrder(current_order);
        }
        
    }
}
