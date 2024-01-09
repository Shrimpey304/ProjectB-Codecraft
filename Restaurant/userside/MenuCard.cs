namespace Restaurant;

using System;
using System.Formats.Asn1;
using System.Net;

public class MenuCard : MasterDisplay
{
    private static FoodManager manager = new();
    private RegisterProcess register = new();
    public User user;
    public List<Action> windowInstanceStack = new();
    public MakeReservation CheckOut;
    private int toCheckOut;
    private bool isLoggedIn;

    public void FromMain(bool loggedin)
    {
        if (user is null){
            isLoggedIn = loggedin;
            toCheckOut = 0;
        }
        isLoggedIn = loggedin;
        Display(); 
    }

    Ingelogdmenu loggedInMenu = new();
    public void GoBackAction(){
        Console.WriteLine("in gobackaction");
       // windowInstanceStack.Pop();
        if(Login.IsLoggedIn){
            loggedInMenu.user = user;
            loggedInMenu.DisplayIngelogdMenu();
        }else{
            MainMenu.DisplayMainMenu();
        }
    }

    public void Display()
    {
        
        List<string> options = new(){
            "Full-Course Meal",
            "Individual Dishes",
            "See Wine Options",
            "Desserts",
            "Go Back"
        };
        int selectedOption = DisplayUtil.Display(options);
        switch(selectedOption){
            case 0:
                CoursesOptions();
                break;
            case 1:
                DishesOptions();
                break;
            case 2:
                AddWine();
                break;
            case 3:
                AddDessert();
                break;
            case 4:
                if (toCheckOut == 1){
                    List<string> outOptions = new(){"Go to checkout", "Go back to reservation menu"};
                    int selectedOption2 = DisplayUtil.Display(outOptions);
                    if (selectedOption2 == 0){
                        CheckOut.CheckOut(CheckOut.table, CheckOut.reservationDate, manager.Cart);
                    }else{
                        CheckOut.Display();
                    }
                }else{
                    windowInstanceStack[0]();
                }
                break;
        }
    }

    private void DishesOptions()
    {
        List<string> option1 = OptionString<Dish>(manager.Dishes);
        string foodCart = GetCartString(manager.Cart);
        int selectedOption = DisplayUtil.Display(option1, foodCart);
        if (selectedOption < (option1.Count - 1))
        {
            Menu(option1[selectedOption], true);
        }
        else
        {
            Display();
        }
    }

    private void CoursesOptions()
    {
        List<string> option1 = OptionString<Meals>(manager.Meals);
        string foodCart = GetCartString(manager.Cart);
        int selectedOption = DisplayUtil.Display(option1, foodCart);
        if (selectedOption < (option1.Count - 1))
        {
            Menu(option1[selectedOption]);
        }
        else
        {
            Display();
        }
    }

    public void AddDessert(){
        List<string> dessertOption = OptionString<Dessert>(manager.Desserts, false);
        int selectedOption = DisplayUtil.Display(dessertOption);
        if(selectedOption < (dessertOption.Count -1) && isLoggedIn){
            manager.Cart.Add(manager.Wines[selectedOption]);
            List<string> options = new(){"Go back", "Go to checkout"};
            int selected = DisplayUtil.Display(options);
            if (selected == 0){
                toCheckOut = 1;
                Display();
            }else{
                // this might blowup
                CheckOut.CheckOut(CheckOut.table, CheckOut.reservationDate, manager.Cart);
            }
        }else{
            Display();
        }
    }
    public void AddWine()
    {
        List<string> wineOption = OptionString<Wine>(manager.Wines, false);
        int selectedOption = DisplayUtil.Display(wineOption);
        if(selectedOption < (wineOption.Count -1) && isLoggedIn){
            manager.Cart.Add(manager.Wines[selectedOption]);
            List<string> options = new(){"Go back", "Go to checkout"};
            int selected = DisplayUtil.Display(options);
            if (selected == 0){
                toCheckOut = 1;
                Display();
            }else{
                // this might blowup
                CheckOut.CheckOut(CheckOut.table, CheckOut.reservationDate, manager.Cart);
            }
        }else{
            Display();
        }
    }

    private void Menu(string itemType, bool dish = false)
    {
        if (dish)
        {
            List<IFoodItems> dishes = manager.GetDishes(itemType);
            List<string> option3 = OptionString(dishes, false);
            string foodCart = GetCartString(manager.Cart);
            int selectedOption1 = DisplayUtil.Display(option3, foodCart);
            if (selectedOption1 < (option3.Count - 1) && isLoggedIn)
            {
                Dish dish1 = (Dish)dishes[selectedOption1];
                Console.WriteLine("Are there any allergens you would like to remove?(y/n) ");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "y")
                {
                    Console.WriteLine("Input allergy you want to remove: ");
                    string allergy = Console.ReadLine();
                    dish1.RemovedA = allergy;
                    FoodManager.RemoveAllergens(allergy);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"We have removed {allergy} from your meal(s)");
                    Thread.Sleep(4000);
                    Console.ResetColor();
                }
                manager.AddToCart(dishes[selectedOption1]);
                foodCart = GetCartString(manager.Cart);
                List<string> options = new(){"Go back", "Go to checkout"};
                int selected = DisplayUtil.Display(options, foodCart);
                if (selected == 0){
                    toCheckOut = 1;
                    Display();
                }else{
                    // this might blowup
                    CheckOut.CheckOut(CheckOut.table, CheckOut.reservationDate, manager.Cart);
                }                
            }
            else
            {
                //windowInstanceStack.Add(MainMenu.DisplayMainMenu);
                Display();
            }
        }
        else
        {
            List<IFoodItems> meals = manager.GetMeals(itemType);
            List<string> option2 = OptionString(meals, false);
            string foodCart = GetCartString(manager.Cart);
            int selectedOption = DisplayUtil.Display(option2, foodCart);
            if (selectedOption < (option2.Count - 1) && isLoggedIn)
            {
                Meals meal = (Meals)meals[selectedOption];
                Console.WriteLine("Are there any allergens you would like to remove?(y/n) ");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "y")
                {
                    Console.WriteLine("Input allergy you want to remove: ");
                    string allergy = Console.ReadLine();
                    meal.RemovedA = allergy;
                    FoodManager.RemoveAllergens(allergy);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"We have removed {allergy} from your meal(s)");
                    Thread.Sleep(4000);
                    Console.ResetColor();
                }
                System.Console.WriteLine("Item added to cart.");
                manager.AddToCart(meals[selectedOption]);
                foodCart = GetCartString(manager.Cart);
                List<string> options = new(){"Go back", "Go to checkout"};
                int selected = DisplayUtil.Display(options, foodCart);
                if (selected == 0){
                    toCheckOut = 1;
                    Display();
                }else{
                    // this might blowup
                    CheckOut.CheckOut(CheckOut.table, CheckOut.reservationDate, manager.Cart);
                }
            }
            else
            {
                //windowInstanceStack.Add(MainMenu.DisplayMainMenu);
                Display();
            }
        }
    }

    private string GetCartString(List<IFoodItems> cart)
    {
        List<string> outCart = new();
        if (cart.Count > 0)
        {
            foreach (IFoodItems item in cart)
            {
                outCart.Add(item.GetString(true, true));
            }
            return string.Join("\n\n", outCart);
        }
        return "your cart is empty\n";
    }

    private static List<string> OptionString<T>(List<T> foodItems, bool justname = true) where T : class
    {
        List<string> outl = new();
        foreach (IFoodItems item in foodItems)
        {
            string option = item.GetString(justname);
            if(!outl.Contains(option)){
                outl.Add(option);
            }
        }
        outl.Add("Go Back");
        return outl;
    }
}