namespace Restaurant;

public class ChangeFoodMenu
{
    public static void DisplayFoodMenu()
    {
        List<string> options = new(){
            "Change dish information",
            "Delete dish",
            "Add dish",
            "Delete whole menu",
            "See food menu",
            "Quit Application"
        };
        List<Action> actions = new(){
            ChangeAccs.ChangeAccsInfo,
            RemoveAccs.RemoveAccsInfo,
            MakeAdminAccs.AddUser,
            OpenAdminAccs.SeeAdminAcc,
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