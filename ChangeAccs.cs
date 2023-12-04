using System;
using System.IO;

namespace Restaurant
{
    public class ChangeAccs
    {
        public static void ChangeAccsInfo()
        {
            ShowAllAccounts();
            UpdateAcc();
        }

        static void ShowAllAccounts()
        {
            Console.WriteLine("Showing all accounts...");
            string json = File.ReadAllText("Admin.json");
            Console.WriteLine(json);
        }

        public static void UpdateAcc()
        {
            Console.WriteLine("Type the ID of the account that you would like to update");
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

            string accountInfo = json.Substring(startBlock, endBlock - startBlock);
            string updatedAccountInfo = UpdateAccountDetails(accountInfo);

            if (!string.IsNullOrEmpty(updatedAccountInfo))
            {
                json = json.Remove(startBlock, endBlock - startBlock).Insert(startBlock, updatedAccountInfo);

                File.WriteAllText(filePath, json);
                Console.WriteLine("Changes saved successfully.");
            }
            else
            {
                Console.WriteLine("Update failed.");
            }
        }

        static string UpdateAccountDetails(string accountInfo)
        {
            Console.WriteLine("What would you like to change?");
            Console.WriteLine("[E] Email");
            Console.WriteLine("[P] Password");
            Console.WriteLine("[H] PhoneNumber");

            string choice = Console.ReadLine()?.ToUpper()!;

            switch (choice)
            {
                case "E":
                    Console.WriteLine("Enter new email:");
                    accountInfo = accountInfo.Replace("Email", $"Email\": \"{Console.ReadLine()}\"");
                    break;
                case "P":
                    Console.WriteLine("Enter new password:");
                    accountInfo = accountInfo.Replace("Password", $"Password\": \"{Console.ReadLine()}\"");
                    break;
                case "H":
                    Console.WriteLine("Enter new phone number:");
                    accountInfo = accountInfo.Replace("PhoneNumber", $"PhoneNumber\": \"{Console.ReadLine()}\"");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            return accountInfo;
        }
    }
}