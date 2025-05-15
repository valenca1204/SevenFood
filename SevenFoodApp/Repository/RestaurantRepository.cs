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
    internal class RestaurantRepository //: //IRepository<Restaurant>
    {
        private const string PATH_FILE_ID = "ids.txt";
        private const string PATH_FILE_RESTAURANT = "restaurants.txt";

        public RestaurantRepository()
        {
            if (!File.Exists(PATH_FILE_RESTAURANT))
                File.WriteAllText(PATH_FILE_RESTAURANT, "");
        }

        public int getLastId()
        {
            var ids = File.ReadAllLines(PATH_FILE_ID);
            return int.Parse(ids.Last());
        }

        private void setLastId(int id)
        {
            File.WriteAllText(PATH_FILE_ID, id.ToString());
        }

        private Restaurant? CastFromString(string _user)
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
        private string toString(Restaurant restaurant)
        {
            return $"{restaurant.Id},{restaurant.Name},{restaurant.Active}";
        }        

        public bool Delete(int id)
        {
            try
            {
                List<string> _users = File.ReadAllLines(PATH_FILE_RESTAURANT).ToList();
                int i = 0;

                for (i = 0; i < _users.Count(); i++)
                {
                    Restaurant? restaurant = this.CastFromString(_users[i]);

                    if ((restaurant != null) && (restaurant.Id == id))
                        break;

                }

                if (i > 0)
                    _users.RemoveAt(i);

                File.WriteAllLines(PATH_FILE_RESTAURANT, _users);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
        }

        public List<Restaurant> GetAll()
        {
            List<Restaurant> list = new List<Restaurant>();
            try
            {
                string[] _restaurants = File.ReadAllLines(PATH_FILE_RESTAURANT);
                foreach (string _restaurant in _restaurants)
                {
                    Restaurant? restaurant = this.CastFromString(_restaurant);
                    if (restaurant != null)
                        list.Add(restaurant);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return list;
        }

        public Restaurant? GetById(int id)
        {
            try
            {
                string[] _restaurants = File.ReadAllLines(PATH_FILE_RESTAURANT);
                foreach (string _restaurant in _restaurants)
                {
                    Restaurant? restaurant = this.CastFromString(_restaurant);

                    if ((restaurant != null) && (restaurant.Id == id))
                        return restaurant;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Insert(Restaurant entity)
        {
            try
            {
                string restaurant = this.toString(entity);
                File.AppendAllText(PATH_FILE_RESTAURANT, $"{restaurant}\n");
                this.setLastId(entity.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Restaurant entity)
        {
            try
            {
                string[] _restaurants = File.ReadAllLines(PATH_FILE_RESTAURANT);

                for (int i = 0; i < _restaurants.Length; i++)
                {
                    Restaurant? restaurant = this.CastFromString(_restaurants[i]);

                    if ((restaurant != null) && (restaurant.Id == entity.Id))
                    {
                        _restaurants[i] = this.toString(entity);
                    }
                }
                File.WriteAllLines(PATH_FILE_RESTAURANT, _restaurants);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
        }
    }
}
