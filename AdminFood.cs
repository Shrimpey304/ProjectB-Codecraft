namespace Restaurant;

public class AdminFood
{
    public static void SeeFoodA()
    {
        Console.WriteLine("test...");
    }

    public static void AddFoodA()
    {
        Console.WriteLine("test...");
    }

    public static void RemoveFoodA()
    {
        Console.WriteLine("test...");
    }

    public static void ChangeFoodA()
    {
        Console.WriteLine("test...");
    }

    public static void AddDishA()
    {
        Console.WriteLine("Enter Dish ID:");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Dish Type:");
        string dishtype = Console.ReadLine();

        Console.WriteLine("Enter Dish Name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Dish Description:");
        string description = Console.ReadLine();

        Console.WriteLine("Enter Dish Price:");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Enter Dish Allergens:");
        string allergens = Console.ReadLine();

        // Call AddDish method with input values
        bool added = AddDish(id, dishtype, name, description, price, allergens);

        if (added)
        {
            Console.WriteLine("Dish added successfully!");
        }
        else
        {
            Console.WriteLine("Failed to add dish. Dish ID already exists.");
        }
    }

}