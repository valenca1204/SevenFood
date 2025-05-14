using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SevenFoodApp.Util.Enums;

namespace SevenFoodApp.Model
{
    internal class User : People
    {
        public User(int id, string name, string password, TYPE_USER type = TYPE_USER.Client) 
            : base(id, name, password, type) { }

    }
}
