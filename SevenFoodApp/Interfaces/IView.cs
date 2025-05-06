using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.Interfaces
{
    internal interface IView<T>
    {
        T? add();
        void show(T obj);
        void showAll(List<T> objs);
        bool remove(int id);


    }
}
