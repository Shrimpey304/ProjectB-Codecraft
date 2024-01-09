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
            "Restaurant information"
        };
        List<Action> actions = new(){
            //menuCard.FromMain,
            loginProcess.LoginProcessMailView,
            //registerProcess.RegisterMail,
        };

        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                menuCard.windowInstanceStack.Add(DisplayMainMenu);
                menuCard.FromMain(false);
                break;
            case 1: 
                loginProcess.LoginProcessMailView();
                break;
            case 2:
                registerProcess.RegisterMail();
                break;
            
            case 3:
                RestaurantInfo.DisplayRestaurantInfo();
                break;
            default:
                throw new Exception("un-expected main menu error");

        }
    }

    // private static void Quit()
    // {
    //     Console.WriteLine("Quitting application...");
    //     System.Environment.Exit(1);
    // }
}

