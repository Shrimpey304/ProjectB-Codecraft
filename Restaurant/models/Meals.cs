namespace Restaurant;

public class Meals : IFoodItems
{
    public int ID {get;set;}
    public int CourseType{get;set;}
    public string MealType{get;set;}
    public string MealName { get; set; }
    //public List<Dish> Dishes {get;set;}
    public decimal Price { get; set; }
    public string CourseDescription { get; set; }

    public Meals(int id, int coursetype, string mealtype, string mealname, decimal price, string coursedescription)
    {
        ID = id;
        CourseType = coursetype;
        MealType = mealtype;
        MealName = mealname;
        //Dishes = dishes;
        Price = price;
        CourseDescription = coursedescription;
    }

    public decimal GetPrice() => Price;
    public string GetString(bool itemType=false)
    {
        if (itemType)
        {
            return $"{MealType}";
        }
        return $"{ID} | {CourseType}-course {MealType} meal €{Price}\n  {CourseDescription}";
    }
}
