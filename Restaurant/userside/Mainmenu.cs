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
            "Restuarant info"
        };
        List<Action> actions = new(){
            //menuCard.FromMain,
            loginProcess.LoginProcessMailView,
            registerProcess.RegisterMail,
        };

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
                registerProcess.RegisterMail();
                break;
            
            case 3:
                RestaurantInfoTest.DisplayRestaurantInfo(null);
                break;
            default:
                break;

        }
    }

    // private static void Quit()
    // {
    //     Console.WriteLine("Quitting application...");
    //     System.Environment.Exit(1);
    // }
}
    

