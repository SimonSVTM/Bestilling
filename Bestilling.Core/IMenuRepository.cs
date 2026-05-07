using System;
using System.Collections.Generic;
using System.Text;

namespace Bestilling.Core
{
    public interface IMenuRepository
    {
        MenuItem GetById(int id);
        IEnumerable<MenuItem> GetAll();
        void Add(MenuItem person);
        void Update(MenuItem person);
        void Delete(int id);
    }
}
