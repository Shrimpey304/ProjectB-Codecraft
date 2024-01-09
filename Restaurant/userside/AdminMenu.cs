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
                DisplayChangeResvMenu(user);
                break;
            case 3:
                DisplayAdminTableMenu(user);
                break;
            case 4:
                LogoutA();
                break;
            default:
                throw new Exception("un-expected admin menu error");

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
                AdminAccounts.SeeAccountsA(user);
                break;
            case 1: 
                AdminAccounts.AddAccountsA(user);
                break;
            case 2:
                AdminAccounts.RemoveAccountsA(user);
                break;
            case 3:
                ChangeAccountsA(user);
                break;
            case 4:
                DisplayAdminMenu(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
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
                AdminEditAccs.ChangeEmail(user);
                break;
            case 1: 
                AdminEditAccs.ChangePassword(user);
                break;
            case 2:
                AdminEditAccs.ChangePhonenumber(user);
                break;
            case 3:
                AdminEditAccs.ChangeAdminstatus(user);
                break;
            case 4:
                DisplayChangeAccMenu(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
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
                DisplayAdminDish(user);
                break;
            case 1: 
                DisplayAdminMeal(user);
                break;
            case 2:
                DisplayAdminWine(user);
                break;
            case 3:
                 DisplayAdminDessert(user);
                break;
            case 4:
                 DisplayAdminMenu(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
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
                AdminFood.SeeDishes(user);
                break;
            case 1: 
                AdminFood.AddDishA(user);
                break;
            case 2:
                AdminFood.RemoveDishA(user);
                break;
            case 3:
                 DisplayChangeDish(user);
                break;
            case 4:
                 AdminFood.RemAllDishes(user);
                break;
            case 5:
                DisplayChangeFoodMenu(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
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
                AdminEditDish.ChangeDishName(user);
                break;
            case 1: 
                AdminEditDish.ChangeDishType(user);
                break;
            case 2:
                AdminEditDish.ChangeDishDescription(user);
                break;
            case 3:
                 AdminEditDish.ChangeDishPrice(user);
                break;
            case 4:
                 AdminEditDish.ChangeDishAllergens(user);
                break;
            case 5:
                DisplayAdminDish(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
        }
    }

    public static void DisplayAdminMeal(User user)
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
                AdminReservations.SeeReservationsA(user);
                break;
            case 1: 
                DisplayAdminMenu(user);
                break;
            case 2:
                AdminReservations.RemovReservationA();
                break;
            case 3:
                DisplayChangeMeal(user);
                break;
            case 4:
                DisplayAdminMenu(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
        }
    }

    public static void DisplayChangeMeal(User user)
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
                AdminEditDish.ChangeDishName(user);
                break;
            case 1: 
                AdminEditDish.ChangeDishType(user);
                break;
            case 2:
                AdminEditDish.ChangeDishDescription(user);
                break;
            case 3:
                 AdminEditDish.ChangeDishPrice(user);
                break;
            case 4:
                 AdminEditDish.ChangeDishAllergens(user);
                break;
            case 5:
                DisplayAdminDish(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
        }
    }

    public static void DisplayChangeWine(User user)
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
                AdminEditDish.ChangeDishName(user);
                break;
            case 1: 
                AdminEditDish.ChangeDishType(user);
                break;
            case 2:
                AdminEditDish.ChangeDishDescription(user);
                break;
            case 3:
                 AdminEditDish.ChangeDishPrice(user);
                break;
            case 4:
                 AdminEditDish.ChangeDishAllergens(user);
                break;
            case 5:
                DisplayAdminDish(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
        }
    }

    public static void DisplayAdminWine(User user)
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
                AdminFood.SeeDishes(user);
                break;
            case 1: 
                AdminFood.AddDishA(user);
                break;
            case 2:
                AdminFood.RemoveDishA(user);
                break;
            case 3:
                 DisplayChangeDish(user);
                break;
            case 4:
                 AdminFood.RemAllDishes(user);
                break;
            case 5:
                DisplayChangeFoodMenu(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
        }
    }

    public static void DisplayAdminDessert(User user)
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
                AdminFood.SeeDishes(user);
                break;
            case 1: 
                AdminFood.AddDishA(user);
                break;
            case 2:
                AdminFood.RemoveDishA(user);
                break;
            case 3:
                 DisplayChangeDish(user);
                break;
            case 4:
                 AdminFood.RemAllDishes(user);
                break;
            case 5:
                DisplayChangeFoodMenu(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
        }
    }

    public static void DisplayChangeDessert(User user)
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
                AdminEditDish.ChangeDishName(user);
                break;
            case 1: 
                AdminEditDish.ChangeDishType(user);
                break;
            case 2:
                AdminEditDish.ChangeDishDescription(user);
                break;
            case 3:
                 AdminEditDish.ChangeDishPrice(user);
                break;
            case 4:
                 AdminEditDish.ChangeDishAllergens(user);
                break;
            case 5:
                DisplayAdminDish(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
        }
    }

    public static void DisplayChangeResvMenu(User user)
    {
        List<string> options = new(){
            "See reservations",
            "Remove reservation",
            "Change reservation",
            "Go back to admin menu"
        };

        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                AdminEditDish.ChangeDishName(user);
                break;
            case 1: 
                AdminEditDish.ChangeDishType(user);
                break;
            case 2:
                AdminEditDish.ChangeDishDescription(user);
                break;
            case 3:
                 AdminEditDish.ChangeDishPrice(user);
                break;
            case 4:
                 AdminEditDish.ChangeDishAllergens(user);
                break;
            case 5:
                DisplayAdminDish(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
        }
    }

    public static void DisplayAdminTableMenu(User user)
    {
        List<string> options = new(){
            "See tables",
            "Add table",
            "Remove tables",
            "Change table",
            "Go back to admin menu"
        };
        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                AdminTable.SeeTablesA(user);
                break;
            case 1: 
                AdminTable.AddTableA(user);
                break;
            case 2:
                AdminTable.RemoveTableA(user);
                break;
            case 3:
                 DisplayChangeTableMenu(user);
                break;
            case 4:
                 DisplayAdminMenu(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
        }
    }

    public static void DisplayChangeTableMenu(User user)
    {
        List<string> options = new(){
            "Change table",
            "Change table position",
            "Change table type",
            "Go back to admin table menu"
        };
        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                AdminTable.ChangeTableA(user);
                break;
            case 1: 
                AdminTable.ChangeTablePosition(user);
                break;
            case 2:
                AdminTable.RemoveTableA(user);
                break;
            case 3:
                 AdminTable.ChangeTableType(user);
                break;
            case 4:
                 DisplayAdminTableMenu(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
        }
    }

    public static void ChangeResvA(User user)
    {   
        List<string> options = new(){
            "Change position of table",
            "Change reservation date",
            "Change reservation table type",
            "Change reservation time",
            "Go back to admin reservations menu"
        };
        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                AdminEditAccs.ChangePassword(user);
                break;
            case 1: 
                AdminEditAccs.ChangePassword(user);
                break;
            case 2:
                //AdminEditResv.ChangeTableTypeR();
                break;
            case 3:
                 AdminEditAccs.ChangeAdminstatus(user);
                break;
            case 4:
                 DisplayChangeAccMenu(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
        }
    }

    private static void LogoutA()
    {
        MainMenu.DisplayMainMenu();
    }
}