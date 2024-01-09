namespace Restaurant;

public class Dish : IFoodItems
{
    public int ID {get;set;}
    public string DishName {get;set;}
    public string Description {get;set;}
    public decimal Price {get;set;}
    public string Allergens {get;set;}
    public string? RemovedA = null;

    public Dish(int id, string name, string description, decimal price, string allergens)
    {
        ID = id;
        DishName = name;
        Description = description;
        Price = price;
        Allergens = allergens;
    }


    public decimal GetPrice() => Price;
    public string GetString(bool itemType=false, bool incart=false)
    {
        if (itemType)
        {
            return !incart ? $"{DishName}" :  $"{Price}\n{Description}\nContains:{Allergens}\nAllergens removed:{(RemovedA is not null ? RemovedA : "No allergens removed")}\n------------";
        }
        return $" {DishName}  {Price}\nDescription: {Description}\nContains:{Allergens}\nAllergens removed:{(RemovedA is not null ? RemovedA : "No allergens removed")}\n------------";
    }

}
