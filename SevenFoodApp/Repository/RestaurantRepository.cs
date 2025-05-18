using SevenFoodApp.Interfaces;
using SevenFoodApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SevenFoodApp.Util.Enums;

namespace SevenFoodApp.Repository
{
    internal class RestaurantRepository : ARepository<Restaurant>
    {

        public RestaurantRepository(CONTEXT context) : base(context) { }

        public override Restaurant? StringToObject(string _user)
        {
            try
            {
                string[] values = _user.Split(",");
                int id = int.Parse(values[0]);
                string name = values[1];
                bool active = bool.Parse(values[2]);
                Restaurant restaurant = new Restaurant(id, name, active);
                return restaurant;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public override string ToString(Restaurant restaurant)
        {
            return $"{restaurant.Id},{restaurant.Name},{restaurant.Active}";
        }
    }
}
