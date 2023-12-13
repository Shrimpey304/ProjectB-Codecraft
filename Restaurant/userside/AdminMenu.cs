namespace Restaurant;

public class AdminMenu
{
    public static void DisplayAdminMenu()
    {
        List<string> options = new(){
            "Change accounts",
            "Change food menu",
            "Change reservations",
            "Change tables",
            "Change application colors",
            "Quit Application"
        };
        List<Action> actions = new(){
            DisplayChangeAccMenu,
            DisplayChangeFoodMenu,
            DisplayChangeResvMenu,
            DisplayChangeTableMenu,
            DisplayChangeColorMenu,
            Quit
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void DisplayChangeAccMenu()
    {
        List<string> options = new(){
            "See accounts",
            "Add account",
            "Remove account",
            "Change account",
            "Go back to admin menu"
        };
        List<Action> actions = new(){
            AdminAccounts.SeeAccountsA,
            AdminAccounts.AddAccountsA,
            AdminAccounts.RemoveAccountsA,
            AdminAccounts.ChangeAccountsA,
            DisplayAdminMenu
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void DisplayChangeFoodMenu()
    {
        List<string> options = new(){
            "See food menu",
            "Add food",
            "Remove food",
            "Change food",
            "Go back to admin menu"
        };
        List<Action> actions = new(){
            AdminFood.SeeFoodA,
            AdminFood.AddFoodA,
            AdminFood.RemoveFoodA,
            AdminFood.ChangeFoodA,
            DisplayAdminMenu
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void DisplayChangeResvMenu()
    {
        List<string> options = new(){
            "See reservations",
            "Add reservation",
            "Remove reservation",
            "Change reservation",
            "Go back to admin menu"
        };
        List<Action> actions = new(){
            AdminReservations.SeeReservationsA,
            AdminReservations.AddReservationA,
            AdminReservations.RemovReservationA,
            AdminReservations.ChangeReservationA,
            DisplayAdminMenu
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void DisplayChangeTableMenu()
    {
        List<string> options = new(){
            "See tables",
            "Add table",
            "Remove table",
            "Change table",
            "Go back to admin menu"
        };
        List<Action> actions = new(){
            AdminTable.SeeTablesA,
            AdminTable.AddTableA,
            AdminTable.RemoveTableA,
            AdminTable.ChangeTableA,
            DisplayAdminMenu
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void DisplayChangeColorMenu()
    {
        List<string> options = new(){
            "Set color",
            "Change color",
            "Go back to admin menu"
        };
        List<Action> actions = new(){
            AdminColor.SetColor,
            AdminColor.ChangeColor,
            DisplayAdminMenu
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
