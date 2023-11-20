namespace Restaurant;

public class AdminMenu
{
    public static void DisplayAdminMenu()
    {
        Console.WriteLine("Welcome to the admin menu, ");
        Console.WriteLine("[F] Change (food) menu");
        Console.WriteLine("[L] Change restaurant layout");
        Console.WriteLine("[R] Change Reservations");
        Console.WriteLine("[A] Change accounts");
        Console.WriteLine("[E] Exit");

        while (true)
        {
            string option = Console.ReadLine()!.ToUpper();

            switch (option)
            {
                case "F":
                    Console.WriteLine("...");
                    break;

                case "L":
                    Console.WriteLine("...");
                    break;

                case "R":
                    Console.WriteLine("...");
                    break;

                case "A":
                    ChangeAccMenu.DisplayChangeAccMenu();
                    break;

                case "E":
                    Console.WriteLine("Exit");
                    return;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}

