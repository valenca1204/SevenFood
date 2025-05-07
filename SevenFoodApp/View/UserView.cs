using SevenFoodApp.Controller;
using SevenFoodApp.Interfaces;
using SevenFoodApp.Model;
using SevenFoodApp.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.View
{
    internal class UserView : IView<User>
    {
        int small = (int)Enums.ColumnSize.small;
        int medium = (int)Enums.ColumnSize.medium;
        int large = (int)Enums.ColumnSize.large;

        public User? add()
        {
            try
            {
                Console.Write("Nome: ");
                string name = Console.ReadLine() ?? "Nome não Informado";
                string password = UserController.BuilderRandomPassword();
                return new User(name, password);

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool remove(int id)
        {
            throw new NotImplementedException();
        }

        public void show(User obj)
        {
            Console.WriteLine($"Id   : {obj.Id}");
            Console.WriteLine($"Nome : {obj.Name}");
            Console.WriteLine($"Senha: {obj.Password}");
        }

        public void showAll(List<User> users)
        {
            this.showTitle();            
            foreach (User user in users)
            {
                this.showInLine(user);
            }
        }

        private void showInLine(User user)
        {
            
            
            Console.Write($"{user.Id.ToString().PadRight(this.small)}");
            Console.Write($"{user.Name.PadRight(this.large)[..(this.large - 1)]} ");
            Console.Write($"{user.Password.PadRight(this.medium)}");
            Console.WriteLine("");
        }

        private void showTitle()
        {
            int totalSize = this.small + this.medium + this.large;
            Console.WriteLine($"".PadRight(totalSize, '-'));
            Console.Write($"ID".PadRight(this.small));
            Console.Write($"NOME".PadRight(this.large));
            Console.WriteLine($"SENHA".PadRight(this.medium));
            Console.WriteLine($"".PadRight(totalSize, '-'));

        }
    }
}
