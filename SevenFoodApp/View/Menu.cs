using SevenFoodApp.Interfaces;
using SevenFoodApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static SevenFoodApp.Util.Enums;

namespace SevenFoodApp.View
{
    public static class Menu
    {
        public static void Begin()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(">>> Bem Vindo do 7Food <<<");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"{(int)CONTEXT.USER} - {CONTEXT.USER.Translate()}");
            Console.WriteLine($"{(int)CONTEXT.RESTAURANT} - {CONTEXT.RESTAURANT.Translate()}");
            Console.WriteLine($"{(int)CONTEXT.FOOD} - {CONTEXT.FOOD.Translate()}");
            Console.WriteLine($"{(int)CONTEXT.EXIT} - {CONTEXT.EXIT.Translate()}");
            Console.WriteLine("-------------------------------------");
        }

        public static void Action()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(">>> USUÁRIO <<<");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"{(int)ACTION.GET_BY_ID} - {ACTION.GET_BY_ID.Translate()}");
            Console.WriteLine($"{(int)ACTION.GET_ALL} - {ACTION.GET_ALL.Translate()}");
            Console.WriteLine($"{(int)ACTION.INSERT} - {ACTION.INSERT.Translate()}");
            Console.WriteLine($"{(int)ACTION.UPDATE} - {ACTION.UPDATE.Translate()}");
            Console.WriteLine($"{(int)ACTION.DELETE} - {ACTION.DELETE.Translate()}");
            Console.WriteLine($"{(int)ACTION.BACK} - {ACTION.BACK.Translate()}");
            Console.WriteLine("-------------------------------------");
        }

        public static void ShowOptionAction(this bool hasBack, IView view)
        {
            while (!hasBack)
            {
                Menu.Action();
                ACTION action = Menu.GetOption<ACTION>(Please.ChoiceOption());

                switch (action)
                {
                    case ACTION.GET_BY_ID:
                        view.ShowById();
                        break;
                    case ACTION.GET_ALL:
                        view.ShowAll();
                        break;
                    case ACTION.INSERT:
                        view.Add();
                        break;
                    case ACTION.DELETE:
                        view.Remove();
                        break;
                    case ACTION.UPDATE:
                        view.Update();
                        break;
                    case ACTION.BACK:
                    default:
                        hasBack = true;
                        break;
                }
                if (!hasBack)
                    Console.ReadKey();
            }
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
