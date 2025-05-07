using SevenFoodApp.Model;
using SevenFoodApp.View;

UserView userView = new UserView();
List<User> users = new List<User>();

Boolean hasContinue = true;


while (hasContinue)
{
    Menu.Main();
    Menu.CODE option = Menu.GetOption("Escolha uma opção");

    User? user = userView.add();
    users.Add(user);
    userView.showAll(users);
    

    hasContinue = HasContinue(option);
}

bool HasContinue(Menu.CODE option)
{
    return !Menu.GetCodeExit().Equals(option);
}
