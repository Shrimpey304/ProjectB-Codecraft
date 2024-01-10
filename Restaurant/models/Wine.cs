using Restaurant;

public class Wine : IFoodItems
{
    public int ID { get; set; }
    public decimal Price { get; set; }
    public double AlcoholPercentage { get; set; }
    public string WineType { get; set; }
    public string WineName { get; set; }
    public string Description { get; set; }
    public const int Size = 1; //in liters

    public Wine(int id, decimal price, double alcoholPercentage, string wineType, string wineName, string description)
    {
        ID = id;
        Price = price;
        AlcoholPercentage = alcoholPercentage;
        WineType = wineType;
        WineName = wineName;
        Description = description;
        
    }
    public decimal GetPrice() => Price;


   public string GetString(bool itemType=false, bool incart=false)
    {
        if (itemType)
        {
            return $"{WineType}";
        }
        return $"{ID} | {WineType}\n  {WineName}  {Price}\n   {Description}\n";
    }
}