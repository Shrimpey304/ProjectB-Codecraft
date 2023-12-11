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
                System.Console.WriteLine("Item added to cart. $_$");
                manager.AddToCart(meals[selectedOption]);
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