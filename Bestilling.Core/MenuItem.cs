using System;
using System.Collections.Generic;
using System.Text;

namespace Bestilling.Core
{

    public class MenuItem
    {
        private int id;
        private string name;
        private float price;
        public int Id { get => id; set { id = value; } }
        public string Name { get => name; set { name = value; } }
        public float Price { get => price; }

        public MenuItem(string name, float price)
        {
            this.name = name;   
            this.price = price;
        }

        override
        public string ToString()
        {
            return id.ToString() + ": " + name;
        }
    }
}
