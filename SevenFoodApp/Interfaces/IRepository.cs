using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.Interfaces
{
    public interface IRepository<T>
    {
        T? GetById(int id);
        List<T> GetAll();
        bool Update(T entity);
        bool Delete(int id);
        bool Insert(T entity);
        T? StringToObject(string str);
        string ToString(T entity);
    }
}
