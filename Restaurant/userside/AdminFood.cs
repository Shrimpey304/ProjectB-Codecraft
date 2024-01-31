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
        FormatJsonJ.FormatDishes();

        FoodManager foodManager = new FoodManager();

        int id;
    while (true)
    {
        Console.WriteLine("Enter dish ID:");
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
            continue;
        }
        break;
    }

        Console.WriteLine("Enter dish type:");
        string dishType = Console.ReadLine();

        Console.WriteLine("Enter dish name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter dish description:");
        string description = Console.ReadLine();

        decimal price;
    while (true)
    {
        Console.WriteLine("Enter dish price:");
        if (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric price.");
            continue; 
        }
        break; 
    }

        Console.WriteLine("Enter dish allergens:");
        string allergens = Console.ReadLine();

        bool dishAdded = foodManager.AddDish(id, dishType, name, description, price, allergens);

        if (dishAdded)
        {
            Console.WriteLine("Dish added successfully!");
            Thread.Sleep(2000);
            AdminMenu.DisplayChangeFoodMenu(user);
        }
        else
        {
                Console.WriteLine("Invalid");
                Console.WriteLine("Heading back to admin menu");
                Thread.Sleep(2000);
                AdminMenu.DisplayAdminMenu(user);
        }
    }

    public static void AddMealA(User user)
    {
        FormatJsonJ.FormatMeals();
    
        FoodManager foodManager = new FoodManager();

        int id;
    while (true)
    {
        Console.WriteLine("Enter meal ID:");
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
            continue; 
        }
        break; 
    }

        int courseType;
    while (true)
    {
        Console.WriteLine("Enter course type:");
        if (!int.TryParse(Console.ReadLine(), out courseType))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric course type.");
            continue; 
        }
        break;
    }

        Console.WriteLine("Enter meal type:");
        string mealType = Console.ReadLine();

        Console.WriteLine("Enter meal name:");
        string mealName = Console.ReadLine();

        Console.WriteLine("Enter meal description:");
        string mealDescription = Console.ReadLine();

        decimal price;
    while (true)
    {
        Console.WriteLine("Enter meal price:");
        if (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric price.");
            continue; 
        }
        break; 
    }

        bool mealAdded = foodManager.AddMeal(id, courseType, mealType, mealName, price, mealDescription);

        if (mealAdded)
        {
            Console.WriteLine("Meal added successfully!");
            Thread.Sleep(2000);
            AdminMenu.DisplayChangeFoodMenu(user);
        }
        else
        {
            Console.WriteLine("Invalid");
            Console.WriteLine("Heading back to admin menu");
            Thread.Sleep(2000);
            AdminMenu.DisplayAdminMenu(user);
        }
    }

    public static void AddWineA(User user)
    {
        FormatJsonJ.FormatWines();
    
        FoodManager foodManager = new FoodManager();

        int id;
    while (true)
    {
        Console.WriteLine("Enter wine ID:");
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
            continue;
        }
        break; 
    }

        decimal price;
    while (true)
    {
        Console.WriteLine("Enter wine price:");
        if (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric price.");
            continue; 
        }
        break; 
    }

        double alcoholPercentage;
    while (true)
    {
        Console.WriteLine("Enter alcohol percentage:");
        if (!double.TryParse(Console.ReadLine(), out alcoholPercentage))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric alcohol percentage.");
            continue; 
        }
        break; 
    }

        Console.WriteLine("Enter wine type:");
        string wineType = Console.ReadLine();

        Console.WriteLine("Enter wine name:");
        string wineName = Console.ReadLine();

        Console.WriteLine("Enter wine description:");
        string description = Console.ReadLine();

        bool wineAdded = foodManager.AddWine(id, price, alcoholPercentage, wineType, wineName, description);

        if (wineAdded)
        {
            Console.WriteLine("Wine added successfully!");
            Thread.Sleep(2000);
            AdminMenu.DisplayChangeFoodMenu(user);
        }
        else
        {
            Console.WriteLine("Invalid");
            Console.WriteLine("Heading back to admin menu");
            Thread.Sleep(2000);
            AdminMenu.DisplayAdminMenu(user);
        }
    }

    public static void AddDessertA(User user)
{
    FormatJsonJ.FormatDesserts();
    
    FoodManager foodManager = new FoodManager();

    int id;
    while (true)
    {
        Console.WriteLine("Enter dessert ID:");
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
            continue; 
        }
        break; 
    }

    int dessertTypeId;
    while (true)
    {
        Console.WriteLine("Enter dessert type:");
        if (!int.TryParse(Console.ReadLine(), out dessertTypeId))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric dessert type.");
            continue;
        }
        break; 
    }

    Console.WriteLine("Enter dessert name:");
    string name = Console.ReadLine();

    Console.WriteLine("Enter dessert description:");
    string description = Console.ReadLine();

    decimal price;
    while (true)
    {
        Console.WriteLine("Enter dessert price:");
        if (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric price.");
            continue; 
        }
        break;
    }

    Console.WriteLine("Enter dessert allergens:");
    string allergens = Console.ReadLine();

    bool dessertAdded = foodManager.AddDessert(id, dessertTypeId, name, description, price, allergens);

    if (dessertAdded)
    {
        Console.WriteLine("Dessert added successfully!");
        Thread.Sleep(2000);
        AdminMenu.DisplayChangeFoodMenu(user);
    }
    else
    {
        Console.WriteLine("Invalid");
        Console.WriteLine("Heading back to admin menu");
        Thread.Sleep(2000);
        AdminMenu.DisplayAdminMenu(user);
    }
}
    public static void RemoveDishA(User user)
    {
        FormatJsonJ.FormatDishes();
        FoodManager foodManager = new FoodManager();

        int id;
    while (true)
    {
        Console.WriteLine("Enter the ID of the dish that you want to remove:");
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
            continue;
        }
        break; 
    }


        bool dishRemoved = foodManager.RemoveDish(id);

        if (dishRemoved)
        {
            Console.WriteLine("Dish removed successfully!");
            Thread.Sleep(2000);
            AdminMenu.DisplayChangeFoodMenu(user);
        }
        else
        {
            Console.WriteLine("Dish not found");
            Console.WriteLine("Heading back to admin menu");
            Thread.Sleep(2000);
            AdminMenu.DisplayAdminMenu(user);
        }
    }


    public static void RemoveMealA(User user)
    {
        FormatJsonJ.FormatMeals();
        FoodManager foodManager = new FoodManager();

        int id;
    while (true)
    {
        Console.WriteLine("Enter the ID of the meal that you want to remove:");
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
            continue; 
        }
        break; 
    }

        bool mealRemoved = foodManager.RemoveMeal(id);

        if (mealRemoved)
        {
            Console.WriteLine("Meal removed successfully!");
            Thread.Sleep(2000);
            AdminMenu.DisplayChangeFoodMenu(user);
        }
        else
        {
            Console.WriteLine("Meal not found");
            Console.WriteLine("Heading back to admin menu");
            Thread.Sleep(2000);
            AdminMenu.DisplayAdminMenu(user);
        }
    }

    public static void RemoveWineA(User user)
    {
        FormatJsonJ.FormatWines();
        FoodManager foodManager = new FoodManager();

        int id;
    while (true)
    {
        Console.WriteLine("Enter the ID of the wine that you want to remove:");
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
            continue; 
        }
        break;
    }

        bool wineRemoved = foodManager.RemoveWine(id);

        if (wineRemoved)
        {
            Console.WriteLine("Wine removed successfully!");
            Thread.Sleep(2000);
            AdminMenu.DisplayChangeFoodMenu(user);
        }
        else
        {
            Console.WriteLine("Wine not found");
            Console.WriteLine("Heading back to admin menu");
            Thread.Sleep(2000);
            AdminMenu.DisplayAdminMenu(user);
        }
    }
    public static void RemoveDessertA(User user)
    {
        FormatJsonJ.FormatDesserts();
        FoodManager foodManager = new FoodManager();

        int id;
    while (true)
    {
        Console.WriteLine("Enter the ID of the dessert that you want to remove:");
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
            continue; 
        }
        break; 
    }

        bool dessertRemoved = foodManager.RemoveDessert(id);

        if (dessertRemoved)
        {
            Console.WriteLine("Dessert removed successfully!");
            Thread.Sleep(2000);
            AdminMenu.DisplayChangeFoodMenu(user);
        }
        else
        {
            Console.WriteLine("Dessert not found");
            Console.WriteLine("Heading back to admin menu");
            Thread.Sleep(2000);
            AdminMenu.DisplayAdminMenu(user);
        }
    }

    public static void RemAllDishes(User user)
    {
        FoodManager foodManager = new FoodManager();
        foodManager.Dishes.Clear();
        JsonUtil.UploadToJson(foodManager.Dishes, dishesPath);
        Console.WriteLine("All dishes removed successfully!");
        Thread.Sleep(2000);
        AdminMenu.DisplayChangeFoodMenu(user);
    }

    public static void RemAllMeals(User user)
    {
        FoodManager foodManager = new FoodManager();
        foodManager.Meals.Clear();
        JsonUtil.UploadToJson(foodManager.Meals, mealsPath);
        Console.WriteLine("All dishes removed successfully!");
        Thread.Sleep(2000);
        AdminMenu.DisplayChangeFoodMenu(user);
    }

    public static void RemAllDesserts(User user)
    {
        FoodManager foodManager = new FoodManager();
        foodManager.Desserts.Clear();
        JsonUtil.UploadToJson(foodManager.Desserts, dessertsPath);
        Console.WriteLine("All desserts removed successfully!");
        Thread.Sleep(2000);
        AdminMenu.DisplayChangeFoodMenu(user);
    }

    public static void RemAllWine(User user)
    {
        FoodManager foodManager = new FoodManager();
        foodManager.Wines.Clear();
        JsonUtil.UploadToJson(foodManager.Wines, winesPath);
        Console.WriteLine("All Wines removed successfully!");
        Thread.Sleep(2000);
        AdminMenu.DisplayChangeFoodMenu(user);
    }


}