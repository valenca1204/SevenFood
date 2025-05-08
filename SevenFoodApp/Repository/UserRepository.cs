using SevenFoodApp.Interfaces;
using SevenFoodApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.Repository
{
    internal class UserRepository : IRepository<User>
    {
        private const string PATH_FILE_USER_ID = "users_ids";
        public int getNextId()
        {
            var ids = File.ReadAllLines(PATH_FILE_USER_ID);
            return int.Parse(ids.Last()) ?? 0;

        }

        public void saveLastId(int id)
        {
            File.WriteAllLines(PATH_FILE_USER_ID, [id.ToString()]);
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

        public void Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
