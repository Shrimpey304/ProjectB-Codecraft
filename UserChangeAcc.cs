using System;
using System.Collections.Generic;

namespace Restaurant
{
    public class UserChangeAccs
    {
        private static string accountPath = "ez.json";

        public static void UserChangeAccsInfo()
        {
            Console.WriteLine("Enter your email:");
            string userEmail = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            string userPassword = Console.ReadLine();

            List<User> accounts = JsonUtil.ReadFromJson<User>(accountPath);
            User userToModify = accounts.FirstOrDefault(acc => acc.Email == userEmail && acc.Password == userPassword);

            if (userToModify != null)
            {
                Console.WriteLine("Account found. Select the information to change:");
                Console.WriteLine("1. Email\n2. Password\n3. Phone Number");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the new email:");
                        string newEmail = Console.ReadLine();
                        if (Registration.CheckEmailRegEx(newEmail) && !Registration.CheckEmailTaken(newEmail))
                        {
                            userToModify.Email = newEmail;
                        }
                        else
                        {
                            Console.WriteLine("Invalid or already existing email. Change aborted.");
                            return;
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter the new password:");
                        string newPassword = Console.ReadLine();
                        if (Registration.CheckPasswordFormat(newPassword))
                        {
                            userToModify.Password = newPassword;
                        }
                        else
                        {
                            Console.WriteLine("Invalid password format. Change aborted.");
                            return;
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter the new phone number:");
                        string newPhoneNumber = Console.ReadLine();
                        userToModify.PhoneNumber = newPhoneNumber;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                // Update the JSON file with the modified account information
                JsonUtil.UploadToJson(accounts, accountPath);
                Console.WriteLine("Account information updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid email or password. Account not found.");
            }
        }
    }
}
