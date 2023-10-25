namespace Restaurant;

public class MainMenu
{
    public static void MainMenuDisplay()
    {
        Console.WriteLine("[M] Menu");
        Console.WriteLine("[R] Restaurant information");
        Console.WriteLine("[I] Log in");
        Console.WriteLine("[Q] Quit");
        Console.WriteLine("Register");

        while (true)
        {
            string option = Console.ReadLine()!.ToUpper();

            switch (option)
            {
                case "M":
                    MenuMain MM = new MenuMain();
                    MM.MenuMainFunc();
                    break;

                case "R":
                    RestaurantInfoTest.DisplayRestaurantInfo();
                    break;

                case "I":
                    Ingelogdmenu.DisplayIngelogdMenu();
                    break;

                case "REGISTER":
                    LoginRegistrationMenu.Menu();
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
