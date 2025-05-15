using SevenFoodApp.Repository;
using SevenFoodApp.Util;
using SevenFoodApp.View;
using static SevenFoodApp.Util.Enums;

Please.StartDataBase();
bool hasContinue = true;
UserView userView = new UserView();

userView.Login();

while (hasContinue)
{
    bool hasBack = false;
    Menu.Begin();
    CONTEXT option = Menu.GetOption<CONTEXT>("Escolha uma opção");

    switch (option)
    {
        case CONTEXT.USER:
            while (!hasBack)
            {
                Menu.User();
                USER optUser = Menu.GetOption<USER>("Escolha uma opção");

                switch (optUser)
                {
                    case USER.GET_BY_ID:

                        userView.ShowById();
                        break;
                    case USER.GET_ALL:
                        userView.ShowAll();
                        break;
                    case USER.INSERT:
                        userView.Add();
                        break;
                    case USER.DELETE:
                        userView.Remove();
                        break;
                    case USER.UPDATE:
                        userView.Update();
                        break;
                    case USER.BACK:
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
                RESTAURANT optRestaurant = Menu.GetOption<RESTAURANT>("Escolha uma opção");

                switch (optRestaurant)
                {
                    case RESTAURANT.GET_BY_ID:
                        restaurantView.ShowById();
                        break;
                    case RESTAURANT.GET_ALL:
                        restaurantView.ShowAll();
                        break;
                    case RESTAURANT.INSERT:
                        restaurantView.Add();
                        break;
                    case RESTAURANT.DELETE:
                        restaurantView.Remove();
                        break;
                    case RESTAURANT.UPDATE:
                        restaurantView.Update();
                        break;
                    case RESTAURANT.BACK:
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
