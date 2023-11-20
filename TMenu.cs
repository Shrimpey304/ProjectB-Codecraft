namespace Restaurant;

public class TMenu
{
    public static void DisplayMainMenu()
    {
        List<string> options = new(){
            "Change (food) menu",
            "Change restaurant layout",
            "Change Reservations",
            "Change accounts",
            "Quit Application"
        };
        List<Action> actions = new(){
            TMenu2.Displaytest,
            TMenu2.Displaytest,
            TMenu2.Displaytest,
            ChangeAccMenu.DisplayChangeAccMenu,
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



