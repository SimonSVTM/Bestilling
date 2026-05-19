using Bestilling.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bestilling.Core.Repositories
{
    public class InMemoryMenuRepository : IMenuRepository
    {
        private readonly List<MenuItem> _menuitems = new List<MenuItem>();
        private int _nextId = 0;

        public MenuItem GetById(int id)
        {
            var item = _menuitems.FirstOrDefault(p => p.Id == id);

            if (item == null)
            {
                throw new ArgumentException("Menu genstand ikke fundet!");
            }
        
            return item;
        }

        public IEnumerable<MenuItem> GetAll()
        {
            return _menuitems;
        }

        public void Add(MenuItem menuItem)
        {
            menuItem.Id = _nextId++;
            _menuitems.Add(menuItem);
        }

        public void Update(MenuItem menuItem)
        {
            var existingMenuItem = _menuitems.FirstOrDefault(p => p.Id == menuItem.Id);
            if (existingMenuItem != null)
            {
                existingMenuItem.Name = menuItem.Name;
            }
        }

        public void Delete(int id)
        {
            _menuitems.RemoveAll(p => p.Id == id);
        }

        public IEnumerable<MenuItem> SearchByName(string search)
        {
            return _menuitems
                .Where(item => item.Name.Contains(search,
                    StringComparison.OrdinalIgnoreCase));
        }
    }
}
