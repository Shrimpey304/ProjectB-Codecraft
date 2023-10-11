using System;

public class Ingelogdmenu
{
    public static void DisplayIngelogdMenu()
    {
        Console.WriteLine("[M] Menu (food)");
        Console.WriteLine("[RI] Restaurant informatie");
        Console.WriteLine("[R] Make reservation");
        Console.WriteLine("[H] Order history");
        Console.WriteLine("[P] Personal information");
        Console.WriteLine("[Q] Quit");

        while (true)
        {
            string option = Console.ReadLine()!.ToUpper();

            switch (option)
            {
                case "M":
                    MenuTest.DisplayMenu();
                    break;

                case "RI":
                    RestaurantInfoTest.DisplayRestaurantInfo();
                    break;

                case "R":
                    ReservationTest.DisplayReservation();
                    break;

                case "H":
                    OrderHistoryTest.DisplayOrderHistory();
                    break;

                case "P":
                    Console.WriteLine("Personal information...");
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
