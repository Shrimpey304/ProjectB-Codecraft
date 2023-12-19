namespace Restaurant;

public class AdminFood
{
    public static void SeeDishesB()
    {
        Console.WriteLine("Showing all dishes...");
        string json = File.ReadAllText(@".\dataStorage\Dishes.json");
        Console.WriteLine(json);
        Console.WriteLine("Go back");
        Console.ReadLine();

        AdminMenu.DisplayChangeFoodMenu();
    }

    public static void SeeDishes()
    {
        Console.WriteLine("Showing all dishes...");
        string json = File.ReadAllText(@".\dataStorage\Dishes.json");
        Console.WriteLine(json);
    }

    public static void SeeMeals()
    {
        Console.WriteLine("Showing all meals...");
        string json = File.ReadAllText(@".\dataStorage\Meals.json");
        Console.WriteLine(json);
    }

    public static void AddDishA()
    {
        SeeDishes();
        FoodManager foodManager = new FoodManager();

        Console.WriteLine("Enter dish ID:");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter dish type:");
        string dishType = Console.ReadLine();

        Console.WriteLine("Enter dish name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter dish description:");
        string description = Console.ReadLine();

        Console.WriteLine("Enter dish price:");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Enter dish allergens:");
        string allergens = Console.ReadLine();

        bool dishAdded = foodManager.AddDish(id, dishType, name, description, price, allergens);

        if (dishAdded)
        {
            Console.WriteLine("Dish added successfully!");
            AdminMenu.DisplayChangeFoodMenu();
        }
        else
        {
                Console.WriteLine("Invalid");
        }
    }

    public static void AddMealA()
    {
        SeeMeals(); 
    
        FoodManager foodManager = new FoodManager();

        Console.WriteLine("Enter meal ID:");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter course type:");
        int courseType = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter meal type:");
        string mealType = Console.ReadLine();

        Console.WriteLine("Enter meal name:");
        string mealName = Console.ReadLine();

        Console.WriteLine("Enter meal description:");
        string mealDescription = Console.ReadLine();

        Console.WriteLine("Enter meal price:");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        // Call the FoodManager's AddMeal method with the user input
        bool mealAdded = foodManager.AddMeal(id, courseType, mealType, mealName, price, mealDescription);

        if (mealAdded)
        {
            Console.WriteLine("Meal added successfully!");
            AdminMenu.DisplayChangeFoodMenu();
        }
        else
        {
            Console.WriteLine("Invalid");
        }
    }

    public static void RemoveDishA()
    {
        SeeDishes();
        FoodManager foodManager = new FoodManager();

        Console.WriteLine("Enter the ID of the dish that you want to remove:");
        int id = Convert.ToInt32(Console.ReadLine());


        bool dishRemoved = foodManager.RemoveDish(id);

        if (dishRemoved)
        {
            Console.WriteLine("Dish removed successfully!");
            AdminMenu.DisplayChangeFoodMenu();
        }
        else
        {
            Console.WriteLine("Dish not found");
        }
    }


    public static void RemoveMealA()
    {
        SeeMeals(); 
        FoodManager foodManager = new FoodManager();

        Console.WriteLine("Enter the ID of the meal you want to remove:");
        int id = Convert.ToInt32(Console.ReadLine());

        bool mealRemoved = foodManager.RemoveMeal(id);

        if (mealRemoved)
        {
            Console.WriteLine("Meal removed successfully!");
            AdminMenu.DisplayChangeFoodMenu();
        }
        else
        {
            Console.WriteLine("Meal not found");
        }
    }



    public static void ChangeFoodA()
    {
        Console.WriteLine("test...");
    }

    public static void RemAllDishes()
    {
        FoodManager foodManager = new FoodManager();
        foodManager.Dishes.Clear();
        JsonUtil.UploadToJson(foodManager.Dishes, @"C:dataStorage\Dishes.json");
        Console.WriteLine("All dishes removed successfully!");
        AdminMenu.DisplayChangeFoodMenu();
    }


}