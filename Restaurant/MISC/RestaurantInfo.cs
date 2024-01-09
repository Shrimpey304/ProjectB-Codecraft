namespace Restaurant;

public class RestaurantInfo
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

    
    public static void DisplayRestaurantInfo(User? user = null)
    {
        Console.Clear();
        Header.DisplayHeader();

        Ingelogdmenu ingelogdmenu = new();
        Console.WriteLine($"\u001B[35m" + "\nWelcome to Codecraft Cuisine!\n");
        Console.WriteLine("Here you will find all the restaurant information\n");
        Console.WriteLine("---------- Opening times ----------\n\n");
        Console.WriteLine($"Monday: {OpeningTimes["Monday"]} \nTuesday: {OpeningTimes["Monday"]}\nWednesday: {OpeningTimes["Monday"]}\nThursday: {OpeningTimes["Monday"]}\nFriday: {OpeningTimes["Monday"]}\nSaturday: {OpeningTimes["Monday"]}\nSunday: {OpeningTimes["Monday"]}\n\n");
        Console.WriteLine("\n\n---------- General Information ----------\n");
        Console.WriteLine("Our restaurant is one of the top restaurants in Rotterdam.\nWe offer a variety of courses and meals for young and old alike.\nAnd ofcourse dont forget our wine cellar filled with delicious wines");
        Console.WriteLine("---------- Location ----------\n\n");
        Console.WriteLine("Wijnhaven 107, 3011 WN in Rotterdam\n");
        
        System.Console.WriteLine($"\x1B[4m" +"\n\nPRESS ENTER TO GO BACK" + $"\x1B[0m");
        string outl = Console.ReadLine();

        ingelogdmenu.user = user;

        if (outl is not null && user is not null){
            ingelogdmenu.DisplayIngelogdMenu();
        }else{
            MainMenu.DisplayMainMenu();
        }
    }

    
}