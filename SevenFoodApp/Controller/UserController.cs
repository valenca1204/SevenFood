using SevenFoodApp.Model;
using SevenFoodApp.Repository;

namespace SevenFoodApp.Controller
{
    internal class UserController
    {
        private UserRepository userRepository = new UserRepository();

        public bool Add(string name)
        {
            int id = this.GetNextId();
            string password = this.BuilderRandomPassword();
            User user = new User(id, name, password);
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
            return userRepository.getLastId() + 1;
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

        internal bool update(int id, string name, string password)
        {
            User user = new User(id, name, password);
            return userRepository.Update(user);
        }

        internal bool Loggin(string id, string password)
        {
            try
            {
                int _id = int.Parse(id);
                return userRepository.Loggin(_id, password);
            }
            catch
            {
                return false;

            }

        }
    }
}
