using SevenFoodApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SevenFoodApp.Util.Enums;

namespace SevenFoodApp.Repository
{
    internal class FoodRepository : ARepository<Food>
    {
        RestaurantRepository restaurantRepository;
        public FoodRepository(CONTEXT context) : base(context) { 
            this.restaurantRepository = new RestaurantRepository(CONTEXT.RESTAURANT);
        }

        public override Food? StringToObject(string _food)
        {
            try
            {
                string[] values = _food.Split(";");
                
                int id = int.Parse(values[0]);
                string name = values[1];
                double price = double.Parse(values[2]);
                int idRestaurant = int.Parse(values[3]);
                
                Restaurant? restaurant = this.restaurantRepository.GetById(idRestaurant);
                if (restaurant == null)
                {
                    throw new Exception("Restaurant Inexistente");
                }

                bool status = bool.Parse(values[4]);

                Food food = new Food(id, name, price, restaurant, status);
                return food;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public override string ToString(Food food)
        {
            return $"{food.Id};{food.Description};{food.Price};{food.Restaurant.Id};{food.Status}";
        }
    }
}
