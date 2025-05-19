using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.Interfaces
{
    public interface IView
    {
        void Add();
        void ShowById();
        void ShowAll();
        void Remove();

        void Update();


    }
}
