namespace Restaurant;

public class AdminMenu
{
    public static void DisplayAdminMenu()
    {
        List<string> options = new(){
            "Change (food) menu",
            "Change restaurant layout",
            "Change application color",
            "Change reservations",
            "Change accounts",
            "Change tables",
            "Quit Application"
        };
        List<Action> actions = new(){
            ChangeFoodMenu.DisplayChangeFoodMenu,
            ChangeLayout.SetLayout,
            ChangeColor.SetColor,
            ChangeResvMenu.DisplayChangeResvMenu,
            ChangeAccMenu.DisplayChangeAccMenu,
            ChangeTableMenu.DisplayChangeTableMenu,
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

