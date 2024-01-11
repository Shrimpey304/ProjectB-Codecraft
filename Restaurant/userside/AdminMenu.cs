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
            "See meals",
            "Add meal",
            "Remove meal",
            "Change meal",
            "Remove all meals",
            "Go back to change food menu"
        };
        
        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                AdminFood.SeeMeals(user);
                break;
            case 1: 
                AdminFood.AddMealA(user);
                break;
            case 2:
                AdminFood.RemoveMealA(user);
                break;
            case 3:
                DisplayChangeMeal(user);
                break;
            case 4:
                DisplayChangeFoodMenu(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
        }
    }

    public static void DisplayChangeMeal(User user)
    {
        List<string> options = new(){
            "Change name of meal",
            "Change course type of meal",
            "Change meal type",
            "Change price of meal",
            "Change course description of meal",
            "Go back to admin meal menu"
        };

        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                AdminEditMeal.ChangeMealName(user);
                break;
            case 1: 
                AdminEditMeal.ChangeCourseType(user);
                break;
            case 2:
                AdminEditMeal.ChangeMealType(user);
                break;
            case 3:
                 AdminEditMeal.ChangePrice(user);
                break;
            case 4:
                 AdminEditMeal.ChangeCourseDescription(user);
                break;
            case 5:
                DisplayAdminMeal(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
        }
    }

    public static void DisplayChangeWine(User user)
    {
        List<string> options = new(){
            "Change name of wine",
            "Change type of wine",
            "Change description of wine",
            "Change alcohol percentage of wine",
            "Change price of wine",
            "Go back to admin wine menu"
        };

        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                AdminEditWines.ChangeWineName(user);
                break;
            case 1: 
                AdminEditWines.ChangeWineType(user);
                break;
            case 2:
                AdminEditWines.ChangeWineDescription(user);
                break;
            case 3:
                 AdminEditWines.ChangeWineAlcoholP(user);
                break;
            case 4:
                 AdminEditWines.ChangeWinePrice(user);
                break;
            case 5:
                DisplayAdminWine(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
        }
    }

    public static void DisplayAdminWine(User user)
    {
        List<string> options = new(){
            "See wines",
            "Add wine",
            "Remove wine",
            "Change wine",
            "Remove all wines",
            "Go back to change food menu"
        };

        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                AdminFood.SeeWines(user);
                break;
            case 1: 
                AdminFood.AddWineA(user);
                break;
            case 2:
                AdminFood.RemoveWineA(user);
                break;
            case 3:
                 DisplayChangeWine(user);
                break;
            case 4:
                 AdminFood.RemAllWine(user);
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
            "See desserts",
            "Add dessert",
            "Remove dessert",
            "Change dessert",
            "Remove all desserts",
            "Go back to change food menu"
        };

        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                AdminFood.SeeDesserts(user);
                break;
            case 1: 
                AdminFood.AddDessertA(user);
                break;
            case 2:
                AdminFood.RemoveDessertA(user);
                break;
            case 3:
                 DisplayChangeDessert(user);
                break;
            case 4:
                 AdminFood.RemAllDesserts(user);
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
            "Change name of dessert",
            "Change type of dessert",
            "Change description of dessert",
            "Change price of dessert",
            "Change allergens of dessert",
            "Go back to admin dessert menu"
        };

        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                AdminEditDessert.ChangeDessertName(user);
                break;
            case 1: 
                AdminEditDessert.ChangeDessertType(user);
                break;
            case 2:
                AdminEditDessert.ChangeDessertDescription(user);
                break;
            case 3:
                 AdminEditDessert.ChangeDessertPrice(user);
                break;
            case 4:
                 AdminEditDessert.ChangeDessertAllergens(user);
                break;
            case 5:
                DisplayAdminDessert(user);
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
            "Change only table position",
            "Change only table type",
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
                AdminTable.ChangeTableType(user);
                break;
            case 3:
                 DisplayAdminTableMenu(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
        }
    }

    public static void DisplayChangeResvMenu(User user)
    {
        List<string> options = new(){
            "See reservations",
            "See reservation By date",
            "See reservations with food orders",
            "See reservation with food order by date",
            //"Add reservation(disabled)",
            //"Remove reservation(disabled)",
            //"Change reservation(disabled)",
            "Go back to admin menu"
        };

        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                AdminReservations.SeeReservationsA(user);
                break;
            case 1:
                AdminEditResv.SeeReservationsDateA(user);
                break;
            case 2: 
                AdminReservations.SeeReservationsOrders(user);
                break;
            case 3:
                AdminEditResv.SeeResvOrdersByDate(user);
                break;
            case 4:
                DisplayAdminMenu(user);
                break;
            case 5:
                DisplayAdminMenu(user);
                break;
            case 6:
                DisplayAdminMenu(user);
                break;
            case 7:
                DisplayAdminMenu(user);
                break;
            default:
                throw new Exception("un-expected admin menu error");
        }
    }

    public static void ChangeResvA(User user)
    {   
        List<string> options = new(){
            //"Change reservation table position(disabled)",
            //"Change reservation table type(disabled)",
            //"Change reservation date(disabled)",
            //"Change reservation time(disabled)",
            "Go back to admin reservations menu"
        };
        int selectedOption = DisplayUtil.Display(options);
        switch (selectedOption)
        {
            case 0:
                DisplayAdminMenu(user);
                break;
            case 1: 
                DisplayAdminMenu(user);
                break;
            case 2:
                DisplayAdminMenu(user);
                break;
            case 3:
                 DisplayAdminMenu(user);
                break;
            case 4:
                 DisplayChangeResvMenu(user);
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