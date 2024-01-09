namespace Restaurant;

public class AdminMenu
{

    

    public static void DisplayAdminMenu(User user)
    {
        List<string> options = new(){
            "Admin accounts",
            "Admin food menu",
            "Admin reservations",
            "Admin tables",
            "Log out"
        };

        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                DisplayChangeAccMenu(user);
                break;
            case 1: 
                DisplayChangeFoodMenu(user);
                break;
            case 2:
                DisplayChangeResvMenu();
                break;
            case 3:
                DisplayAdminTableMenu();
                break;
            case 4:
                LogoutA();
                break;
            default:
                throw new Exception("un-expected main menu error");

        }
    }

    public static void DisplayChangeAccMenu(User user)
    {
        List<string> options = new(){
            "See accounts",
            "Add account",
            "Remove account",
            "Change account",
            "Go back to admin menu"
        };

        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                AdminAccounts.SeeAccountsA();
                break;
            case 1: 
                AdminAccounts.AddAccountsA();
                break;
            case 2:
                AdminAccounts.RemoveAccountsA();
                break;
            case 3:
                ChangeAccountsA(user);
                break;
            case 4:
                DisplayAdminMenu(user);
                break;
            default:
                throw new Exception("un-expected main menu error");
        }
    }

    public static void ChangeAccountsA(User user)
    {   
        List<string> options = new(){
            "Change email of account",
            "Change password of account",
            "Change phone number of account",
            "Change admin status of account",
            "Go back to admin accounts menu"
        };

        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                AdminEditAccs.ChangeEmail();
                break;
            case 1: 
                AdminEditAccs.ChangePassword();
                break;
            case 2:
                AdminEditAccs.ChangePhonenumber();
                break;
            case 3:
                AdminEditAccs.ChangeAdminstatus();
                break;
            case 4:
                DisplayChangeAccMenu(user);
                break;
            default:
                throw new Exception("un-expected main menu error");
        }
    }

    public static void DisplayChangeFoodMenu(User user)
    {
        List<string> options = new(){
            "Admin dishes",
            "Admin meals",
            "Admin wines",
            "Admin desserts",
            "Go back to admin menu"
        };

        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                DisplayAdminDish();
                break;
            case 1: 
                DisplayAdminMeal();
                break;
            case 2:
                DisplayAdminWine();
                break;
            case 3:
                 DisplayAdminDessert();
                break;
            case 4:
                 DisplayAdminMenu(user);
                break;
            default:
                throw new Exception("un-expected main menu error");
        }
    }

    public static void DisplayAdminDish(User user)
    {
        List<string> options = new(){
            "See dishes",
            "Add dish",
            "Remove dish",
            "Change dish",
            "Remove all dishes",
            "Go back to change food menu"
        };

        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                AdminFood.SeeDishes();
                break;
            case 1: 
                AdminFood.AddDishA();
                break;
            case 2:
                AdminFood.RemoveDishA();
                break;
            case 3:
                 DisplayChangeDish();
                break;
            case 4:
                 AdminFood.RemAllDishes();
                break;
            case 5:
                DisplayChangeFoodMenu(user);
                break;
            default:
                throw new Exception("un-expected main menu error");
        }
    }

    public static void DisplayChangeDish(User user)
    {
        List<string> options = new(){
            "Change name of dish",
            "Change type of dish",
            "Change description of dish",
            "Change price of dish",
            "Change allergens of dish",
            "Go back to admin dish menu"
        };

        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                AdminEditDish.ChangeDishName();
                break;
            case 1: 
                AdminEditDish.ChangeDishType();
                break;
            case 2:
                AdminEditDish.ChangeDishDescription();
                break;
            case 3:
                 AdminEditDish.ChangeDishPrice();
                break;
            case 4:
                 AdminEditDish.ChangeDishAllergens();
                break;
            case 5:
                DisplayAdminDish(user);
                break;
            default:
                throw new Exception("un-expected main menu error");
        }
    }

    public static void DisplayAdminMeal(User user)
    {
        List<string> options = new(){
            "See reservations",
            "Add reservation",
            "Remove reservation",
            "Change reservation",
            "Go back to admin menu"
        };
        
        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                AdminReservations.SeeReservationsA();
                break;
            case 1: 
                DisplayAdminMenu(user);
                break;
            case 2:
                AdminReservations.RemovReservationA();
                break;
            case 3:
                DisplayChangeMeal();
                break;
            case 4:
                DisplayAdminMenu(user);
                break;
            default:
                throw new Exception("un-expected main menu error");
        }
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