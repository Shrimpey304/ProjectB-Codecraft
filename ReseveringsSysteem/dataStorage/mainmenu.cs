using System;

public class MainMenu
{
    public static void DisplayMainMenu()
    {
        Console.WriteLine("[M] Menu");
        Console.WriteLine("[R] Restaurant information");
        Console.WriteLine("[I] Log in");
        Console.WriteLine("[Q] Quit");

        while (true)
        {
            string option = Console.ReadLine()!.ToUpper();

            switch (option)
            {
                case "M":
                    MenuTest.DisplayMenu();
                    break;

                case "R":
                    RestaurantInfoTest.DisplayRestaurantInfo();
                    break;

                case "I":
                    Ingelogdmenu.DisplayIngelogdMenu();
                    break;

                case "Q":
                    Console.WriteLine("Quitting application.");
                    return;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}