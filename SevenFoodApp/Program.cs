using SevenFoodApp.Model;
using SevenFoodApp.View;
using System.ComponentModel;

UserView userView = new UserView();
List<User> users = new List<User>();

bool hasContinue = true;

while (hasContinue)
{
    bool hasBack = false;
    Menu.Begin();
    Menu.CODE option = Menu.GetOption<Menu.CODE>("Escolha uma opção");

    switch (option)
    {
        case Menu.CODE.USER:

            while (!hasBack)
            {
                Menu.User();
                Menu.USER optUser = Menu.GetOption<Menu.USER>("Escolha uma opção");

                switch (optUser)
                {
                    case Menu.USER.GET_BY_ID:
                        userView.Show();
                        break;
                    case Menu.USER.GET_ALL:
                        userView.ShowAll();
                        break;
                    case Menu.USER.INSERT:
                        userView.Add();                            
                        break;
                    case Menu.USER.DELETE:
                        userView.Remove();
                        break;
                    case Menu.USER.UPDATE:
                        userView.Update();
                        break;
                    case Menu.USER.BACK:
                    default:
                        hasBack = true;
                        break;

                }
                if (!hasBack)
                    Console.ReadKey();
            }
            break;
        case Menu.CODE.EXIT:
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

//bool HasContinue(Menu.CODE option)
//{
//    return !Menu.GetCodeExit().Equals(option);
//}
