namespace Restaurant;

using System;
using System.Formats.Asn1;
using System.Net;

public static class MenuCard
{
    private static FoodManager manager = new();

    public static void FromMain() { Display(); }
    public static List<IFoodItems>? Display()
    {
        List<string> options = new(){
            "Full-Course Meal",
            "Individual Dishes",
            "Go Back"
        };
        List<Action> actions = new(){
            CoursesOptions,
            DishesOptions,
            MakeReservation.Display
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

    private static void DishesOptions()
    {
        List<string> option1 = OptionString<Dish>(manager.Dishes);
        int selectedOption = DisplayUtil.Display(option1);
        if (selectedOption < (option1.Count - 1))
        {
            Menu(option1[selectedOption], true);
        }
        else
        {
            Display();
        }
    }

    private static void CoursesOptions()
    {
        List<string> option1 = OptionString<Meals>(manager.Meals);
        int selectedOption = DisplayUtil.Display(option1);
        if (selectedOption < (option1.Count - 1))
        {
            Console.WriteLine("Are there any allergens you would like to remove? ");
            string answer = Console.ReadLine();
            string allergy = null;
            if (answer.ToLower() == "yes")
            {
                Console.WriteLine("Input allergy you want to remove: ");
                allergy = Console.ReadLine();
                FoodManager.RemoveAllergens(allergy);
                Console.WriteLine($"We have removed {allergy} from your meal(s)");
            }
            Menu(option1[selectedOption]);
        }
        else
        {
            Display();
        }
    }

    private static void Menu(string itemType, bool dish = false)
    {
        if (dish)
        {
            List<IFoodItems> dishes = manager.GetDishes(itemType);
            List<string> option3 = OptionString(dishes, false);
            int selectedOption1 = DisplayUtil.Display(option3);
            if (selectedOption1 < (option3.Count - 1))
            {
                Console.WriteLine("Are there any allergens you would like to remove? ");
                string answer = Console.ReadLine();
                string allergy = null;
                if (answer.ToLower() == "yes")
                {
                    Console.WriteLine("Input allergy you want to remove: ");
                    allergy = Console.ReadLine();
                    FoodManager.RemoveAllergens(allergy);
                    Console.WriteLine($"We have removed {allergy} from your meal(s)");
                }
                System.Console.WriteLine("Item added to cart.");
                manager.AddToCart(dishes[selectedOption1]);
                DishesOptions();
            }
            else
            {
                Display();
            }
        }
        else
        {
            List<IFoodItems> meals = manager.GetMeals(itemType);
            System.Console.WriteLine($"{itemType}, {meals.Count}");

            List<string> option2 = OptionString(meals, false);
            int selectedOption = DisplayUtil.Display(option2);
            if (selectedOption < (option2.Count - 1))
            {
                System.Console.WriteLine("Item added to cart. $_$");
                manager.AddToCart(meals[selectedOption]);
                CoursesOptions();
            }
            else
            {

                Display();
            }
        }
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