namespace Restaurant;

public class MainMenu : MasterDisplay
{
    public Stack<Action> windowInstanceStack = new();
    public static void DisplayMainMenu()
    {
        MenuCard menuCard = new();
        LoginProcess loginProcess = new();
        RegisterProcess registerProcess = new();
        List<string> options = new(){
            "Menu",
            "Log in",
            "Register",
        };
        List<Action> actions = new(){
            menuCard.FromMain,
            loginProcess.LoginProcessMailView,
            registerProcess.RegisterProcessView,
        };
        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                menuCard.windowInstanceStack.Push(DisplayMainMenu);
                break;
        }
        actions[selectedOption]();
    }
    
}
