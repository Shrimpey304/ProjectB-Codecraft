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
            "Register"
        };
<<<<<<< HEAD
        List<Action> actions = new(){
            menuCard.FromMain,
            loginProcess.LoginProcessMailView,
            registerProcess.RegisterProcessView,
        };
=======
>>>>>>> cadaadbfae2919938ca60ae945979171f630099d
        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                menuCard.windowInstanceStack.Push(DisplayMainMenu);
                menuCard.FromMain(false);
                break;
            case 1: 
                loginProcess.LoginProcessMailView();
                break;
            case 2:
                registerProcess.RegisterProcessView();
                break;
            case 3:
                Quit();
                break;
        }
    }

    // private static void Quit()
    // {
    //     Console.WriteLine("Quitting application...");
    //     System.Environment.Exit(1);
    // }
}
    

