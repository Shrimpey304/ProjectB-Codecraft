namespace Restaurant;

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
        Console.WriteLine("Hello! Which full-course meal would you like to try? We have a three, four and five-course meal! ");
        choice = Console.ReadLine(); // 3 = 3 course, 4 = 4 course, 5 = 5 course
        if (choice == "3")
        {
            return "You have picked the three course meal! This consists of a starter dish of Garlic & Herb Olive Oil Bread Dip or Caesar Salad, a main dish of Million Dollar Spaghetti Casserole, a side of Roasted Broccolini and for dessert Ricotta Cookies.";
        }
        else if (choice == "4")
        {
            return "You have picked the luxurious four course meal! This consists of an appetizer of Spinach Artichoke Stuffed Mushrooms, then a refreshing Perfect French Onion Soup, an entrée of Port Braised Short Ribs and for dessert Flourless Chocolate Espresso Torte.";
        }
        else if (choice == "5")
        {
            return "You have picked the luxurious five course meal! This consists of an Hors D'Oeuvre of Italian Meatballs cooked by our best chef, then a refreshing appetizer of Rosemary Focaccia, a calorie free rich tasting Garden Salad, a Chicken Parmigiana as an entrée and a delicious Sfogliatelle for dessert.";
        }
        else
        {
            return "Not a valid option, please choose between 3, 4 and 5";
        }
    }

    public string PickMeal(string choice)
    {

        string[] dishes = new string[]
    {
        "Spanish Iberian Ham served on Densuke Watermelons. €21,99",
        "Beluga Caviar. €27,99",
        "Tuna Empanadillas. €20,99 (gluten, lactose)",
        "Butter chicken vol-au-vents. €15,99 (gluten, lactose)",
        "Fresh Spaghettoni with Italian White Alba Truffle. €32,99 (gluten, egg, lactose)",
        "Crab stuffed Filet Mignon with Whiskey Peppercorn sauce. €39,99",
        "Wagyu Beef. €89,99"
    };

        Console.WriteLine("Hello and welcome to CodeCraft Cuisine, home of the worlds finest dishes and courses. We have a large variety of meals you can pick from. The starters consists of:");
        for (int i = 0; i < dishes.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {dishes[i]}");
        }
        choice = Console.ReadLine();
        if (int.TryParse(choice, out int choiceIndex) && choiceIndex >= 1 && choiceIndex <= dishes.Length)
        {
            // Get the selected dish's name
            string selectedDish = dishes[choiceIndex - 1];
            return $"You have picked {selectedDish}, good choice!";
        }
        else
        {
            return "Invalid choice. Please select a valid dish number.";
        }
    }


}
