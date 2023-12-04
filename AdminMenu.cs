namespace Restaurant;

public class AdminMenu
{
    public static void DisplayAdminMenu()
    {
        List<string> options = new(){
            "Change (food) menu",
            "Change restaurant layout",
            "Change Reservations",
            "Change accounts",
            "Quit Application"
        };
        List<Action> actions = new(){
            A.B,
            A.B,
            ChangeResvMenu.DisplayChangeResvMenu,
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

