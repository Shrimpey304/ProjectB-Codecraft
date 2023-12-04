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
            string json = File.ReadAllText("Admin.json");
            Console.WriteLine(json);
        }

        public static void RemoveAcc()
        {
            Console.WriteLine("Type the ID of the account that you would like to remove");
            string userId = Console.ReadLine()!;

            string filePath = "Admin.json";
            string json = File.ReadAllText(filePath);

            int startIndex = json.IndexOf($"\"ID\": \"{userId}\"");

            if (startIndex == -1)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            int endIndex = json.IndexOf('}', startIndex);

            if (endIndex == -1)
            {
                Console.WriteLine("Invalid JSON structure.");
                return;
            }

            int startBlock = json.LastIndexOf('{', startIndex);
            int endBlock = endIndex + 1;

            string removedJson = json.Remove(startBlock, endBlock - startBlock);

            File.WriteAllText(filePath, removedJson);
            Console.WriteLine("Account removed successfully.");
        }

        
    }
}




