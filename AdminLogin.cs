using System;
using System.IO;

namespace Restaurant
{
    public class AdminLogin
    {
        public static void CheckAdminAcc()
        {
            string jsonFileName = "AdminAccs.json";
            string jsonContents = File.ReadAllText(jsonFileName);

            bool isLoggedIn = false;

            while (!isLoggedIn)
            {
                Console.Write("Enter your email: ");
                string userEmail = Console.ReadLine();

                if (jsonContents.Contains($"\"Email\": \"{userEmail}\"", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Logged in as admin");
                    AdminMenu.DisplayAdminMenu();
                    isLoggedIn = true;
                }
                else
                {
                    Console.WriteLine("Email not found. Please try again.");
                }
            }
        }
    }
}

