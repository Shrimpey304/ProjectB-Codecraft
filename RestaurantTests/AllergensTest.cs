using System.Dynamic;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
[TestClass]
public class RemoveAllergensTest
{
    [TestMethod]
    public void RemoveAllergens_AllergenRemoved_ReturnsString()
    {
        // Arrange
        //Allergen allergen = new Allergen(); // Note: You might need to instantiate your Allergens class

        // Act
        string result = FoodManager.RemoveAllergens("Gluten");

        // Assert
        Assert.IsTrue(result.Contains("We have removed Gluten from your meal(s)"));
    }
}