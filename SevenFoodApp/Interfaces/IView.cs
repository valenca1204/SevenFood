using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.Interfaces
{
    internal interface IView
    {
        bool add();
        void show();
        void showAll();
        bool remove();


    }
}
