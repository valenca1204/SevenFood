using SevenFoodApp.Repository;
using SevenFoodApp.View;
using static SevenFoodApp.Util.Enums;

UserRepository.startFileUsers();

UserView userView = new UserView();

bool hasContinue = true;


userView.Login();

while (hasContinue)
{
    bool hasBack = false;
    Menu.Begin();
    CODE option = Menu.GetOption<CODE>("Escolha uma opção");

    switch (option)
    {
        case CODE.USER:

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
        case CODE.EXIT:
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



    // hasContinue = HasContinue(option);
}

//bool HasContinue(CODE option)
//{
//    return !Menu.GetCodeExit().Equals(option);
//}
