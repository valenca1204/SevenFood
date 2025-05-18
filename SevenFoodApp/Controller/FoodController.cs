using SevenFoodApp.Model;
using SevenFoodApp.Repository;
using SevenFoodApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SevenFoodApp.Util.Enums;

namespace SevenFoodApp.Controller
{
    internal class FoodController
    {
        FoodRepository repository = new FoodRepository(CONTEXT.FOOD);
        RestaurantRepository restaurantRepository = new RestaurantRepository(CONTEXT.RESTAURANT);

        public bool Add(string name, double price, int idRestaurant)
        {
            try
            {
                int id = this.GetNextId();
                Restaurant? restaurant = this.restaurantRepository.GetById(idRestaurant);
                if (restaurant == null)
                {
                    throw new Exception("Restaurant Inexistente");
                }

                Food food = new Food(id, name, price, restaurant);
                return repository.Insert(food);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Please.GetMessageGenericError());
                return false;
            }
        }

        private int GetNextId()
        {
            return Please.GetNextId();
        }

        public List<Dictionary<string, string>>? getAll()
        {

            List<Food> restaurants = repository.GetAll();

            if (restaurants != null && restaurants.Count() > 0)
            {
                var restaurantsString = new List<Dictionary<string, string>>();

                foreach (var food in restaurants)
                {
                    var userString = this.castObjectToDictionary(food);
                    restaurantsString.Add(userString);
                }
                return restaurantsString;
            }
            return null;
        }

        public Dictionary<string, string>? getById(int id)
        {
            var food = repository.GetById(id);
            return food != null ? this.castObjectToDictionary(food) : null;
        }

        public bool remove(int id)
        {
            return repository.Delete(id);
        }

        internal bool update(int id, string description, int idRestaurant, double price, bool status)
        {
            try
            {
                Restaurant? restaurant = this.restaurantRepository.GetById(idRestaurant);
                if (restaurant == null)
                {
                    throw new Exception("Restaurant Inexistente");
                }

                Food Food = new Food(id, description, price, restaurant, status);
                return repository.Update(Food);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Please.GetMessageGenericError());
                return false;
            }
        }

        private Dictionary<string, string> castObjectToDictionary(Food food)
        {
            var foodString = new Dictionary<string, string>
                {
                    { "id", food.Id.ToString() },
                    { "description",  food.Description },
                    { "price",  food.Price.ToString("C2") },
                    { "restaurant",  $"{food.Restaurant.Id} - {food.Restaurant.Name}" },
                    { "idRestaurant",  food.Restaurant.Id.ToString() },
                    { "status", Please.TranslateFromBool(food.Status) },
                };
            return foodString;
        }
    }
}
