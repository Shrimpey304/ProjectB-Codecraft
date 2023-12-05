using System;
using System.IO;

namespace Restaurant
{
    public class RemoveAccs
    {
        public static void RemoveAccsInfo()
        {
            ShowAllAccounts();
            RemoveAcc();
        }

        static void ShowAllAccounts()
        {
            Console.WriteLine("Showing all accounts...");
            string[] lines = File.ReadAllLines("Admin.json");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }


        public static void RemoveAcc()
        {
            Console.WriteLine("Type the ID of the account that you would like to remove");
            string user_id = Console.ReadLine()!;

            string filePath = "Admin.json";
            string json = File.ReadAllText(filePath);

            string searchTerm = $"\"ID\": \"{user_id}\"";
            int index = json.IndexOf(searchTerm);

            if (index == -1)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            int start = json.LastIndexOf('{', index);
            int end = json.IndexOf('}', index) + 1;

            if (start == -1 || end == -1)
            {
                Console.WriteLine("Invalid JSON structure.");
                return;
            }

            json = json.Remove(start, end - start);

            File.WriteAllText(filePath, json);
            Console.WriteLine("Account removed successfully.");
        }
    }
}




