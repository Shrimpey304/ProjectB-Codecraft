namespace Restaurant;

public class RestaurantInfoTest
{
    static Dictionary<string,string> OpeningTimes = new(){
        {"Monday", "14:00 - 21:00"},
        {"Tuesday", "14:00 - 21:00"},
        {"Wednesday", "12:00 - 21:00"},
        {"Thursday", "12:00 - 21:00"},
        {"Friday", "12:00 - 21:00"},
        {"Saturday", "12:00 - 21:00"},
        {"Sunday", "15:00 - 20:00"}
    };

    
      public static void DisplayRestaurantInfo()
    {
        Ingelogdmenu ingelogdmenu = new();
        Console.WriteLine("Welcome to Codecraft Cuisine!\u001B[35m");
        Console.WriteLine("Here you will find all the restaurant information\n\u001B[35m");
        Console.WriteLine("---------- Opening times ----------\u001B[35m \n\n");
        Console.WriteLine($"Monday: {OpeningTimes["Monday"]} \nTuesday: {OpeningTimes["Monday"]}\n Wednesday: {OpeningTimes["Monday"]}\nThursday: {OpeningTimes["Monday"]}\n Friday: {OpeningTimes["Monday"]}\nSaturday: {OpeningTimes["Monday"]}\nSunday: {OpeningTimes["Monday"]}\n\n\u001B[35m");
        Console.WriteLine("\n\n---------- General Information ----------\u001B[35m \n\n");
        System.Console.WriteLine("press any key to exit.");
        string outl = Console.ReadLine();
        if (outl is not null){ingelogdmenu.DisplayIngelogdMenu();}
    }

    
}