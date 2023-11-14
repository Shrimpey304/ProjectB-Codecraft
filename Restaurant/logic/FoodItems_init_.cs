namespace Restaurant;

public static class FoodItems_init_
{
    public static List<Dish> LoadDishes(string fileName)
    {
        List<Dish> dishes;
        try
        {
            dishes = JsonUtil.ReadFromJson<Dish>(fileName);
            if (dishes is null)
            {
                throw new NullReferenceException();
            }
            return dishes;
        }
        catch (NullReferenceException)
        {
            dishes = PopulateDishes();
            JsonUtil.UploadToJson<Dish>(dishes, fileName);
            return dishes;
        }
    }

    public static List<Meals> LoadMeals(string fileName)
    {
        List<Meals> meals;
        try
        {
            meals = JsonUtil.ReadFromJson<Meals>(fileName);
            if (meals is null)
            {
                throw new NullReferenceException();
            }
            return meals;
        }
        catch (NullReferenceException)
        {
            meals = PopulateMeals();
            JsonUtil.UploadToJson<Meals>(meals, fileName);
            return meals;
        }
    }

    internal static List<Dish> PopulateDishes()
    {
        List<Dish> dishes = new(){
            new Dish(1, "Chicken", "chicken nuggies", "sum gas nugs", 12.90M, "RS")
        };
        return dishes;
    }

    internal static List<Meals> PopulateMeals()
    {
        List<Meals> meals = new(){
            new Meals(1, 3, "fish", "bomama", 56.90M, "etaboma")
        };
        return meals;
    }
}
