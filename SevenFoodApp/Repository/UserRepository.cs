using SevenFoodApp.Interfaces;
using SevenFoodApp.Model;
using static SevenFoodApp.Util.Enums;

namespace SevenFoodApp.Repository
{
    internal class UserRepository : IRepository<User>
    {
        private const string PATH_FILE_ID = "ids.txt";
        private const string PATH_FILE_USER = "users.txt";

        public UserRepository() {
            startFileUsers();
        }
        public int getLastId()
        {
            var ids = File.ReadAllLines(PATH_FILE_ID);
            return int.Parse(ids.Last());
        }

        public void setLastId(int id)
        {
            File.WriteAllText(PATH_FILE_ID, id.ToString());
        }
        
        public bool Insert(User entity)
        {
            try
            {
                File.AppendAllText(PATH_FILE_USER, $"{entity.Id},{entity.Name},{entity.Password},{(int)entity.Type}\n");
                this.setLastId(entity.Id);
                return true;
            } catch
            {
                return false;
            }
        }

        public User? GetById(int id)
        {
            try
            {
                string[] _users = File.ReadAllLines(PATH_FILE_USER);    
                foreach (string _user in _users)
                {
                    User? user = this.CastFromString(_user);

                    if ((user != null) && (user.Id == id))
                        return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<User> GetAll()
        {
            List<User> list = new List<User>();
            try
            {
                string[] _users = File.ReadAllLines(PATH_FILE_USER);
                foreach (string _user in _users)
                {
                    User? user = this.CastFromString(_user);
                    if (user != null)
                        list.Add(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return list;
        }

        public bool Update(User entity)
        {
            try
            {
                string[] _users = File.ReadAllLines(PATH_FILE_USER);

                for (int i = 0; i < _users.Length; i++)
                {
                    User? user = this.CastFromString(_users[i]);

                    if ((user != null) && (user.Id == entity.Id))
                    {
                        _users[i] = this.toString(entity);
                    }
                }
                File.WriteAllLines(PATH_FILE_USER, _users);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }            
        }

        public bool Delete(int id)
        {
            try
            {
                List<string> _users = File.ReadAllLines(PATH_FILE_USER).ToList();
                int i = 0;

                for (i = 0; i < _users.Count(); i++)
                {
                    User? user = this.CastFromString(_users[i]);

                    if ((user != null) && (user.Id == id))
                        break;
                    
                }

                if (i > 0)
                    _users.RemoveAt(i);

                File.WriteAllLines(PATH_FILE_USER, _users);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
        }

        private User? CastFromString(string _user)
        {
            try
            {
                string[] values = _user.Split(",");
                int id = int.Parse(values[0]);
                string name = values[1];
                string password = values[2];
                TYPE_USER type = (TYPE_USER) int.Parse(values[3]);
                User user = new User(id, name, password, type);
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        private string toString(User user)
        {
            return $"{user.Id},{user.Name},{user.Password},{(int)user.Type}";
        }

        public static void startFileUsers()
        {

            if (!File.Exists(PATH_FILE_ID))
                File.WriteAllText(PATH_FILE_ID, "1");

            if (!File.Exists(PATH_FILE_USER))
                File.WriteAllText(PATH_FILE_USER, "1,Dudats,admin,0\n");
        }
    }
}
