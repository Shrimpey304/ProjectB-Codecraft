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
            string json = File.ReadAllText("ez.json");
            Console.WriteLine(json);
        }

        private static string accountPath = "ez.json";
        public static void RemoveAcc()
         {
            Console.WriteLine("Enter the email of the account you want to remove:");
            string emailToRemove = Console.ReadLine();

            List<User> accounts = JsonUtil.ReadFromJson<User>(accountPath);
            User userToRemove = accounts.FirstOrDefault(acc => acc.Email == emailToRemove);

            if (userToRemove != null)
            {
                accounts.Remove(userToRemove);
                JsonUtil.UploadToJson(accounts, accountPath);
                Console.WriteLine("Account removed.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        
    }
}




