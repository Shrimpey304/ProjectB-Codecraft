namespace Restaurant;

public class AdminTable
{
    public static User user;
    private static string tablesPath = @".\dataStorage\Tables.json";

    public static TableManager tableManager = new TableManager(user);

    private static List<Table> tables = JsonUtil.ReadFromJson<Table>(tablesPath);

    public static void SeeTablesA()
    {
        FormatJsonJ.FormatTables();
        Console.WriteLine("Press enter to go back to change tables menu");
        Console.ReadLine();
        AdminMenu.DisplayChangeTableMenu(); 
    }

    public static void AddTableA()
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
            AdminMenu.DisplayChangeTableMenu();
        }
        else
        {
            Console.WriteLine("Table with the specified position already exists.");
        }
    }

    public static void RemoveTableA()
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
            AdminMenu.DisplayChangeTableMenu();
        }
        else
        {
            Console.WriteLine("Table not found.");
        }
    }

    private static Table GetTableByPosition()
    {
        Console.WriteLine("Enter the position of the table you want to change:");
        int tablePosition;
        if (!int.TryParse(Console.ReadLine(), out tablePosition))
        {
            Console.WriteLine("Invalid input");
            return null;
        }

        Table tableToChange = tables.FirstOrDefault(t => t.Position == tablePosition);

        if (tableToChange == null)
        {
            Console.WriteLine("table not found.");
        }

        return tableToChange;
    }

    public static void ChangeTablePosition()
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
                return;
            }

            tableToChange.Position = position;

            JsonUtil.UploadToJson(tables, tablesPath);
            Console.WriteLine("Table Position changed successfully.");
            AdminMenu.DisplayChangeTableMenu();
        }
    }

    public static void ChangeTableType()
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
                return;
            }

            tableToChange.Type = type;

            JsonUtil.UploadToJson(tables, tablesPath);
            Console.WriteLine("Type changed successfully.");
            AdminMenu.DisplayChangeTableMenu();
        }
    }

    public static void ChangeTableA()
    {
        FormatJsonJ.FormatTables();

        Console.WriteLine("Enter the position of the table you want to change:");
        int currentposition;
        if (!int.TryParse(Console.ReadLine(), out currentposition))
            {
                Console.WriteLine("Invalid input.");
                return;
            }
        Console.WriteLine("Enter the new position for the table:");
        int position;
        if (!int.TryParse(Console.ReadLine(), out position))
            {
                Console.WriteLine("Invalid input.");
                return;
            }
        Console.WriteLine("Enter the new type for the table:");
        int type;
        if (!int.TryParse(Console.ReadLine(), out type))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

        bool tablechanged = tableManager.ChangeTableDetails(currentposition, position, type);
        if (tablechanged)
        {
            Console.WriteLine("Table Position changed successfully.");
            AdminMenu.DisplayChangeTableMenu();
        }
    }
}