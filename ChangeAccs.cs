using System;
using System.IO;

namespace Restaurant
{
    public class ChangeAccs
    {
        public static void ChangeAccsInfo()
        {
            ShowAllAccounts();
            EnterID();
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

        static void EnterID()
        {
            Console.WriteLine("Type the ID of the account that you would like to change");
            string user_id = Console.ReadLine()!;

            string[] lines = File.ReadAllLines("Admin.json");
            bool accountFound = false;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains($"\"ID\": \"{user_id}\""))
                {
                    accountFound = true;
                    lines[i] = UpdateAccountDetails(lines[i]);
                    break;
                }
            }

            if (!accountFound)
            {
                Console.WriteLine("Account not found.");
            }
            else
            {
                File.WriteAllText("Admin.json", string.Join(Environment.NewLine, lines));
                Console.WriteLine("Changes saved successfully.");
            }
        }

        static string UpdateAccountDetails(string accountInfo)
        {
            Console.WriteLine("What would you like to change?");
            Console.WriteLine("[E] Email");
            Console.WriteLine("[P] Password");
            Console.WriteLine("[H] PhoneNumber");

            string choice = Console.ReadLine()!.ToUpper();

            switch (choice)
            {
                case "E":
                    Console.WriteLine("Enter new email:");
                    accountInfo = accountInfo.Replace("Email", $"Email: \"{Console.ReadLine()}\"");
                    break;
                case "P":
                    Console.WriteLine("Enter new password:");
                    accountInfo = accountInfo.Replace("Password", $"Password: \"{Console.ReadLine()}\"");
                    break;
                case "H":
                    Console.WriteLine("Enter new phone number:");
                    accountInfo = accountInfo.Replace("PhoneNumber", $"PhoneNumber: \"{Console.ReadLine()}\"");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            return accountInfo;
        }
    }
}