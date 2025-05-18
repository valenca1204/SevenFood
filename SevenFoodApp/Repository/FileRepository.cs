using SevenFoodApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static SevenFoodApp.Util.Enums;

namespace SevenFoodApp.Repository
{
    internal class FileRepository
    {
        private const string PATH_FILE_ID = "ids.txt";
        private const string PATH_FILE_USER = "users.txt";
        private const string PATH_FILE_RESTAURANT = "restaurants.txt";
        private const string PATH_FILE_FOOD = "foods.txt";
        private string PathContext { get; }

        public FileRepository(CONTEXT context)
        {
            this.PathContext = this.getPath(context);
            StartFiles();
        }

        public static void StartFiles()
        {
            if (!File.Exists(PATH_FILE_ID))
                File.WriteAllText(PATH_FILE_ID, "1");

            if (!File.Exists(PATH_FILE_USER))
                File.WriteAllText(PATH_FILE_USER, "1,Dudats,admin,0\n");

            if (!File.Exists(PATH_FILE_RESTAURANT))
                File.WriteAllText(PATH_FILE_RESTAURANT, "");

            if (!File.Exists(PATH_FILE_FOOD))
                File.WriteAllText(PATH_FILE_FOOD, "");
        }

        public static int getLastId()
        {
            var ids = File.ReadAllLines(PATH_FILE_ID);
            return int.Parse(ids.Last());
        }

        public void setLastId(int id)
        {
            File.WriteAllText(PATH_FILE_ID, id.ToString());
        }

        public string getPath(CONTEXT context)
        {
            switch (context)
            {
                case CONTEXT.USER:
                    return PATH_FILE_USER;
                case CONTEXT.RESTAURANT:
                    return PATH_FILE_RESTAURANT;
                case CONTEXT.FOOD:
                    return PATH_FILE_FOOD;
                default:
                    throw new NotImplementedException();
            }
        }

        public string? GetById(int id)
        {
            try
            {
                string[] objects = File.ReadAllLines(this.PathContext);
                foreach (string obj in objects)
                {
                    string[] fields = obj.Split(",");

                    if ((fields.Length > 0) && (fields[0].Equals(id.ToString())))
                        return obj;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Insert(int id, string entityInString)
        {
            try
            {
                File.AppendAllText(this.PathContext, $"{entityInString}\n");
                this.setLastId(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(int id, string entityInString)
        {
            try
            {
                string[] objects = File.ReadAllLines(this.PathContext);

                for (int i = 0; i < objects.Length; i++)
                {
                    string[] obj = objects[i].Split(",");

                    if ((obj.Length > 0) && (obj[0].Equals(id.ToString())))
                    {
                        objects[i] = entityInString;
                    }
                }
                File.WriteAllLines(this.PathContext, objects);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
        }

        public string[] GetAll()
        {
            return File.ReadAllLines(this.PathContext);
        }

        public bool Delete(int id)
        {
            try
            {
                List<string> objects = [.. GetAll()];
                int i = 0;

                for (i = 0; i < objects.Count(); i++)
                {
                    string[] obj = objects[i].Split(",");

                    if ((obj.Length > 0) && (obj[0].Equals(id.ToString())))
                        break;

                }

                if (i >= objects.Count())
                    return false;

                objects.RemoveAt(i);

                File.WriteAllLines(this.PathContext, objects);
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
