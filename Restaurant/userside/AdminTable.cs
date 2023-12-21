// namespace Restaurant;

// public class AdminTable
// {
//     private static string tablePath = @".\dataStorage\Tables.json";
//     public static void SeeTablesA()
//     {
//         Console.WriteLine("Showing all tables...");
//         string json = File.ReadAllText(tablePath);
//         Console.WriteLine(json);
//     }

//     public static void AddTableA()
//     {
//         SeeTablesA();
//         TableManager tableManager = new TableManager();

//         Console.WriteLine("Enter the position of the table:");
//         if (!int.TryParse(Console.ReadLine(), out int position))
//         {
//             Console.WriteLine("Invalid input for position.");
//             return;
//         }

//         Console.WriteLine("Enter the type of the table:");
//         if (!int.TryParse(Console.ReadLine(), out int type))
//         {
//             Console.WriteLine("Invalid input for type.");
//             return;
//         }

//         bool tableAdded = tableManager.AddTable(position, type);
//         if (tableAdded)
//         {
//             Console.WriteLine("Table added successfully.");
//             AdminMenu.DisplayChangeTableMenu();
//         }
//         else
//         {
//             Console.WriteLine("Table with the specified position already exists.");
//         }
//     }

//     public static void RemoveTableA()
//     {
//         SeeTablesA();
//         TableManager tableManager = new TableManager();

//         Console.WriteLine("Enter the position of the table to remove:");
//         if (!int.TryParse(Console.ReadLine(), out int position))
//         {
//             Console.WriteLine("Invalid input for position.");
//             return;
//         }

//         bool tableRemoved = tableManager.RemoveTable(position);
//         if (tableRemoved)
//         {
//             Console.WriteLine("Table removed successfully.");
//             AdminMenu.DisplayChangeTableMenu();
//         }
//         else
//         {
//             Console.WriteLine("Table not found.");
//         }
//     }

//     public static void ChangeTableA()
//     {
        
//         SeeTablesA();

//         Console.WriteLine("Enter the position of the table you want to change:");
//         if (!int.TryParse(Console.ReadLine(), out int currentPosition))
//         {
//             Console.WriteLine("Invalid input .");
//             return;
//         }

//         TableManager tableManager = new TableManager();

//         Console.WriteLine("Enter new position:");
//         if (!int.TryParse(Console.ReadLine(), out int newPosition))
//         {
//             Console.WriteLine("Invalid input");
//             return;
//         }

//         Console.WriteLine("Enter the new type:");
//         if (!int.TryParse(Console.ReadLine(), out int newType))
//         {
//             Console.WriteLine("Invalid input");
//             return;
//         }

//         bool tableChanged = tableManager.ChangeTableDetails(currentPosition, newPosition, newType);
//         if (tableChanged)
//         {
//             Console.WriteLine("Table details changed successfully.");
//         }
//         else
//         {
//             Console.WriteLine("Table with the specified position was not found.");
//         }
//     }
    
// }