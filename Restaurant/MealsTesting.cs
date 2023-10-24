using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Meals.TestClass;


[TestClass]
public class MealsTesting
{
    [TestMethod]
    public void CalculateTotalPrice()
    {
        Meals meal1 = new Meals();
        meal1.Price = 10;
        Meals meal2 = new Meals();
        meal2.Price = 15;

        Meals calculator = new Meals();
        decimal result = calculator.CalculateTotalPrice(new List<Meals> { meal1, meal2 });
        decimal expectedTotal = 10 + 15;

        Assert.AreEqual(result, expectedTotal);

    }

    [TestMethod]
    public void ShowReceipt()
    {
        Meals meal1 = new Meals();
        meal1.Price = 10;
        meal1.Name = "3-course meal.";
        Meals meal2 = new Meals();
        meal2.Price = 20;
        meal2.Name = "4-course meal.";

        Meals receipt = new Meals();
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            receipt.ShowReceipt(meal1);
            receipt.ShowReceipt(meal2);

            // Assert
            string expectedOutput = "Here's your receipt:\r\n3-course meal. - 10\r\nTotal price: 10\r\n" +
                "Here's your receipt:\r\n4-course meal. - 20\r\nTotal price: 20\r\n";

            Assert.AreEqual(expectedOutput, sw.ToString());
        }
    }
