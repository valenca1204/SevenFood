using SevenFoodApp.Model;
using SevenFoodApp.Repository;
using SevenFoodApp.Util;
using static SevenFoodApp.Util.Enums;

namespace SevenFoodApp.Controller
{
    internal class UserController
    {
        private UserRepository userRepository = new UserRepository(CONTEXT.USER);

        public bool Add(string name, TYPE_USER type)
        {
            int id = this.GetNextId();
            string password = this.BuilderRandomPassword();
            User user = new User(id, name, password, type);
            return userRepository.Insert(user);
        }

        private string BuilderRandomPassword()
        {
            const string UPPER = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string LOWWER = "abcdefghijklmnopqrstuvwxyz";
            const string SPECIAL = "!@#$%&?><";
            const string DIGIT = "0123456789";

            var caracteres = new List<string>([UPPER, LOWWER, SPECIAL, DIGIT]);
            string password = "";
            Random index_randomic = new Random();

            for (int i = 0; i < 8; i++)
            {
                int index_type = index_randomic.Next(0, 4);
                int index_caractere = index_randomic.Next(0, caracteres[index_type].Length);
                char caracter_random = caracteres[index_type][index_caractere];
                password += caracter_random;
            }
            return password;
        }

        private bool IsValidPassWord(string password) => password.Length >= 8;

        private int GetNextId()
        {
            return Please.GetNextId();
        }

        public List<User> getAll()
        {
            return userRepository.GetAll();
        }

        public User? getById(int id)
        {
            return userRepository.GetById(id);
        }

        public bool remove(int id)
        {
            return userRepository.Delete(id);
        }

        internal bool update(int id, string name, string password, TYPE_USER type = TYPE_USER.Client)
        {
            User user = new User(id, name, password, type);
            return userRepository.Update(user);
        }

        public bool Loggin(string id, string password)
        {
            try
            {
                int _id = int.Parse(id);
                User user = userRepository.GetById(_id)!;
                return user != null && user.Password == password;
            }
            catch
            {
                return false;

            }

        }
    }
}
