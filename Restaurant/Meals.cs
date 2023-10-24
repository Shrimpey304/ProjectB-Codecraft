namespace Restaurant

public class Meals
{
    public string MealName { get; set; }
    public int Price { get; set; }
    public string FoodDescription { get; set; }

    public Meals(string mealName = "", int price = 0, string foodDescription = "")
    {
        MealName = mealName;
        Price = price;
        FoodDescription = foodDescription;
    }

    public string PickCourse(string choice)
    {
        new Meals("3-course meal.", 100, "This consists of a starter dish of Garlic & Herb Olive Oil Bread Dip or Caesar Salad, a main dish of Million Dollar Spaghetti Casserole, a side of Roasted Broccolini and for dessert Ricotta Cookies.");
        new Meals("4-course meal.", 140, "This consists of an appetizer of Spinach Artichoke Stuffed Mushrooms, then a refreshing Perfect French Onion Soup, an entrée of Port Braised Short Ribs and for dessert Flourless Chocolate Espresso Torte.");
        new Meals("5-course meal.", 160, "This consists of an Hors D'Oeuvre of Italian Meatballs cooked by our best chef, then a refreshing appetizer of Rosemary Focaccia, a calorie low rich tasting Garden Salad, a Chicken Parmigiana as an entrée and a delicious Sfogliatelle for dessert.");
        Console.WriteLine("Hello! Which full-course meal would you like to try? We have a three, four and five-course meal! ");
        choice = Console.ReadLine(); // 3 = 3 course, 4 = 4 course, 5 = 5 course
        if (choice == "3")
        {
            return "You have picked the three course meal!\n Your total price will be €100,- (excluding drinks)";
        }
        else if (choice == "4")
        {
            return "You have picked the luxurious four course meal!\n Your total price will be €140,- (including drinks)";
        }
        else if (choice == "5")
        {
            return "You have picked the mega-luxurious five course meal!\n Your total price will be €160,- (including drinks)";
        }
        else
        {
            return "Not a valid option, please choose between 3, 4 and 5";
        }
    }
    public decimal CalculateTotalPrice(Meals meal)
    {
        decimal total = 0;
        foreach meal
        {
            total += meal.Price; // calculates total price
        }
        return total;
    }

    public void ShowReceipt(Meals meal)
    {
        Console.WriteLine("Here's your receipt:");
        foreach meal
        {
            Console.WriteLine($"{meal.MealName} - {meal.Price}");
        }
        decimal totalPrice = CalculateTotalPrice(meal);
        Console.WriteLine($"Total price: {totalPrice}");
    }

}
