namespace Restaurant;

public class AdminMenu
{
    public static void DisplayAdminMenu()
    {
        List<string> options = new(){
            "Admin accounts",
            "Admin food menu",
            "Admin reservations",
            "Admin tables",
            "Log out"
        };
        List<Action> actions = new(){
            DisplayChangeAccMenu,
            DisplayChangeFoodMenu,
            DisplayChangeResvMenu,
            DisplayAdminTableMenu,
            LogoutA
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
            ChangeAccountsA,
            DisplayAdminMenu
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void ChangeAccountsA()
    {   
        List<string> options = new(){
            "Change email of account",
            "Change password of account",
            "Change phone number of account",
            "Change admin status of account",
            "Go back to admin accounts menu"
        };
        List<Action> actions = new(){
            AdminEditAccs.ChangeEmail,
            AdminEditAccs.ChangePassword,
            AdminEditAccs.ChangePhonenumber,
            AdminEditAccs.ChangeAdminstatus,
            DisplayChangeAccMenu,
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void DisplayChangeFoodMenu()
    {
        List<string> options = new(){
            "Admin dishes",
            "Admin meals",
            "Admin wines",
            "Admin desserts",
            "Go back to admin menu"
        };
        List<Action> actions = new(){
            DisplayAdminDish,
            DisplayAdminMeal,
            DisplayAdminWine,
            DisplayAdminDessert,
            DisplayAdminMenu
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void DisplayAdminDish()
    {
        List<string> options = new(){
            "See dishes",
            "Add dish",
            "Remove dish",
            "Change dish",
            "Remove all dishes",
            "Go back to change food menu"
        };
        List<Action> actions = new(){
            AdminFood.SeeDishes,
            AdminFood.AddDishA,
            AdminFood.RemoveDishA,
            DisplayChangeDish,
            AdminFood.RemAllDishes,
            DisplayChangeFoodMenu
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void DisplayChangeDish()
    {
        List<string> options = new(){
            "Change name of dish",
            "Change type of dish",
            "Change description of dish",
            "Change price of dish",
            "Change allergens of dish",
            "Go back to admin dish menu"
        };
        List<Action> actions = new(){
            AdminEditDish.ChangeDishName,
            AdminEditDish.ChangeDishType,
            AdminEditDish.ChangeDishDescription,
            AdminEditDish.ChangeDishPrice,
            AdminEditDish.ChangeDishAllergens,
            DisplayAdminDish
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void DisplayAdminMeal()
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
            DisplayAdminMenu,
            AdminReservations.RemovReservationA,
            DisplayChangeMeal,
            DisplayAdminMenu
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void DisplayChangeMeal()
    {
        LoginProcess loginProcess = new LoginProcess();
        List<string> options = new(){
            "See reservations",
            "Add reservation",
            "Remove reservation",
            // "Change reservation",
            "Go back to admin menu"
        };
        List<Action> actions = new(){
            AdminReservations.SeeReservationsA,
            DisplayAdminMenu,
            AdminReservations.RemovReservationA,
            // ChangeResvA,
            DisplayAdminMenu
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void DisplayChangeWine()
    {
        List<string> options = new(){
            "See reservations",
            "Add reservation",
            "Remove reservation",
            // "Change reservation",
            "Go back to admin menu"
        };
        List<Action> actions = new(){
            AdminReservations.SeeReservationsA,
            DisplayAdminMenu,
            AdminReservations.RemovReservationA,
            // ChangeResvA,
            DisplayAdminMenu
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void DisplayAdminWine()
    {
        List<string> options = new(){
            "See reservations",
            "Add reservation",
            "Remove reservation",
            // "Change reservation",
            "Go back to admin menu"
        };
        List<Action> actions = new(){
            AdminReservations.SeeReservationsA,
            DisplayAdminMenu,
            AdminReservations.RemovReservationA,
            // ChangeResvA,
            DisplayAdminMenu
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void DisplayAdminDessert()
    {
        List<string> options = new(){
            "See reservations",
            "Add reservation",
            "Remove reservation",
            // "Change reservation",
            "Go back to admin menu"
        };
        List<Action> actions = new(){
            AdminReservations.SeeReservationsA,
            DisplayAdminMenu,
            AdminReservations.RemovReservationA,
            // ChangeResvA,
            DisplayAdminMenu
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void DisplayChangeDessert()
    {
        List<string> options = new(){
            "See reservations",
            "Add reservation",
            "Remove reservation",
            // "Change reservation",
            "Go back to admin menu"
        };
        List<Action> actions = new(){
            AdminReservations.SeeReservationsA,
            DisplayAdminMenu,
            AdminReservations.RemovReservationA,
            // ChangeResvA,
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
            // "Change reservation",
            "Go back to admin menu"
        };
        List<Action> actions = new(){
            AdminReservations.SeeReservationsA,
            DisplayAdminMenu,
            AdminReservations.RemovReservationA,
            // ChangeResvA,
            DisplayAdminMenu
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void DisplayAdminTableMenu()
    {
        List<string> options = new(){
            "See tables",
            "Add table",
            "Remove tables",
            "Change table",
            "Go back to admin menu"
        };
        List<Action> actions = new(){
            AdminTable.SeeTablesA,
            AdminTable.AddTableA,
            AdminTable.RemoveTableA,
            DisplayChangeTableMenu,
            DisplayAdminMenu
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void DisplayChangeTableMenu()
    {
        List<string> options = new(){
            "Change table",
            "Change table position",
            "Change table type",
            "Go back to admin table menu"
        };
        List<Action> actions = new(){
            AdminTable.ChangeTableA,
            AdminTable.ChangeTablePosition,
            AdminTable.ChangeTableType,
            DisplayAdminTableMenu
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    private static void LogoutA()
    {
        MainMenu.DisplayMainMenu();
    }

    // public static void ChangeResvA()
    // {   
    //     List<string> options = new(){
    //         "Change position of table",
    //         "Change reservation date",
    //         "Change reservation table type",
    //         "Change reservation time",
    //         "Go back to admin reservations menu"
    //     };
    //     List<Action> actions = new(){
    //         AdminEditAccs.ChangePassword,
    //         AdminEditAccs.ChangePassword,
    //         AdminEditResv.ChangeTableTypeR,
    //         AdminEditAccs.ChangeAdminstatus,
    //         DisplayChangeAccMenu,
    //     };
    //     int selectedOption = DisplayUtil.Display(options);
    //     actions[selectedOption]();
        

    // }
}