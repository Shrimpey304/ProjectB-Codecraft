namespace Restaurant;

public class Dessert : IFoodItems
{
    public int ID { get; set; }
    public int DessertType { get; set; }
    public string DessertName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Allergens { get; set; }

    public Dessert(int id, int desserttypeid, string name, string description, decimal price, string allergens)
    {
        ID = id;
        DessertType = desserttypeid;
        DessertName = name;
        Description = description;
        Price = price;
        Allergens = allergens;
    }

    public decimal GetPrice() => Price;

    public string GetString(bool itemType=false, bool incart=false)
    {
        if (itemType)
        {
            return !incart ? $"{DessertType}" : $"{ID} | {DessertType}-course {DessertName} meal €{Price}\n  {Description}";
        }
        return $"{ID} | {DessertType}-course {DessertName} meal €{Price}\n  {Description}";
    }

}