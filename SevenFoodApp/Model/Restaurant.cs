using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.Model
{
    public class Restaurant : AModel
    {
        public string Name { get; set; }
        public bool Active { get; set; }

        public Restaurant(int id, string name, bool active = true) : base(id) { 
            this.Name = name;
            this.Active = active;
        }
    }
}
