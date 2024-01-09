using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;

[TestClass]

public class DishTest
{
    [TestMethod]
    public void GetString_WhenItemTypeIsTrueAndInCartIsTrue_ReturnsCorrectString()
    {
        var dish = new Dish(1, "Test dish", "good test dish", 10.99m, "coffee");
        string result = dish.GetString(itemType: true, incart: true);
        Assert.AreEqual($"{dish.ID} {dish.Price}\n  {dish.Description}\n   Contains: {dish.Allergens}\n\n   Allergens removed:{(dish.RemovedA is not null ? dish.RemovedA : "No allergens removed")}", result);
    }

    //  public Dish(int id, string name, string description, decimal price, string allergens)
    // return $" {DishName}  {Price}\n\n   Description: {Description}\n\n   Contains:{Allergens}\n\n   Allergens removed:{(RemovedA is not null ? RemovedA : "No allergens removed")}";
    //kept the above to make writing easier
}