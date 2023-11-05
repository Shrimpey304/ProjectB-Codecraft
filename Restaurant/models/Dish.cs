namespace Restaurant;

public class Dish : IFoodItems
{
    public int ID {get;set;}
    public string DishType {get;set;}
    public string DishName {get;set;}
    public string Description {get;set;}
    public decimal Price {get;set;}
    public string Allergens {get;set;}

    public Dish(int id, string dishtype, string name, string description, decimal price, string allergens)
    {
        ID = id;
        DishType = dishtype;
        DishName = name;
        Description = description;
        Price = price;
        Allergens = allergens;
    }

    public decimal GetPrice() => Price;
    public string GetString(bool itemType=false)
    {
        if (itemType)
        {
            return $"{DishType}";
        }
        return $"{ID} | {DishType}\n  {DishName}  €{Price}\n   {Description}\n   Contains:{Allergens}";
    }
}
