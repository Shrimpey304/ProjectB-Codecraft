namespace Restaurant;

public class AdminEditDish
{
    private static string dishPath = @".\dataStorage\Dishes.json";
    private static List<Dish> dishes = JsonUtil.ReadFromJson<Dish>(dishPath);

    private static Dish GetDishById()
    {
        Console.WriteLine("Enter the ID of the dish you want to change:");
        int dishID;
        if (!int.TryParse(Console.ReadLine(), out dishID))
        {
            Console.WriteLine("Invalid input");
            return null;
        }

        Dish dishToChange = dishes.FirstOrDefault(d => d.ID == dishID);

        if (dishToChange == null)
        {
            Console.WriteLine("Dish not found.");
        }

        return dishToChange;
    }

    public static void ChangeDishName(User user)
    {
        FormatJsonJ.FormatDishes();
        Dish dishToChange = GetDishById();

        if (dishToChange != null)
        {
            Console.WriteLine("Enter new dish name:");
            string newDishName = Console.ReadLine();

             dishToChange.DishName = newDishName;

            JsonUtil.UploadToJson(dishes, dishPath);
            Console.WriteLine("Dish name changed successfully.");
            AdminMenu.DisplayChangeFoodMenu(user);
        }
    }

    public static void ChangeDishDescription(User user)
    {
        FormatJsonJ.FormatDishes();
        Dish dishToChange = GetDishById();

        if (dishToChange != null)
        {
            Console.WriteLine("Enter new description:");
            string newDescription = Console.ReadLine();

             dishToChange.Description = newDescription;

            JsonUtil.UploadToJson(dishes, dishPath);
            Console.WriteLine("Description changed successfully.");
            AdminMenu.DisplayChangeFoodMenu(user);
        }    
    }

    public static void ChangeDishPrice(User user)
    {
        FormatJsonJ.FormatDishes();
        Dish dishToChange = GetDishById();

        if (dishToChange != null)
        {
            Console.WriteLine("Enter the new price for dish:");
            decimal newPrice;
            if (!decimal.TryParse(Console.ReadLine(), out newPrice))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

             dishToChange.Price = newPrice;

            JsonUtil.UploadToJson(dishes, dishPath);
            Console.WriteLine("Price changed successfully.");
            AdminMenu.DisplayChangeFoodMenu(user);
        }
    }

    public static void ChangeDishAllergens(User user)
    {
        FormatJsonJ.FormatDishes();
        Dish dishToChange = GetDishById();

        if (dishToChange != null)
        {
            Console.WriteLine("Enter the new allergens:");
            string newAllergens = Console.ReadLine();

            dishToChange.Allergens = newAllergens;
            
            JsonUtil.UploadToJson(dishes, dishPath);
            Console.WriteLine("Allergens changed successfully.");
            AdminMenu.DisplayChangeFoodMenu(user);
        }
    }

    public static void ChangeDishType(User user)
    {
        FormatJsonJ.FormatDishes();
        Dish dishToChange = GetDishById();

        if (dishToChange != null)
        {
            Console.WriteLine("Enter the new dish type for dish:");
            string newDishType = Console.ReadLine();

//             dishToChange.DishType = newDishType;

            JsonUtil.UploadToJson(dishes, dishPath);
            Console.WriteLine("Dish type changed successfully.");
            AdminMenu.DisplayChangeFoodMenu(user);
        }
    }
}
