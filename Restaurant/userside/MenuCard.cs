namespace Restaurant;

using System;
using System.Formats.Asn1;
using System.Net;

public class MenuCard : MasterDisplay
{
    private static FoodManager manager = new();
    public Stack<Action> windowInstanceStack = new();

    public void FromMain()
    {

        //windowInstanceStack.Push(MainMenu.DisplayMainMenu);
        Display(); 
    }
    public List<IFoodItems>? Display()
    {
        List<string> options = new(){
            "Full-Course Meal",
            "Individual Dishes",
            "Go Back"
        };
        List<Action> actions = new(){
            CoursesOptions,
            DishesOptions,
            windowInstanceStack.Pop()
        };
        int selectedOption = DisplayUtil.Display(options);
        if (selectedOption == (options.Count - 1) && manager.Cart.Count > 0)
        {
            MakeReservation.foodItems = manager.Cart;
            return manager.Cart;
        }
        actions[selectedOption]();
        return null;
    }

    private void DishesOptions()
    {
        List<string> option1 = OptionString<Dish>(manager.Dishes);
        int selectedOption = DisplayUtil.Display(option1);
        if (selectedOption < (option1.Count - 1))
        {
            Menu(option1[selectedOption], true);
        }
        else
        {
            windowInstanceStack.Push(MainMenu.DisplayMainMenu);
            Display();
        }
    }

    private void CoursesOptions()
    {
        List<string> option1 = OptionString<Meals>(manager.Meals);
        int selectedOption = DisplayUtil.Display(option1);
        if (selectedOption < (option1.Count - 1))
        {
            Menu(option1[selectedOption]);
        }
        else
        {
            windowInstanceStack.Push(MainMenu.DisplayMainMenu);
            Display();
        }
    }
    public void AddWine()
    {
        Console.WriteLine("Would you like a bottle of wine with your order?");
        string answer = Console.ReadLine().ToLower();

        if (answer == "yes" || answer == "yess")
        {
        

            Console.WriteLine("Splendid! Here is our list of available wine bottles: ");
            List<Wine> wineList = FoodItems_init_.PopulateWine();
            
            foreach (var availableWine in wineList)
            {
                Console.WriteLine($"ID: {availableWine.ID}, Name: {availableWine.WineName}, Description: {availableWine.Description}, Price: {availableWine.Price:C}\n");
            }

            Console.WriteLine("Enter the ID of the wine you would like to add to your order.");
            string userInput2 = Console.ReadLine();
            if (int.TryParse(userInput2.Trim(), out int selectedWineID) && selectedWineID > 0 && selectedWineID <= wineList.Count)
            {
                    var selectedWine = wineList.FirstOrDefault(wine => wine.ID == selectedWineID);
                    if (selectedWine != null)
                    {
                        Console.WriteLine($"We have added: {selectedWine.WineName} - with a price of: {selectedWine.Price} to your order");
                        Thread.Sleep(4000);
                        manager.AddToCart(selectedWine);
                    }
            }
            else if (int.TryParse(userInput2, out int userInput3) && userInput3 > 4)
            {
                Console.WriteLine("Input too high. Please enter a valid wine ID.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid wine ID");
            }
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
            if (selectedOption1 < (option3.Count - 1))
            {
                Dish dish1 = (Dish)dishes[selectedOption1];
                Console.WriteLine("Are there any allergens you would like to remove? ");
                string answer = Console.ReadLine();
                string allergy = null;
                if (answer.ToLower() == "yes")
                {
                    Console.WriteLine("Input allergy you want to remove: ");
                    allergy = Console.ReadLine();
                    dish1.RemovedA = allergy;
                    FoodManager.RemoveAllergens(allergy);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"We have removed {allergy} from your meal(s)");
                    Thread.Sleep(4000);
                    Console.ResetColor();
                }
                System.Console.WriteLine("Item added to cart.");
                manager.AddToCart(dishes[selectedOption1]);
                AddWine(); //ADDWINE HERE !!!! (als iemand een betere plek weet om de method aan te roepen do your thing)
                DishesOptions();
                
                 
            }
            else
            {
                windowInstanceStack.Push(MainMenu.DisplayMainMenu);
                Display();
            }
        }
        else
        {
            List<IFoodItems> meals = manager.GetMeals(itemType);
            System.Console.WriteLine($"{itemType}, {meals.Count}");
            List<string> option2 = OptionString(meals, false);
            string foodCart = GetCartString(manager.Cart);
            int selectedOption = DisplayUtil.Display(option2, foodCart);
            if (selectedOption < (option2.Count - 1))
            {
                Meals meal = (Meals)meals[selectedOption];
                Console.WriteLine("Are there any allergens you would like to remove? ");
                string answer = Console.ReadLine();
                string allergy = null;
                if (answer.ToLower() == "yes")
                {
                    Console.WriteLine("Input allergy you want to remove: ");
                    allergy = Console.ReadLine();
                    meal.RemovedA = allergy;
                    FoodManager.RemoveAllergens(allergy);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"We have removed {allergy} from your meal(s)");
                    Thread.Sleep(4000);
                    Console.ResetColor();
                }
                System.Console.WriteLine("Item added to cart.");
                manager.AddToCart(meals[selectedOption]);
                AddWine();
                CoursesOptions();
            }
            else
            {
                windowInstanceStack.Push(MainMenu.DisplayMainMenu);
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
            return string.Join("\n", outCart);
        }
        return "Your cart is empty";
    }

    private static List<string> OptionString<T>(List<T> foodItems, bool justname = true) where T : class
    {
        List<string> outl = new();
        foreach (IFoodItems item in foodItems)
        {
            outl.Add(item.GetString(justname));
        }
        outl.Add("Go Back");
        return outl;
    }
}