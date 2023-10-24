using System.Xml.Serialization;

public class Dish
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Allergens { get; set; }

    public Dish(string name = "", decimal price = 0, string allergens = "")
    {
        Name = name;
        Price = price;
        Allergens = allergens;
    }


    public void DisplayMenu(Dish[] dishes)
    {
        Console.WriteLine("Welcome to CodeCraft Cuisine, where you can enjoy our delicious full-course meals and dishes.");
        Console.WriteLine("Here's our menu:");

        for (int i = 0; i < dishes.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {dishes[i].Name} - €{dishes[i].Price} ({dishes[i].Allergens})");
        }
    }
    public List<Dish> PickMeal()
    {
        Dish[] dishes = new Dish[]
        {
        new Dish("Spanish Iberian Ham served on Densuke Watermelons.", 21.99m, ""),
        new Dish("Beluga Caviar.", 27.99m, ""),
        new Dish("Tuna Empanadillas.", 20.99m, "gluten, lactose"),
        new Dish("Butter chicken vol-au-vents.", 15.99m, "gluten, lactose"),
        new Dish("Fresh Spaghettoni with Italian White Alba Truffle.", 32.99m, "gluten, egg, lactose"),
        new Dish("Crab stuffed Filet Mignon with Whiskey Peppercorn sauce.", 39.99m, "lactose"),
        new Dish("Wagyu Beef.", 89.99m, "")
        };
        DisplayMenu(dishes);
        List<Dish> selectedDishes = new List<Dish>();
        bool continueChoosing = true;
        while (continueChoosing)
        {
            Console.WriteLine("Please enter the number of the dish you would like to try or type done if you're satisfied with what you've ordered: ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "done")
            {
                Console.WriteLine("Enjoy your meal!");
                continueChoosing = false;
            }
            else if (int.TryParse(choice, out int choiceIndex) && choiceIndex >= 0 && choiceIndex < dishes.Length)
            {
                selectedDishes.Add(dishes[choiceIndex]);
                Console.WriteLine($"Added '{dishes[choiceIndex].Name}' to your selection.");
            }
            else
            {
                Console.WriteLine("Invalid choice, try again.");
            }
        }
        return selectedDishes;
    }

    public decimal CalculatePrice(Dish[] dishes, string choice)
    {
        if (int.TryParse(choice, out int choiceIndex) && choiceIndex >= 1 && choiceIndex <= dishes.Length)
        {
            // Get the selected dish's price
            decimal selectedDishPrice = dishes[choiceIndex - 1].Price;
            return selectedDishPrice;
        }
        else
        {
            Console.WriteLine("Invalid choice. Please select a valid dish number.");
            return 0.0m; // Return 0 if the choice is invalid
        }
    }

    public decimal CalculateTotalPrice(List<Dish> selectedDishes)
    {
        decimal total = 0;
        foreach (Dish dish in selectedDishes) // goes through every dish in the list
        {
            total += dish.Price; //adds the price of each individual dish to the total variable
        }
        return total; //returns the total price
    }

    public void ShowReceipt(List<Dish> selectedDishes)
    {
        Console.WriteLine($"Here's your receipt:");
        foreach (Dish dish in selectedDishes)
        {
            Console.WriteLine($"{dish.Name} - €{dish.Price}"); //shows all the dishes you've ordered plus the according prices
        }
        decimal totalPrice = CalculateTotalPrice(selectedDishes); //uses the CalctotalPrice method to calculate your total price
        Console.WriteLine($"Total Price: €{totalPrice}");
    }
}

