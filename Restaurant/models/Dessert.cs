namespace Restaurant;

public class Dessert : IFoodItems
{
    public int ID { get; set; }
    public string DessertType { get; set; }
    public string DessertName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Allergens { get; set; }

    public Dessert(int id, string name, string description, decimal price, string allergens)
    {
        ID = id;
        DessertName = name;
        Description = description;
        Price = price;
        Allergens = allergens;
    }

    public decimal GetPrice() => Price;

    public string GetString(bool itemType)
    {
        if (itemType)
        {
            return $"{DessertType};
        }
        return $"{ID} | {DessertType}-course {DessertName} meal €{Price}\n  {Description}";
    }

}