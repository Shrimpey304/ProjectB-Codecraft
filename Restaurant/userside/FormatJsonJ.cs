namespace Restaurant;

public class FormatJsonJ
{
    private static string dishesPath = @".\dataStorage\Dishes.json";
    private static string mealsPath = @".\dataStorage\Meals.json";
    private static string dessertsPath = @".\dataStorage\Desserts.json";
    private static string winesPath = @".\dataStorage\Wines.json";
    private static string tablesPath = @".\dataStorage\Tables.json";
    private static string accountPath = @".\dataStorage\account.json";
    private static string reservationPath = @".\dataStorage\Reservations.json";

    public static void FormatDishes()
    {
        List<Dish> dishes = JsonUtil.ReadFromJson<Dish>(dishesPath);
        Console.WriteLine("Dishes:");
        Console.WriteLine("--------------");
        foreach (var dish in dishes)
            {
                Console.WriteLine($"ID: {dish.ID}");
                Console.WriteLine($"Dish name: {dish.DishName}");
                Console.WriteLine($"Dish description: {dish.Description}");
                Console.WriteLine($"Dish price: {dish.Price}");
                Console.WriteLine($"Dish allergens: {dish.Allergens}");
                Console.WriteLine("--------------");
            }
    }

    public static void FormatMeals()
    {
        List<Meals> meals = JsonUtil.ReadFromJson<Meals>(mealsPath);
        Console.WriteLine("Meals:");
        Console.WriteLine("--------------");
        foreach (var meal in meals)
            {
                Console.WriteLine($"ID: {meal.ID}");
                Console.WriteLine($"Dish type: {meal.CourseType}");
                Console.WriteLine($"Dish name: {meal.MealType}");
                Console.WriteLine($"Dish description: {meal.MealName}");
                Console.WriteLine($"Dish price: {meal.Price}");
                Console.WriteLine($"Dish allergens: {meal.CourseDescription}");
                Console.WriteLine("--------------");
            }
    }

    public static void FormatDesserts()
    {
        List<Dessert> desserts = JsonUtil.ReadFromJson<Dessert>(dessertsPath);
        Console.WriteLine("Desserts:");
        Console.WriteLine("--------------");
        foreach (var dessert in desserts)
            {
                Console.WriteLine($"ID: {dessert.ID}");
                Console.WriteLine($"Dish type: {dessert.DessertType}");
                Console.WriteLine($"Dish name: {dessert.DessertName}");
                Console.WriteLine($"Dish description: {dessert.Description}");
                Console.WriteLine($"Dish price: {dessert.Price}");
                Console.WriteLine($"Dish allergens: {dessert.Allergens}");
                Console.WriteLine("--------------");
            }
    }

    public static void FormatWines()
    {
        List<Wine> wines = JsonUtil.ReadFromJson<Wine>(winesPath);
        Console.WriteLine("Wines:");
        Console.WriteLine("--------------");
        foreach (var wine in wines)
            {
                Console.WriteLine($"ID: {wine.ID}");
                Console.WriteLine($"Dish type: {wine.Price}");
                Console.WriteLine($"Dish allergens: {wine.AlcoholPercentage}");
                Console.WriteLine($"Dish name: {wine.WineType}");
                Console.WriteLine($"Dish description: {wine.WineName}");
                Console.WriteLine($"Dish price: {wine.Description}");
                Console.WriteLine("--------------");
            }
    }

    public static void FormatTables()
    {
        List<Table> tables = JsonUtil.ReadFromJson<Table>(tablesPath);
        Console.WriteLine("Tables:");
        Console.WriteLine("--------------");
        foreach (var table in tables)
        {
            Console.WriteLine($"Position: {table.Position}");
            Console.WriteLine($"Type: {table.Type}");
            Console.WriteLine("--------------");
        }
    }

    public static void FormatAccs()
    {
        List<User> users = JsonUtil.ReadFromJson<User>(accountPath);
        Console.WriteLine("Accounts:");
        Console.WriteLine("--------------");
        foreach (var user in users)
            {
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Password: {user.Password}");
                Console.WriteLine($"Phone Number: {user.PhoneNumber}");
                Console.WriteLine($"Admin: {(user.Admin ? "True" : "False")}");
                Console.WriteLine("--------------");
            }
    }

}