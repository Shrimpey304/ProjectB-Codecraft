namespace Restaurant;

public class AdminEditDessert
{
    private static string dessertPath = @".\dataStorage\Desserts.json";
    private static List<Dessert> desserts = JsonUtil.ReadFromJson<Dessert>(dessertPath);

    private static Dessert GetDessertById()
    {
        Console.WriteLine("Enter the ID of the dessert you want to change:");
        int dessertID;
        if (!int.TryParse(Console.ReadLine(), out dessertID))
        {
            Console.WriteLine("Invalid input");
            Thread.Sleep(2000);
            return null;
        }

        Dessert dessertToChange = desserts.FirstOrDefault(d => d.ID == dessertID);

        if (dessertToChange == null)
        {
            Console.WriteLine("Dessert not found.");
            Thread.Sleep(2000);
        }

        return dessertToChange;
    }

    public static void ChangeDessertType(User user)
    {
        FormatJsonJ.FormatDesserts();
        Dessert dessertToChange = GetDessertById();

        if (dessertToChange != null)
        {
            Console.WriteLine("Enter the new dessert type for dessert:");
            int newDessertType = Convert.ToInt32(Console.ReadLine());

            //dessertToChange.DessertType = newDessertType;

            JsonUtil.UploadToJson(desserts, dessertPath);
            Console.WriteLine("Dessert type changed successfully.");
            Thread.Sleep(2000);
            AdminMenu.DisplayChangeFoodMenu(user);
        }
    }

    public static void ChangeDessertName(User user)
    {
        FormatJsonJ.FormatDesserts();
        Dessert dessertToChange = GetDessertById();

        if (dessertToChange != null)
        {
            Console.WriteLine("Enter new dessert name:");
            string newDessertName = Console.ReadLine();

             dessertToChange.DessertName = newDessertName;

            JsonUtil.UploadToJson(desserts, dessertPath);
            Console.WriteLine("Dessert name changed successfully.");
            Thread.Sleep(2000);
            AdminMenu.DisplayChangeFoodMenu(user);
        }
    }

    public static void ChangeDessertDescription(User user)
    {
        FormatJsonJ.FormatDesserts();
        Dessert dessertToChange = GetDessertById();

        if (dessertToChange != null)
        {
            Console.WriteLine("Enter new description:");
            string newDescription = Console.ReadLine();

             dessertToChange.Description = newDescription;

            JsonUtil.UploadToJson(desserts, dessertPath);
            Console.WriteLine("Description changed successfully.");
            Thread.Sleep(2000);
            AdminMenu.DisplayChangeFoodMenu(user);
        }    
    }

    public static void ChangeDessertPrice(User user)
    {
        FormatJsonJ.FormatDesserts();
        Dessert dessertToChange = GetDessertById();

        if (dessertToChange != null)
        {
            Console.WriteLine("Enter the new price for dessert:");
            decimal newPrice;
            if (!decimal.TryParse(Console.ReadLine(), out newPrice))
            {
                Console.WriteLine("Invalid input.");
                Thread.Sleep(2000);
                return;
            }

             dessertToChange.Price = newPrice;

            JsonUtil.UploadToJson(desserts, dessertPath);
            Console.WriteLine("Price changed successfully.");
            Thread.Sleep(2000);
            AdminMenu.DisplayChangeFoodMenu(user);
        }
    }

    public static void ChangeDessertAllergens(User user)
    {
        FormatJsonJ.FormatDesserts();
        Dessert dessertToChange = GetDessertById();

        if (dessertToChange != null)
        {
            Console.WriteLine("Enter the new allergens:");
            string newAllergens = Console.ReadLine();

            dessertToChange.Allergens = newAllergens;
            
            JsonUtil.UploadToJson(desserts, dessertPath);
            Console.WriteLine("Allergens changed successfully.");
            Thread.Sleep(2000);
            AdminMenu.DisplayChangeFoodMenu(user);
        }
    }
}