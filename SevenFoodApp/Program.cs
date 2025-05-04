using SevenFoodApp.View;

Boolean hasContinue = true;

while (hasContinue)
{
    Menu.Main();
    Menu.CODE option = Menu.GetOption("Escolha uma opção");

    hasContinue = HasContinue(option);
}

bool HasContinue(Menu.CODE option)
{
    return !Menu.GetCodeExit().Equals(option);
}
