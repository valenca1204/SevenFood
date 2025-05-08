using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.Interfaces
{
    internal interface IRepository<T>
    {
        T GetById(int id);
        T GetAll();
        bool Update(T entity);
        bool Delete(int id);
        void Insert(T entity);
    }
}
