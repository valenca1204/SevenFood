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

        public enum USER : int
        {
            BACK = 0,
            GET_BY_ID = 1,
            GET_ALL = 2,
            INSERT = 3,
            UPDATE = 4,
            DELETE = 5,
        }

        public static void Begin()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(">>> Bem Vindo do 7Food <<<");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"{(int)CODE.USER} - Usuário");
            Console.WriteLine($"{(int)CODE.EXIT} - Sair");
            Console.WriteLine("-------------------------------------");
        }

        public static void User()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(">>> USUÁRIO <<<");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"{(int)USER.GET_BY_ID} - Buscar pelo ID ");
            Console.WriteLine($"{(int)USER.GET_ALL} - Listar todos");
            Console.WriteLine($"{(int)USER.INSERT} - Cadastrar um novo usuário");
            Console.WriteLine($"{(int)USER.UPDATE} - Atualizar");
            Console.WriteLine($"{(int)USER.DELETE} - Apagar");
            Console.WriteLine($"{(int)USER.BACK} - Voltar");
            Console.WriteLine("-------------------------------------");
        }

        public static T GetOption<T>(string message) {
            T option;
            try
            {
                Console.WriteLine(message);
                option = (T) Enum.Parse(typeof(T), Console.ReadLine() ?? "0");
            }
            catch
            {
                option = (T) Enum.Parse(typeof(T), "0");
            } 
            return option;
        }

        public static CODE GetCodeExit() => CODE.EXIT;
    }
}
