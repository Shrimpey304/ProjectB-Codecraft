using System;

namespace Restaurant
{
    public class RemoveAdminTable
    {
        public static void RemoveTableA()
        {
            TableManager tableManager = new TableManager();

            Console.WriteLine("Enter the ID of the table you want to remove:");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input");
            }

            bool success = tableManager.RemoveTable(id);

            if (success)
            {
                Console.WriteLine("Table removed successfully.");
            }
            else
            {
                Console.WriteLine("ID not found");
            }
        }
    }
}



