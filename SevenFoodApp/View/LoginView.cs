using SevenFoodApp.Controller;
using SevenFoodApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.View
{
    internal class LoginView
    {
        public static void Login()
        {
            UserController controller = new UserController();
            bool canTryLogin = false;
            string? id;
            string? password;
            bool approved = false;
            
            do
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("|  >>> SEVEN FOOD <<<  |");
                Console.WriteLine("------------------------");
                Console.Write("ID: ");
                id = Please.ConsoleRead();
                Console.Write("Senha: ");
                password = Please.ConsoleRead();

                canTryLogin = (id != null) && (password != null);
                if (canTryLogin)
                    approved = controller.Loggin(id!, password!);

                if (!approved)
                    Console.WriteLine(Please.GetMessageGenericError());

            } while (canTryLogin && !approved);

        }
    }
}
