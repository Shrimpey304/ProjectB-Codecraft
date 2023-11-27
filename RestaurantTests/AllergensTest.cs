using System.Dynamic;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;

public class RemoveAllergensTest
{
    [TestMethod]
    public void RemoveAllergens_AllergenRemoved_ReturnsString()
    {
        // Arrange
        var allergen = new Allergens(); // Note: You might need to instantiate your Allergens class

        // Act
        string result = FoodManager.RemoveAllergens("Gluten");

        // Assert
        Assert.IsTrue(result.Contains("We have removed Gluten from your meal(s)"));
    }
}