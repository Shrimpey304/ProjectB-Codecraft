namespace Restaurant;
public class UserChangeOwnAcc
    {
        private static string accountPath = @".\dataStorage\account.json";
        private static List<User> accounts = JsonUtil.ReadFromJson<User>(accountPath);
        public static Registration registration = new();
        public static Ingelogdmenu ingelogdmenu = new();
        private static User userToChange;

        public static User SeeAccInfoByPassword(User user)
        {
            Console.WriteLine("Enter password to see and change account:");
            string password = Registration.HashPassword();

            userToChange = accounts.FirstOrDefault(acc => acc.Password == password);

            if (userToChange == null)
            {
                Console.WriteLine("Account not found.");
                Thread.Sleep(2000);
                ingelogdmenu.user = user;
                ingelogdmenu.DisplayIngelogdMenu();
            }
            else
            {
                Console.WriteLine("------------");
                Console.WriteLine($"Email: {userToChange.Email}");
                Console.WriteLine($"Password: {userToChange.Password}");
                Console.WriteLine($"Phone number: {userToChange.PhoneNumber}");
                Console.WriteLine("------------");

                Console.WriteLine("Press enter to change");
                Console.ReadLine();

                DisplayChangeOptions(user);
            }

            return userToChange;
        }

        private static void DisplayChangeOptions(User user)
        {
            List<string> options = new()
            {
                "Change email",
                "Change phone number",
                "Change password",
                "Go back",
            };
            int selectedOption = DisplayUtil.Display(options);
            switch (selectedOption)
            {
                case 0:
                    ChangeUserEmail(user);
                    break;
                case 1:
                    ChangeUserPhoneNumber(user);
                    break;
                case 2:
                    ChangeUserPassword(user);
                    break;
                case 3:
                    ingelogdmenu.user = user;
                    ingelogdmenu.DisplayIngelogdMenu();
                    break;
                default:
                    throw new Exception("Unexpected menu error");
            }
        }

        public static void ChangeUserEmail(User user)
        {
            if (userToChange != null)
            {
                Console.WriteLine("Enter new email:");
                string newEmail = Console.ReadLine()!;

                if (!Registration.CheckEmailRegEx(newEmail))
                {
                    Console.WriteLine("Invalid email format.");
                    Thread.Sleep(2000);
                    ingelogdmenu.user = user;
                    ingelogdmenu.DisplayIngelogdMenu();
                    return;
                }

                if (registration.CheckEmailTaken(newEmail))
                {
                    Console.WriteLine("Email is already taken.");
                    Thread.Sleep(2000);
                    ingelogdmenu.user = user;
                    ingelogdmenu.DisplayIngelogdMenu();
                    return;
                }

                userToChange.Email = newEmail;

                JsonUtil.UploadToJson(accounts, accountPath);
                Console.WriteLine("Email changed successfully.");
                ingelogdmenu.user = user;
                ingelogdmenu.DisplayIngelogdMenu();
            }
        }

        public static void ChangeUserPassword(User user)
        {
            if (userToChange != null)
            {
                Console.WriteLine("Enter new password:");
                string newPassword = Console.ReadLine();

                if (Registration.CheckPasswordFormat(newPassword))
                {
                    userToChange.Password = newPassword;

                    JsonUtil.UploadToJson(accounts, accountPath);
                    Console.WriteLine("Password changed successfully.");
                    ingelogdmenu.user = user;
                    ingelogdmenu.DisplayIngelogdMenu();
                }
            }
        }

        public static void ChangeUserPhoneNumber(User user)
        {
            if (userToChange != null)
            {
                Console.WriteLine("Enter new phonenumber:");
                string newPhoneNumber = Console.ReadLine();

                userToChange.PhoneNumber = newPhoneNumber;

                JsonUtil.UploadToJson(accounts, accountPath);
                Console.WriteLine("Phonenumber changed successfully.");
                ingelogdmenu.user = user;
                ingelogdmenu.DisplayIngelogdMenu();
            }
        }
    }
