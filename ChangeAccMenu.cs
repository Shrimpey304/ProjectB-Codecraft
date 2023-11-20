namespace Restaurant;

public class ChangeAccMenu
{
    public static void DisplayChangeAccMenu()
    {
        Console.WriteLine("Welcome to the change accounts menu, ");
        Console.WriteLine("[C] Change accounts information");
        Console.WriteLine("[D] Delete account");
        Console.WriteLine("[M] Make account");
        Console.WriteLine("[S] See all accounts");
        Console.WriteLine("[B] Go back");
        Console.WriteLine("[E] Exit");

        while (true)
        {
            string option = Console.ReadLine()!.ToUpper();

            switch (option)
            {
                case "C":
                    ChangeAccs.ChangeAccsInfo();
                    break;

                case "D":
                    RemoveAccs.RemoveAccsInfo();
                    break;

                case "M":
                    MakeAdminAccs.AddUser();
                    break;

                case "S":
                    OpenAdminAccs.SeeAdminAcc();
                    break;

                case "B":
                    AdminMenu.DisplayAdminMenu();
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