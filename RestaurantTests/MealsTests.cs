using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;

[TestClass]
public class MealsTests
{
    [TestMethod]
    public void GetString_WhenItemTypeIsTrueAndInCartIsTrue_ReturnsCorrectString()
    {
        // Arrange
         var meal = new Meals(1, 1, "Breakfast", "Example Meal", 10.99m, "Test meal");


        // Act
        string result = meal.GetString(itemType: true, incart: true);

        // Assert
        Assert.AreEqual($"{meal.ID} | {meal.CourseType}-course, {meal.MealType} meal €{meal.Price}\n  {meal.CourseDescription}\n   Allergens removed:{(meal.RemovedA is not null ? meal.RemovedA : "No allergens romved")}", result); 
    }
    // $"{ID} | {CourseType}-course {MealType} meal €{Price}\n  {CourseDescription}\n   Allergens removed:{(RemovedA is not null ? RemovedA : "No allergens romved")}"
    //kept the above to simplify writing
    
}