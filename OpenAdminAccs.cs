namespace Restaurant;
public class OpenAdminAccs
{
    public static void SeeAdminAcc()
    
    {
        ReadingWriting("AdminAccs.json");
        BackToMenu();
    }

    static void ReadingWriting(string fileName)
    {
        Console.WriteLine("Showing all accounts...");
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

    static void BackToMenu()
    {
        ChangeAccMenu.DisplayChangeAccMenu();
    }

}
