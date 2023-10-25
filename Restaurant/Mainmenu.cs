namespace Restaurant;

public class MainMenu
{
    public static void DisplayMainMenu()
    {
        Console.WriteLine("[M] Menu");
        Console.WriteLine("[R] Reservation");
        Console.WriteLine("[I] Log in");
        Console.WriteLine("[Q] Quit");
        Console.WriteLine("register");

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
                    MakeReservation.Display();
                    break;

                case "I":
                    Ingelogdmenu.DisplayIngelogdMenu();
                    break;
                
                case "REGISTER":
                    RegisterProcess.RegisterProcessView();
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
