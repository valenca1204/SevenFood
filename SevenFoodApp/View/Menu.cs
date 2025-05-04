using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.View
{
    internal class Menu
    {
        public enum CODE : int
        {
            EXIT = 0,
            USER = 1,
        }

        public static void Main()
        {
            Console.Clear();
            Console.WriteLine("Bem Vindo do 7Food");
            Console.WriteLine();
            Console.WriteLine("1 - Usuário");
            Console.WriteLine($"{(int)CODE.EXIT} - Sair");
        }

        public static CODE GetOption(string message) {
            CODE option;
            try
            {
                Console.WriteLine(message);
                option = (CODE) Enum.Parse(typeof(CODE), Console.ReadLine() ?? "0");
            }
            catch
            {
                option = CODE.EXIT;
            } 
            return option;
        }

        public static CODE GetCodeExit() => CODE.EXIT;
    }
}
