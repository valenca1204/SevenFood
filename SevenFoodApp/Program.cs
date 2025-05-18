using SevenFoodApp.Repository;
using SevenFoodApp.Util;
using SevenFoodApp.View;
using static SevenFoodApp.Util.Enums;

Please.StartDataBase();
bool hasContinue = true;
LoginView.Login();

while (hasContinue)
{
    bool hasBack = false;
    Menu.Begin();
    CONTEXT option = Menu.GetOption<CONTEXT>(Please.ChoiceOption());
    ACTION action;

    switch (option)
    {
        case CONTEXT.USER:
            while (!hasBack)
            {
                UserView userView = new UserView();
                Menu.User();
                action = Menu.GetOption<ACTION>(Please.ChoiceOption());

                switch (action)
                {
                    case ACTION.GET_BY_ID:

                        userView.ShowById();
                        break;
                    case ACTION.GET_ALL:
                        userView.ShowAll();
                        break;
                    case ACTION.INSERT:
                        userView.Add();
                        break;
                    case ACTION.DELETE:
                        userView.Remove();
                        break;
                    case ACTION.UPDATE:
                        userView.Update();
                        break;
                    case ACTION.BACK:
                    default:
                        hasBack = true;
                        break;

                }
                if (!hasBack)
                    Console.ReadKey();
            }
            break;
        case CONTEXT.RESTAURANT:
            RestaurantView restaurantView = new RestaurantView();
            while (!hasBack)
            {
                Menu.Restaurant();
                action = Menu.GetOption<ACTION>(Please.ChoiceOption());

                switch (action)
                {
                    case ACTION.GET_BY_ID:
                        restaurantView.ShowById();
                        break;
                    case ACTION.GET_ALL:
                        restaurantView.ShowAll();
                        break;
                    case ACTION.INSERT:
                        restaurantView.Add();
                        break;
                    case ACTION.DELETE:
                        restaurantView.Remove();
                        break;
                    case ACTION.UPDATE:
                        restaurantView.Update();
                        break;
                    case ACTION.BACK:
                    default:
                        hasBack = true;
                        break;
                }
                if (!hasBack)
                    Console.ReadKey();
            }
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
