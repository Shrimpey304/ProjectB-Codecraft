namespace Restaurant;

public class ChangeResvMenu
{
    public static void DisplayChangeResvMenu()
    {
        List<string> options = new(){
            "Change reservations",
            "Remove reservation",
            "Add reservation",
            "See all reservations",
            "Quit Application"
        };
        List<Action> actions = new(){
            ChangeReservationA.AdminChangeResv,
            RemoveReservationA.AdminRemResv,
            AddReservationA.AdminAddResv,
            SeeReservations.AdminSeeResv,
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