using System.Dynamic;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;

[TestClass]
public class TestReservation
{
    private const string tablesFileName = @"C:\Users\zamir\Documents\GitHub\ProjectB-Codecraft\RestaurantTests\test_datastorage\Test_tables.json";
    private const string reseravtionFileName = @"C:\Users\zamir\Documents\GitHub\ProjectB-Codecraft\RestaurantTests\test_datastorage\Test_reservations.json";
    private static string[] dateFormate = {"yyyy-MM-dd"};
    private static DateOnly testDate = DateOnly.ParseExact("2029-11-23", dateFormate);

    [TestMethod]
    [DataRow("2023-11-21", 2, true)]
    public void Making_Reservation_With_Valid_Data(string datestring, int partysize, bool expected)
    {
        //Arange
        TableManager manager = CreateDefaultTableManager();
        DateOnly? date = TableManager.ValidateDate(datestring);
        
        //Act
        bool actual = manager.AddReservation(date, partysize, reseravtionFileName);

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("3", 3)]
    [DataRow("1", null)]
    [DataRow("a", null)]
    public void Test_PartySize_Validation(string partyinp, int? expected)
    {
        //Act
        int? actual = TableManager.ValidatePartySize(partyinp);

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("2029-11-23", "2029-11-23")]
    [DataRow("2022-01-01", null)]
    [DataRow("01-12-2023", null)]
    [DataRow("2023-13-09", null)]
    [DataRow("2023-11-40", null)]
    [DataRow("2023/11/02", null)]
    public void Test_Date_Validation(string datestring, string? expectedout)
    {
        //Arange
        DateOnly? expected = expectedout is not null ? DateOnly.ParseExact(expectedout, dateFormate) : null;

        //Act
        DateOnly? actual = TableManager.ValidateDate(datestring);
        
        //Assert
        Assert.AreEqual(expected, actual);
    }
    private TableManager CreateDefaultTableManager()
    {
        return new TableManager(tablesFileName);
    }
}