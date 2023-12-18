namespace Restaurant;

public class FoodManager
{
    public List<Dish> Dishes { get; set; }
    public List<Meals> Meals { get; set; }
    public List<IFoodItems> Cart = new();
    public User? User { get; set; }
    private readonly string[] fileNames = { @"C:dataStorage\Dishes.json", @"C:dataStorage\Meals.json" };

    public FoodManager()
    {
        Dishes = FoodItems_init_.LoadDishes(fileNames[0]);
        Meals = FoodItems_init_.LoadMeals(fileNames[1]);
    }

    public bool AddDish(int id, string dishtype, string name, string description, decimal price, string allergens)
    {
        if (!Dishes.Exists(item => item.ID == id))
        {
            Dish dish = new(id, dishtype, name, description, price, allergens);
            Dishes.Add(dish);
        }
        return false;
    }

    public bool AddMeal(int id, int coursetype, string mealtype, string mealname, decimal price, string coursedescription)
    {
        if (!Meals.Exists(item => item.ID == id))
        {
            Meals meal = new(id, coursetype, mealtype, mealname, price, coursedescription);
            Meals.Add(meal);
        }
        return false;
    }

    public bool RemoveDish(int id)
    {
        if (Dishes.Exists(item => item.ID == id))
        {
            Dish dish = Dishes.Find(item => item.ID == id)!;
            Dishes.Remove(dish);
            return true;
        }
        return false;
    }

    public bool RemoveMeal(int id)
    {
        if (Meals.Exists(item => item.ID == id))
        {
            Meals meal = Meals.Find(item => item.ID == id)!;
            Meals.Remove(meal);
            return true;
        }
        return false;
    }

    public List<IFoodItems> GetDishes(string type)
    {
        List<IFoodItems> dishes = new();
        if (Dishes.Any(item => item.DishType == type))
        {
            Dish dish = Dishes.Find(item => item.DishType == type)!;
            dishes.Add(dish);
            return dishes;
        }
        return dishes;
    }

    public List<IFoodItems> GetMeals(string type)
    {
        List<IFoodItems> meals = new();
        if (Meals.Exists(item => item.MealType == type))
        {
            System.Console.WriteLine("yep");
            Meals meal = Meals.Find(item => item.MealType == type)!;
            meals.Add(meal);
            return meals;
        }
        System.Console.WriteLine(type);
        return meals;
    }

    public static string RemoveAllergens(string allergy)
    {
        if (Allergen.allergenList.Contains(allergy))
        {
            return $"We have removed {allergy} from your meal(s)";
        }
        return "This allergy is nowhere to be found in any of our meals";
    }

    public void AddToCart(IFoodItems foodItems)
    {
        Cart.Add(foodItems);
    }

    public static decimal GetTotal(IEnumerable<IFoodItems> cart)
    {
        decimal total = 0.0m;
        foreach (var item in cart)
        {
            total += item.GetPrice();
        }
        return total;
    }
    
}
