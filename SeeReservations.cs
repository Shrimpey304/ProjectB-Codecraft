namespace Restaurant;

public class SeeReservations
{
    public static void AdminSeeResv()
    {
        ReadingWriting("Reservations.json");
        BackToChangeResvMenu();
    }

    static void ReadingWriting(string fileName)
    {
        Console.WriteLine("Showing all reservations...");
        string contents = ReadAllText(fileName);
        Console.WriteLine(contents);
    }

    static string ReadAllText(string jsonFileName)
    {
        StreamReader reader = new(jsonFileName);
        string contents = File.ReadAllText(jsonFileName);
        reader.Close();
        return contents;
    }

    static void BackToChangeResvMenu()
    {
        ChangeAccMenu.DisplayChangeAccMenu();
    }

}