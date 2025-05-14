using SevenFoodApp.Model;
using SevenFoodApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SevenFoodApp.Util.Enums;

namespace SevenFoodApp.Controller
{
    internal class RestaurantController
    {
        RestaurantRepository repository = new RestaurantRepository();
        public bool Add(string name)
        {
            int id = this.GetNextId();
            Restaurant restaurant = new Restaurant(id, name);
            return repository.Insert(restaurant);
        }

        private int GetNextId()
        {
            return repository.getLastId() + 1;
        }

        public List<Restaurant> getAll()
        {
            return repository.GetAll();
        }

        public Restaurant? getById(int id)
        {
            return repository.GetById(id);
        }

        public bool remove(int id)
        {
            return repository.Delete(id);
        }

        internal bool update(int id, string name, bool isActive)
        {
            Restaurant Restaurant = new Restaurant(id, name, isActive);
            return repository.Update(Restaurant);
        }
    }
}
