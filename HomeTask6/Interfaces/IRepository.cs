using HomeTask6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask6.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Save(T catalog);
        T Load();
    }
}
