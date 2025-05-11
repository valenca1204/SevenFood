using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.Model
{
    internal class User : People
    {
        public User(int id, string name, string password) : base(id, name, password) { }

    }
}
