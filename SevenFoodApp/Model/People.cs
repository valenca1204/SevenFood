using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.Model
{
    internal abstract class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public People(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }
    }
}
