namespace Restaurant;

public class AdminTable
{
    public static User user;
    private static string tablesPath = @".\dataStorage\Tables.json";

    public static TableManager tableManager = new TableManager(user);

    private static List<Table> tables = JsonUtil.ReadFromJson<Table>(tablesPath);

    public static void SeeTablesA(User user)
    {
        FormatJsonJ.FormatTables();
        Console.WriteLine("Press enter to go back to change tables menu");
        Console.ReadLine();
        AdminMenu.DisplayChangeTableMenu(user); 
    }

    public static void AddTableA(User user)
    {
        FormatJsonJ.FormatTables();

        Console.WriteLine("Enter the position of the table:");
        if (!int.TryParse(Console.ReadLine(), out int position))
        {
            Console.WriteLine("Invalid input for position.");
            return;
        }

        Console.WriteLine("Enter the type of the table:");
        if (!int.TryParse(Console.ReadLine(), out int type))
        {
            Console.WriteLine("Invalid input for type.");
            return;
        }

        bool tableAdded = tableManager.AddTable(position, type);
        if (tableAdded)
        {
            tables = tableManager.Tables;
            Console.WriteLine("Table added successfully.");
            AdminMenu.DisplayChangeTableMenu(user);
        }
        else
        {
            Console.WriteLine("Table with the specified position already exists.");
            Console.WriteLine("Heading back to admin menu");
            Thread.Sleep(2000);
            AdminMenu.DisplayAdminMenu(user);
        }
    }

    public static void RemoveTableA(User user)
    {
        FormatJsonJ.FormatTables();

        Console.WriteLine("Enter the position of the table to remove:");
        if (!int.TryParse(Console.ReadLine(), out int position))
        {
            Console.WriteLine("Invalid input for position.");
            return;
        }

        bool tableRemoved = tableManager.RemoveTable(position);
        if (tableRemoved)
        {
            Console.WriteLine("Table removed successfully.");
            AdminMenu.DisplayChangeTableMenu(user);
        }
        else
        {
            Console.WriteLine("Table not found.");
            Console.WriteLine("Heading back to admin menu");
            Thread.Sleep(2000);
            AdminMenu.DisplayAdminMenu(user);
        }
    }

    private static Table GetTableByPosition()
    {
        Console.WriteLine("Enter the position of the table you want to change:");
        int tablePosition;
        if (!int.TryParse(Console.ReadLine(), out tablePosition))
        {
            Console.WriteLine("Invalid input");
            Console.WriteLine("Heading back to admin menu");
            Thread.Sleep(2000);
            AdminMenu.DisplayAdminMenu(user);
            
            return null;
        }

        Table tableToChange = tables.FirstOrDefault(t => t.Position == tablePosition);

        if (tableToChange == null)
        {
            Console.WriteLine("table not found.");
            Console.WriteLine("Heading back to admin menu");
            Thread.Sleep(2000);
            AdminMenu.DisplayAdminMenu(user);
        }

        return tableToChange;
    }

    public static void ChangeTablePosition(User user)
    {
        FormatJsonJ.FormatTables();
        Table tableToChange = GetTableByPosition();

        if (tableToChange != null)
        {
            Console.WriteLine("Enter the new position for the table:");
            int position;
            if (!int.TryParse(Console.ReadLine(), out position))
            {
                Console.WriteLine("Invalid input.");
                Console.WriteLine("Heading back to admin menu");
                Thread.Sleep(2000);
                AdminMenu.DisplayAdminMenu(user);
                return;
            }

            tableToChange.Position = position;

            JsonUtil.UploadToJson(tables, tablesPath);
            Console.WriteLine("Table Position changed successfully.");
            AdminMenu.DisplayChangeTableMenu(user);
        }
    }

    public static void ChangeTableType(User user)
    {
        FormatJsonJ.FormatTables();
        Table tableToChange = GetTableByPosition();

        if (tableToChange != null)
        {
            Console.WriteLine("Enter the new type for the table:");
            int type;
            if (!int.TryParse(Console.ReadLine(), out type))
            {
                Console.WriteLine("Invalid input.");
                Console.WriteLine("Heading back to admin menu");
                Thread.Sleep(2000);
                AdminMenu.DisplayAdminMenu(user);
                return;
            }

            tableToChange.Type = type;

            JsonUtil.UploadToJson(tables, tablesPath);
            Console.WriteLine("Type changed successfully.");
            AdminMenu.DisplayChangeTableMenu(user);
        }
    }

    public static void ChangeTableA(User user)
    {
        FormatJsonJ.FormatTables();

        Console.WriteLine("Enter the position of the table you want to change:");
        int currentposition;
        if (!int.TryParse(Console.ReadLine(), out currentposition))
            {
                Console.WriteLine("Invalid input.");
                Console.WriteLine("Heading back to admin menu");
                Thread.Sleep(2000);
                AdminMenu.DisplayAdminMenu(user);
                return;
            }
        Console.WriteLine("Enter the new position for the table:");
        int position;
        if (!int.TryParse(Console.ReadLine(), out position))
            {
                Console.WriteLine("Invalid input.");
                Console.WriteLine("Heading back to admin menu");
                Thread.Sleep(2000);
                AdminMenu.DisplayAdminMenu(user);
                return;
            }
        Console.WriteLine("Enter the new type for the table:");
        int type;
        if (!int.TryParse(Console.ReadLine(), out type))
            {
                Console.WriteLine("Invalid input.");
                Console.WriteLine("Heading back to admin menu");
                Thread.Sleep(2000);
                AdminMenu.DisplayAdminMenu(user);
                return;
            }

        bool tablechanged = tableManager.ChangeTableDetails(currentposition, position, type);
        if (tablechanged)
        {
            Console.WriteLine("Table Position changed successfully.");
            AdminMenu.DisplayChangeTableMenu(user);
        }
    }
}