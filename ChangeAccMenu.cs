namespace Restaurant;

public class AdminMenu
{
    public static void DisplayAdminMenu()
    {
        List<string> options = new(){
            "Change accounts information",
            "Delete account",
            "Make account",
            "See all accounts",
            "Quit Application"
        };
        List<Action> actions = new(){
            ChangeAccs.ChangeAccsInfo,
            RemoveAccs.RemoveAccsInfo,
            MakeAdminAccs.AddUser,
            OpenAdminAccs.SeeAdminAcc,
            Quit
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    private static void Quit()
    {
        Console.WriteLine("Quitting application...");
        return;
    }
}