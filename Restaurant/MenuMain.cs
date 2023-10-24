namespace Restaurant;

using System;
public class MenuChoice
{
    public void ChooseMenu()
    {
        Console.WriteLine("Welcome to CodeCraft Cuisine!");
        Console.WriteLine("What would you like to order?");
        Console.WriteLine("1. Full-Course Meal");
        Console.WriteLine("2. Individual Dishes");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.WriteLine("Select a full-course meal:");
            Console.WriteLine("3. 3-course meal");
            Console.WriteLine("4. 4-course meal");
            Console.WriteLine("5. 5-course meal");

            string courseChoice = Console.ReadLine();
            Meals meals = new Meals();
            string result = meals.PickCourse(courseChoice);
            Console.WriteLine(result);
        }
        else if (choice == "2")
        {
            Dish dish = new Dish();
            List<Dish> selectedDishes = dish.PickMeal();

            Console.WriteLine("You have selected the following dishes:");
            foreach (Dish selectedDish in selectedDishes)
            {
                Console.WriteLine(selectedDish.Name);
            }

        }
        else
        {
            Console.WriteLine("Invalid choice. Please select 1 for full-course meal or 2 for individual dishes.");
        }
    }

}