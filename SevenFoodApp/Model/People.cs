using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SevenFoodApp.Util.Enums;

namespace SevenFoodApp.Model
{
    internal abstract class People : AModel
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public TYPE_USER Type { get; set; }

        public People(int id, string name, string password, TYPE_USER type = TYPE_USER.Client) : base(id)
        {
            this.Name = name;
            this.Password = password;
            this.Type = type;
        }
    }
}
