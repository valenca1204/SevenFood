using SevenFoodApp.Interfaces;
using SevenFoodApp.Model;
using System.Transactions;
using static SevenFoodApp.Util.Enums;

namespace SevenFoodApp.Repository
{
    internal class UserRepository : ARepository<User>
    {

        public UserRepository(CONTEXT context) : base(context) { }

        public override User? StringToObject(string _user)
        {
            try
            {
                string[] values = _user.Split(";");
                int id = int.Parse(values[0]);
                string name = values[1];
                string password = values[2];
                TYPE_USER type = (TYPE_USER)int.Parse(values[3]);
                User user = new User(id, name, password, type);
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public override string ToString(User user)
        {            
            return $"{user.Id};{user.Name};{user.Password};{(int)user.Type}";
        }
    }
}
