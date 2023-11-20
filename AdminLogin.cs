using System;
using System.IO;

namespace Restaurant
{
    public class AdminLogin
    {
        public static void CheckAdminAcc()
        {
            string jsonFileName = "AdminAccs.json";
            string jsonContents = ReadAllText(jsonFileName);

            Console.Write("Enter your email: ");
            string userEmail = Console.ReadLine()!;

            if (jsonContents.Contains($"\"Email\": \"{userEmail}\"", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Logged in as admin");
                AdminMenu.DisplayAdminMenu();
            }
            else
            {
                Console.WriteLine("Email not found. Access denied.");
            }
        }

        static string ReadAllText(string jsonFileName)
        {
            return File.ReadAllText(jsonFileName);
        }
    }
}
