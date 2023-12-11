namespace Restaurant;
public class SeeTables
{
    public static void DisplaySeeTables()
    
    {
        ReadingWriting("Tables.json");
        BackToChangeTableMenu();
    }

    static void ReadingWriting(string fileName)
    {
        Console.WriteLine("Showing all existing tables...");
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

    static void BackToChangeTableMenu()
    {
        ChangeTableMenu.DisplayChangeTableMenu();
    }

}