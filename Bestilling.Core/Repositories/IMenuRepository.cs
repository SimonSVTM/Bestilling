using Bestilling.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bestilling.Core.Repositories
{
    public interface IMenuRepository
    {
        MenuItem GetById(int id);
        IEnumerable<MenuItem> GetAll();
        void Add(MenuItem menuItem);
        void Update(MenuItem menuItem);
        void Delete(int id);
    }
}
