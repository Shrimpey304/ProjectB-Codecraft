using System.Runtime.CompilerServices;

namespace Restaurant;

public class FoodManager
{
    public List<Dish> Dishes { get; set; }
    public List<Meals> Meals { get; set; }
    public List<Wine> Wines { get; set; }
    public List<Dessert> Desserts { get; set; }
    public List<IFoodItems> Cart = new();
    public User? User { get; set; }
    private readonly string[] fileNames = { @"C:dataStorage\Dishes.json", @"C:dataStorage\Meals.json", @"C:dataStorage\Wines.json", @"C:dataStorage\Desserts.json"  };

    public FoodManager()
    {
        Dishes = FoodItems_init_.LoadDishes(fileNames[0]);
        Meals = FoodItems_init_.LoadMeals(fileNames[1]);
    }

    public bool AddDish(int id, string dishname, string name, string description, decimal price, string allergens)
    {
        if (!Dishes.Exists(item => item.DishName == dishname))
        {
            Dish dish = new(id, name, description, price, allergens);
            Dishes.Add(dish);
            JsonUtil.UploadToJson(Dishes, fileNames[0]);
            return true;
        }
        return false;
    }

    public bool AddMeal(int id, int coursetype, string mealtype, string mealname, decimal price, string coursedescription)
    {
        if (!Meals.Exists(item => item.ID == id))
        {
            Meals meal = new(id, coursetype, mealtype, mealname, price, coursedescription);
            Meals.Add(meal);
            JsonUtil.UploadToJson(Meals, fileNames[1]);
            return true;
        }
        return false;
    }

    public bool AddWine(int id, decimal price, double alcoholPercentage, string wineType, string wineName, string description)
    {
        if (!Wines.Exists(item => item.ID == id))
        {
            Wine wine = new(id, price, alcoholPercentage, wineType, wineName, description);
            Wines.Add(wine);
            JsonUtil.UploadToJson(Wines, fileNames[2]);
            return true;
        }
        return false;
    }

    public bool AddDessert(int id, int desserttypeid, string name, string description, decimal price, string allergens)
    {
        if (!Desserts.Exists(item => item.ID == id))
        {
            Dessert dessert = new(id, desserttypeid, name, description, price, allergens);
            Desserts.Add(dessert);
            JsonUtil.UploadToJson(Desserts, fileNames[3]);
            return true;
        }
        return false;
    }

    public bool RemoveDish(int id)
    {
        if (Dishes.Exists(item => item.ID == id))
        {
            Dish dish = Dishes.Find(item => item.ID == id)!;
            Dishes.Remove(dish);
            JsonUtil.UploadToJson(Dishes, fileNames[0]);
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
            JsonUtil.UploadToJson(Meals, fileNames[1]);
            return true;
        }
        return false;
    }

    public bool RemoveWine(int id)
    {
        if (Wines.Exists(item => item.ID == id))
        {
            Wine wine = Wines.Find(item => item.ID == id)!;
            Wines.Remove(wine);
            JsonUtil.UploadToJson(Wines, fileNames[2]);
            return true;
        }
        return false;
    }

    public bool RemoveDessert(int id)
    {
        if (Desserts.Exists(item => item.ID == id))
        {
            Dessert dessert = Desserts.Find(item => item.ID == id)!;
            Desserts.Remove(dessert);
            JsonUtil.UploadToJson(Desserts, fileNames[3]);
            return true;
        }
        return false;
    }

    public List<IFoodItems> GetDishes(string name)
    {
        List<IFoodItems> dishes = new();
        if (Dishes.Any(item => item.DishName == name))
        {
            Dish dish = Dishes.Find(item => item.DishName == name)!;
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
            Meals meal = Meals.Find(item => item.MealType == type)!;
            meals.Add(meal);
            return meals;
        }
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
