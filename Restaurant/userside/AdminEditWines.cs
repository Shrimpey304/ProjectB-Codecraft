namespace Restaurant;

public class AdminEditWines
{
    private static string winesPath = @".\dataStorage\Wines.json";
    private static List<Wine> wines = JsonUtil.ReadFromJson<Wine>(winesPath);

    private static Wine GetWineById(User user)
    {
        Console.WriteLine("Enter the ID of the Wine you want to change:");
        int wineID;
        if (!int.TryParse(Console.ReadLine(), out wineID))
        {
            Console.WriteLine("Invalid input");
            Thread.Sleep(2000);
            return null;
        }

        Wine wineToChange = wines.FirstOrDefault(w => w.ID == wineID);

        if (wineToChange == null)
        {
            Console.WriteLine("Wine not found.");
            Console.WriteLine("Heading back to admin menu");
            Thread.Sleep(2000);
            AdminMenu.DisplayAdminMenu(user);
        }

        return wineToChange;
    }

    public static void ChangeWineType(User user)
    {
        FormatJsonJ.FormatWines();
        Wine wineToChange = GetWineById(user);

        if (wineToChange != null)
        {
            Console.WriteLine("Enter the new wine type:");
            string newWineType = Console.ReadLine();

             wineToChange.WineType = newWineType;

            JsonUtil.UploadToJson(wines, winesPath);
            Console.WriteLine("Wine type changed successfully.");
            Thread.Sleep(2000);
            AdminMenu.DisplayChangeFoodMenu(user);
        }
    }

    public static void ChangeWineName(User user)
    {
        FormatJsonJ.FormatWines();
        Wine wineToChange = GetWineById(user);

        if (wineToChange != null)
        {
            Console.WriteLine("Enter new wine name:");
            string newWineName = Console.ReadLine();

             wineToChange.WineName = newWineName;

            JsonUtil.UploadToJson(wines, winesPath);
            Console.WriteLine("Wine name changed successfully.");
            Thread.Sleep(2000);
            AdminMenu.DisplayChangeFoodMenu(user);
        }
    }

    public static void ChangeWineDescription(User user)
    {
        FormatJsonJ.FormatWines();
        Wine wineToChange = GetWineById(user);

        if (wineToChange != null)
        {
            Console.WriteLine("Enter new description:");
            string newDescription = Console.ReadLine();

             wineToChange.Description = newDescription;

            JsonUtil.UploadToJson(wines, winesPath);
            Console.WriteLine("Description changed successfully.");
            Thread.Sleep(2000);
            AdminMenu.DisplayChangeFoodMenu(user);
        }    
    }

    public static void ChangeWinePrice(User user)
    {
        FormatJsonJ.FormatWines();
        Wine wineToChange = GetWineById(user);

        if (wineToChange != null)
        {
            Console.WriteLine("Enter the new price for wine:");
            decimal newPrice;
            if (!decimal.TryParse(Console.ReadLine(), out newPrice))
            {
                Console.WriteLine("Invalid input.");
                Console.WriteLine("Heading back to admin menu");
                Thread.Sleep(2000);
                AdminMenu.DisplayAdminMenu(user);
                return;
            }

             wineToChange.Price = newPrice;

            JsonUtil.UploadToJson(wines, winesPath);
            Console.WriteLine("Price changed successfully.");
            Thread.Sleep(2000);
            AdminMenu.DisplayChangeFoodMenu(user);
        }
    }

    public static void ChangeWineAlcoholP(User user)
    {
        FormatJsonJ.FormatWines();
        Wine wineToChange = GetWineById(user);

        if (wineToChange != null)
        {
            Console.WriteLine("Enter the new alcohol percentage:");
            double newAlcoholPercentage = Convert.ToDouble(Console.ReadLine());

            wineToChange.AlcoholPercentage = newAlcoholPercentage;
            
            JsonUtil.UploadToJson(wines, winesPath);
            Console.WriteLine("AlcoholPercentage changed successfully.");
            Thread.Sleep(2000);
            AdminMenu.DisplayChangeFoodMenu(user);
        }
    }
}