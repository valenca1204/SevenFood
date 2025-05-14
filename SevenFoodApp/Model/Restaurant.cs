using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.Model
{
    internal class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public Restaurant(int id, string name, bool active = true) { 
            this.Id = id;
            this.Name = name;
            this.Active = active;
        }
    }
}
