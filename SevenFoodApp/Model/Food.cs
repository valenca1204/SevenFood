using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.Model
{
    public class Food : AModel
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
        public Restaurant Restaurant { get; set; }

        public Food(int id, string description, double price, Restaurant restaurant, bool status = true) : base(id) { 
            this.Description = description;
            this.Price = price;
            this.Restaurant = restaurant;
            this.Status = status;
        }
    }
}
