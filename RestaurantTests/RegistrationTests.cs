using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Restaurant;

[TestClass]

public class RegistrationTest
{
    [TestMethod]
    public void CheckPhoneNumberFormat_InvalidNumber_ReturnsFalse()
    {
        string invalidPhoneNumber = "1234567";
        bool expectedResult = false;

        using (StringWriter stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);

            bool result = Registration.CheckPhoneNumberFormat(invalidPhoneNumber);

            Assert.AreEqual(expectedResult, result);
        }
    }
    [TestMethod]
    public void CheckPhoneNumberFormat_ValidNUmber_ReturnsTrue()
    {
        string validPhoneNumber = "12345678";
        bool expectedResult = true;

        using (StringWriter stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);

            bool result = Registration.CheckPhoneNumberFormat(validPhoneNumber);

            Assert.AreEqual(expectedResult, result);
        }
    }

    [TestMethod]
    public void CheckPasswordFormat_PasswordIsInvalid_ReturnsFalse()
    {
        string invalidPassword = "this is an invalid password";
        bool expectedResult = false;

        using (StringWriter stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);
            bool result = Registration.CheckPasswordFormat(invalidPassword);

            Assert.AreEqual(expectedResult, result);
        }
    }
    [TestMethod]
    public void CheckPasswordFormat_PasswordIsValid_ReturnsTrue()
    {
        string validPassword = "ValidPassword123";
        bool expectedResult = true;

        using (StringWriter stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);
            bool result = Registration.CheckPasswordFormat(validPassword);
            
            Assert.AreEqual(expectedResult, result);
        }
    }
}