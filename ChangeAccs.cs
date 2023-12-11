using System;
using System.Collections.Generic;

namespace Restaurant
{
    public class ChangeAccs
    {
        private static string accountPath = "ez.json";

        public static void ChangeAccsInfo()
        {
            Console.WriteLine("Enter the email of the account you want to modify:");
            string emailToModify = Console.ReadLine();

            List<User> accounts = JsonUtil.ReadFromJson<User>(accountPath);
            User userToModify = accounts.FirstOrDefault(acc => acc.Email == emailToModify);

            if (userToModify != null)
            {
                Console.WriteLine("Account found. Select the information to change:");
                Console.WriteLine("1. Email\n2. Password\n3. Phone Number\n4. Admin Status");

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

                    case 4:
                        Console.WriteLine("Change admin status (true/false):");
                        bool newAdminStatus = Convert.ToBoolean(Console.ReadLine());
                        userToModify.Admin = newAdminStatus;
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
                Console.WriteLine("Account not found.");
            }
        }
    }
}