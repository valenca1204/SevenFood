using System;
using SevenFoodApp.View;
using static SevenFoodApp.Util.Enums;

namespace SevenFoodApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Please.StartDataBase();
            bool hasContinue = true;
            LoginView.Login();

            while (hasContinue)
            {
                bool hasBack = false;
                Menu.Begin();
                CONTEXT option = Menu.GetOption<CONTEXT>(Please.ChoiceOption());

                switch (option)
                {
                    case CONTEXT.USER:
                        UserView userView = new UserView();
                        userView.CadastrarUsuario();
                        break;

                    case CONTEXT.RESTAURANT:
                        RestaurantView restaurantView = new RestaurantView();
                        Menu.ShowOptionAction(hasBack, restaurantView);
                        break;

                    case CONTEXT.FOOD:
                        FoodView foodView = new FoodView();
                        Menu.ShowOptionAction(hasBack, foodView);
                        break;

                    case CONTEXT.EXIT:
                    default:
                        hasContinue = false;
                        break;
                }

                if (hasContinue && !hasBack)
                {
                    Console.WriteLine("Aperta qualquer tecla para continuar...");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Valeu Prezadinhos...\nAqui é Barril Dobrado, pai!!!");
                }
            }
        }
    }
}