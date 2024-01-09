namespace Restaurant;

public class AdminFood
{
    private static string dishesPath = @".\dataStorage\Dishes.json";
    private static string mealsPath = @".\dataStorage\Meals.json";
    private static string dessertsPath = @".\dataStorage\Desserts.json";
    private static string winesPath = @".\dataStorage\Wines.json";
    public static void SeeDishes(User user)
    {
        FormatJsonJ.FormatDishes();
        Console.WriteLine("Press enter to go back to change food menu");
        Console.ReadLine();
        AdminMenu.DisplayChangeFoodMenu(user); 
    }

    public static void SeeMeals(User user)
    {
        FormatJsonJ.FormatMeals();
        Console.WriteLine("Press enter to go back to change food menu");
        Console.ReadLine();
        AdminMenu.DisplayChangeFoodMenu(user); 
    }

    public static void SeeWines(User user)
    {
        FormatJsonJ.FormatWines();
        Console.WriteLine("Press enter to go back to change food menu");
        Console.ReadLine();
        AdminMenu.DisplayChangeFoodMenu(user); 
    }

    public static void SeeDesserts(User user)
    {
        FormatJsonJ.FormatDesserts();
        Console.WriteLine("Press enter to go back to change food menu");
        Console.ReadLine();
        AdminMenu.DisplayChangeFoodMenu(user); 
    }

    public static void AddDishA(User user)
    {
        SeeDishes(user);
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
            AdminMenu.DisplayChangeFoodMenu(user);
        }
        else
        {
                Console.WriteLine("Invalid");
        }
    }

    public static void AddMealA(User user)
    {
        SeeMeals(user); 
    
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

        bool mealAdded = foodManager.AddMeal(id, courseType, mealType, mealName, price, mealDescription);

        if (mealAdded)
        {
            Console.WriteLine("Meal added successfully!");
            AdminMenu.DisplayChangeFoodMenu(user);
        }
        else
        {
            Console.WriteLine("Invalid");
        }
    }

    public static void AddWineA(User user)
    {
        SeeWines(user); 
    
        FoodManager foodManager = new FoodManager();

        Console.WriteLine("Enter wine ID:");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter wine price:");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Enter alcoholPercentage:");
        double alcoholPercentage = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter wine type:");
        string wineType = Console.ReadLine();

        Console.WriteLine("Enter wine name:");
        string wineName = Console.ReadLine();

        Console.WriteLine("Enter wine description:");
        string description = Console.ReadLine();

        bool wineAdded = foodManager.AddWine(id, price, alcoholPercentage, wineType, wineName, description);

        if (wineAdded)
        {
            Console.WriteLine("Meal added successfully!");
            AdminMenu.DisplayChangeFoodMenu(user);
        }
        else
        {
            Console.WriteLine("Invalid");
        }
    }

    public static void AddDessertA(User user)
    {
        SeeDesserts(user); 
    
        FoodManager foodManager = new FoodManager();

        Console.WriteLine("Enter dessert ID:");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter dessert type:");
        int desserttypeid = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter dessert name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter dessert description:");
        string description = Console.ReadLine();

        Console.WriteLine("Enter dessert price:");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Enter dessert allergens:");
        string allergens = Console.ReadLine();

        bool dessertAdded = foodManager.AddDessert(id, desserttypeid, name, description, price, allergens);

        if (dessertAdded)
        {
            Console.WriteLine("Meal added successfully!");
            AdminMenu.DisplayChangeFoodMenu(user);
        }
        else
        {
            Console.WriteLine("Invalid");
        }
    }

    public static void RemoveDishA(User user)
    {
        SeeDishes(user);
        FoodManager foodManager = new FoodManager();

        Console.WriteLine("Enter the ID of the dish that you want to remove:");
        int id = Convert.ToInt32(Console.ReadLine());


        bool dishRemoved = foodManager.RemoveDish(id);

        if (dishRemoved)
        {
            Console.WriteLine("Dish removed successfully!");
            AdminMenu.DisplayChangeFoodMenu(user);
        }
        else
        {
            Console.WriteLine("Dish not found");
        }
    }


    public static void RemoveMealA(User user)
    {
        SeeMeals(user); 
        FoodManager foodManager = new FoodManager();

        Console.WriteLine("Enter the ID of the meal you want to remove:");
        int id = Convert.ToInt32(Console.ReadLine());

        bool mealRemoved = foodManager.RemoveMeal(id);

        if (mealRemoved)
        {
            Console.WriteLine("Meal removed successfully!");
            AdminMenu.DisplayChangeFoodMenu(user);
        }
        else
        {
            Console.WriteLine("Meal not found");
        }
    }

    public static void RemoveWineA(User user)
    {
        SeeMeals(user); 
        FoodManager foodManager = new FoodManager();

        Console.WriteLine("Enter the ID of the meal you want to remove:");
        int id = Convert.ToInt32(Console.ReadLine());

        bool mealRemoved = foodManager.RemoveMeal(id);

        if (mealRemoved)
        {
            Console.WriteLine("Meal removed successfully!");
            AdminMenu.DisplayChangeFoodMenu(user);
        }
        else
        {
            Console.WriteLine("Meal not found");
        }
    }
    public static void RemoveDessertA(User user)
    {
        SeeMeals(user); 
        FoodManager foodManager = new FoodManager();

        Console.WriteLine("Enter the ID of the meal you want to remove:");
        int id = Convert.ToInt32(Console.ReadLine());

        bool mealRemoved = foodManager.RemoveMeal(id);

        if (mealRemoved)
        {
            Console.WriteLine("Meal removed successfully!");
            AdminMenu.DisplayChangeFoodMenu(user);
        }
        else
        {
            Console.WriteLine("Meal not found");
        }
    }

    public static void RemAllDishes(User user)
    {
        FoodManager foodManager = new FoodManager();
        foodManager.Dishes.Clear();
        JsonUtil.UploadToJson(foodManager.Dishes, dishesPath);
        Console.WriteLine("All dishes removed successfully!");
        AdminMenu.DisplayChangeFoodMenu(user);
    }


}