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
            new Dish(1, "Chicken", "chicken nuggets", "deep fried chicken nuggets cooked in organic oil", 12.90M, "RS"),
            new Dish(2, "Meat", "Cheeseburger" , "A tasty cheesburger using authentic American cheddar cheese, fresh pickles and onion, A4 waguy beef and homemade brioche buns.", 15.20m, "Gluten, lactose"),
            new Dish(3, "Chicken", "Chicken Ramen", "Our house delicacy cooked by one of the most famous ramen chefs: Kazumoto Ochiai. This ramen consists of some roasted chicken, ramen noodles, veggies and a soft cooked egg.", 21.50m, ""),
            new Dish(4, "Vegan", "Coconut rice bowls", "Delicious, vegan Coconut Rice Bowls are healthy and adaptable!  Curried jasmine rice cooked in coconut milk and topped with tofu (or your choice of protein) and seasonal vegetables.  All tossed with a simple, flavorful sauce, fresh cilantro, mint and toasted coconut flakes. A flavorful vegan meal, bursting with so much flavor!", 17.50m, ""),
            new Dish(5, "Fish", "Fish and chips", "Dive into a British tradition with our Classic Fish and Chips. Enjoy golden, crispy battered fish, paired with thick-cut, perfectly fried potato chips. Served with a side of tartar sauce and a slice of lemon, it's a satisfying, time-honored favorite.", 12.99m, "gluten, fish"),
            new Dish(6, "Meat", "Moroccan Spice-Rubbed Lamb Tagine", "This exotic dish consists of tender succulent pieces of lamb that are marinated in a blend of North African spices slow-cooked in a traditional tagine, and served with fluffy couscous.", 21.99m, "gluten, nuts")
        };
        return dishes;
    }

    internal static List<Dessert> PopulateDesserts()
    {
        List<Dessert> desserts = new(){
            new Dessert(1, 2, "Chocolate", "Indulge in the ultimate chocolate lover's dream with our Chocolate Lava Cake. Crack open the delicate shell to reveal a warm, oozing center of rich dark chocolate. Served with a scoop of vanilla bean ice cream and a sprinkle of powdered sugar, it's the perfect balance of warm, cold, and sweet, making each bite a heavenly indulgence.", 7.99m, "Dairy, eggs and gluten."),
            new Dessert(2, 2, "Pie", "Our Caramel Pecan Pie is a slice of southern comfort. A buttery, flaky crust cradles a generous filling of pecans in a rich caramel sauce. Served warm with a dollop of whipped cream.", 9.99m, "dairy, nuts, gluten"),
            new Dessert(3, 2, "Cake", "A Creamy New York-style cheesecake topped with a medley of fresh berries and a raspberry coulis, creating a sweet and tangy masterpiece.", 10.99m, "dairy, gluten"),
            new Dessert(4, 2, "Sorbet", "Refresh your palate with our zesty Lemon Sorbet. This light and tangy sorbet is the perfect way to cleanse you after a savory meal or as a delightful, guilt-free dessert.", 5.99m ,"suitable for vegans and those with dairy allergies"),
            new Dessert(5, 2, "Divine", "Elevate your dining experience with The Grand Golden Symphony, our most opulent dessert creation. This masterpiece is a symphony of a luxurious 24-karat edible gold leaf-encased dark chocolate sphere that hides a decadent surprise within. While pouring a warm raspberry coulis over the sphere it starts melting  revealing a luscious core of Belgian chocolate mousse infused with rare, hand-harvested Tahitian vanilla beans. The spectacle continues as a scoop of Madagascar vanilla bean ice cream is crowned with white truffle shavings, and a sprinkle of saffron-infused golden sugar adds a delicate touch of sweetness. Handpicked seasonal berries and a delicate spun sugar sculpture complete this extravagant masterpiece. Every bite of The Grand Golden Symphony is a journey of pure luxury, delighting the senses and creating a lasting memory of culinary excellence.", 49.99m, "dairy, nuts, gluten")
        };
        return desserts;
    }

    internal static List<Meals> PopulateMeals()
    {
        List<Meals> meals = new(){
            new Meals(1, 3, "fish", "salmon", 56.90M, "its smoked...")
        };
        return meals;
    }
    internal static List<Wine> PopulateWine()
    {
        List<Wine> wine = new()
        {
            new Wine(1, 50.99m, 14.7, "Rosé", "Magnum Château", "High quality sweet yet dry rosé wine imported straight from Lyon, France"),
            new Wine(2, 89.99m, 16.3, "White", "Joseph Drouhin Meursault Porusots", "Luxurious dry white wine hand-harvested from our own vineyard estates in the NorthEastern region of italy Friuli-Venezia Giulia."),
            new Wine(3, 100.00m, 15.3, "White", "Château Suduiraut Sauternes", "This sweet white wine is one of the finest wines in our product range."),
            new Wine(4, 149.99m, 15.7, "Red", "Cavallotto Barolo Riserva Bricco Boschis Vigna San Giuseppe", "This delicious red whine could be considered a masterpiece by some. The delicate balance of flavours between the sweetness of the grapes and the sourness of the vinegar are unmatched in this classic Italian treasure.")
        };
        return wine;
    }
}
