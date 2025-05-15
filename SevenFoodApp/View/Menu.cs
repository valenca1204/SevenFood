using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static SevenFoodApp.Util.Enums;

namespace SevenFoodApp.View
{
    internal class Menu
    {
        public static void Begin()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(">>> Bem Vindo do 7Food <<<");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"{(int)CONTEXT.USER} - Usuários");
            Console.WriteLine($"{(int)CONTEXT.RESTAURANT} - Restaurantes");
            Console.WriteLine($"{(int)CONTEXT.EXIT} - Sair");
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
            Console.WriteLine($"{(int)USER.INSERT} - Cadastrar");
            Console.WriteLine($"{(int)USER.UPDATE} - Atualizar");
            Console.WriteLine($"{(int)USER.DELETE} - Apagar");
            Console.WriteLine($"{(int)USER.BACK} - Voltar");
            Console.WriteLine("-------------------------------------");
        }

        public static void Restaurant()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(">>> RESTAURANTE <<<");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"{(int)USER.GET_BY_ID} - Buscar pelo ID ");
            Console.WriteLine($"{(int)USER.GET_ALL} - Listar todos");
            Console.WriteLine($"{(int)USER.INSERT} - Cadastrar");
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

        public static CONTEXT GetCodeExit() => CONTEXT.EXIT;
    }
}
