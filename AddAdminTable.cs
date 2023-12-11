using System;

namespace Restaurant
{
    public class AddAdminTable
    {
        public static void MakeTableA()
        {
            Console.WriteLine("Enter ID");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input");
            }

            Console.WriteLine("Enter type");
            int type;
            while (!int.TryParse(Console.ReadLine(), out type))
            {
                Console.WriteLine("Invalid input");
            }

            ///!
            TableManager tableManager = new TableManager();
            bool success = tableManager.AddTable(id, type);

            if (success)
            {
                Console.WriteLine("Table added successfully.");
            }
            else
            {
                Console.WriteLine("Table ID already exists.");
            }
        }
    }
}


