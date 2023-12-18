using System;
using System.Text;
using System.Dynamic;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;

[TestClass]
public class TestRegisterLogic{


    [DataTestMethod]
    [DataRow("Password123", "Password123", true)]
    [DataRow("Password123", "password123", false)]
    [DataRow("Password123", "Password", false)]
    public void TestPassworValidity_ReturnsTrue(string password, string retypePassword, bool expectedResult){
        
        bool result = Registration.CheckPasswordSimilar(password, retypePassword);
        Assert.AreEqual(expectedResult, result);

    }


    [DataTestMethod]
    [DataRow("Abcdefg1", true)]
    [DataRow("ABCDEFG1", false)]
    [DataRow("abcdefg1", false)]
    [DataRow("12345678", false)]
    public void CheckPasswordFormat_ValidPasswords_ReturnsExpected(string password, bool expectedResult)
    {
        bool result = Registration.CheckPasswordFormat(password);
        Assert.AreEqual(expectedResult, result);
    }

    [DataTestMethod]
    [DataRow("test@test.com", true)]
    [DataRow("invalidemail.com", false)]
    [DataRow("another_test@test.com", true)]
    public void CheckEmailRegEx_ValidEmails_ReturnsExpected(string email, bool expectedResult)
    {
        bool result = Registration.CheckEmailRegEx(email);
        Assert.AreEqual(expectedResult, result);
    }

    [DataTestMethod]
    public void CheckEmailTaken_ExistingEmail_ReturnsTrue()
    {
        // Arrange
        string existingEmail = "existing_email@test.com";

        // Act
        bool isTaken = Registration.CheckEmailTaken(existingEmail);

        // Assert
        Assert.IsTrue(isTaken);
    }

    [DataTestMethod]
    public void CheckEmailTaken_NonExistingEmail_ReturnsFalse()
    {z
        // Arrange
        string nonExistingEmail = "non_existing_email@test.com";

        // Act
        bool isTaken = Registration.CheckEmailTaken(nonExistingEmail);

        // Assert
        Assert.IsFalse(isTaken);
    }

    [DataTestMethod]
    public void CreateAccount_ValidInputs_ReturnsUserObject()
    {
        // Arrange
        string email = "newuser@test.com";
        string password = "Password123";
        string phoneNumber = "1234567890";

        // Act
        Registration registration = new Registration();
        User createdUser = registration.CreateAccount(email, password, phoneNumber);

        // Assert
        Assert.IsNotNull(createdUser);
        Assert.AreEqual(email, createdUser.Email);
        Assert.AreEqual(password, createdUser.Password);
        Assert.AreEqual(phoneNumber, createdUser.PhoneNumber);
    }

}