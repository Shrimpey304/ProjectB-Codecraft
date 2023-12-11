namespace Restaurant;

public class ChangeTableMenu
{
    public static void DisplayChangeTableMenu()
    {
        List<string> options = new(){
            "See existing tables"
            "Add table",
            "Remove table",
            "Quit Application"
        };
        List<Action> actions = new(){
            SeeTables.DisplaySeeTables
            AddAdminTable.MakeTableA,
            RemoveAdminTable.RemoveTableA,
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