namespace Restaurant;

public class Ingelogdmenu
{
    
    public static void DisplayIngelogdMenu()
    {

        List<string> LogedInMenuOptions = new(){
            "Menu (food)",
            "Restaurant informatie",
            "Make reservation",
            "Order history",
            "Personal information",
        };
        List<Action> actions = new(){
            MenuCard.FromMain,
            RestaurantInfoTest.DisplayRestaurantInfo,
            MakeReservation.Display,
            OrderHistoryTest.DisplayOrderHistory,
            PersonalInfoTest.DisplayPersonalInfo,
        };
        DisplayUtil.Display(LogedInMenuOptions);

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
                    MakeReservation.Display();
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
