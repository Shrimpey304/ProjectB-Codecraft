namespace Restaurant;

using System;
public class MenuMain
{
    public void MenuMainFunc()
    {
        Console.WriteLine("Welcome to CodeCraft Cuisine!");
        Console.WriteLine("What would you like to order?");
        Console.WriteLine("1. Full-Course Meal");
        Console.WriteLine("2. Individual Dishes");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Meals meals = new Meals();
            Console.WriteLine(meals.PickCourse(choice));
        }
        else if (choice == "2")
        {
            Dish dish = new Dish();
            Console.WriteLine(dish.PickMeal(choice));
        }
        else
        {
            Console.WriteLine("Invalid choice. Please select 1 for full-course meal or 2 for individual dishes.");
        }
    }

}