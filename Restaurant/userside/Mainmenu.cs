namespace Restaurant;

public class MainMenu
{
    public static void DisplayMainMenu()
    {
        List<string> options = new(){
            "Menu",
            "Reservation",
            "Log in",
            "Register",
            "Quit Application"
        };
        List<Action> actions = new(){
            MenuCard.FromMain,
            MakeReservation.Display,
            LoginProcess.LoginProcessMailView,
            RegisterProcess.RegisterProcessView,
            Quit
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    private static void Quit()
    {
        Console.WriteLine("Quitting application...");
        return;
    }
}
