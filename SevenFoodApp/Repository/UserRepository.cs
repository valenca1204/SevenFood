using SevenFoodApp.Interfaces;
using SevenFoodApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.Repository
{
    internal class UserRepository // : IRepository<User>
    {
        private const string PATH_FILE_ID = "ids.txt";
        private const string PATH_FILE_USER = "users.txt";

        public UserRepository() {
            if (!File.Exists(PATH_FILE_ID))            
                File.WriteAllText(PATH_FILE_ID, "0");

            if (!File.Exists(PATH_FILE_USER))
                File.WriteAllText(PATH_FILE_USER, "");
        }
        public int getLastId()
        {
            var ids = File.ReadAllLines(PATH_FILE_ID);
            return int.Parse(ids.Last());
        }

        public void setLastId(int id)
        {
            File.WriteAllLines(PATH_FILE_ID, [id.ToString()]);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(User entity)
        {
            try
            {
                File.WriteAllText(PATH_FILE_USER, $"{entity.Id},{entity.Name},{entity.Password}");
                return true;
            } catch
            {
                return false;
            }
        }

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
