namespace Restaurant;

public class AdminEditAccs
{
    private static string accountPath = @".\dataStorage\account.json";
    private static List<User> accounts = JsonUtil.ReadFromJson<User>(accountPath)!;
    public static Registration registration = new();

    private static User GetAccByEmail()
    {
        Console.WriteLine("Enter the email of the account you want to change:");
        string currentEmail = Console.ReadLine()!;

        User userToChange = accounts.FirstOrDefault(acc => acc.Email == currentEmail)!;

        if (userToChange == null)
        {
            Console.WriteLine("Account not found.");
        }

        return userToChange;
    }
    
    public static void ChangeEmail(User user)
    {
        FormatJsonJ.FormatAccs();;
        User userToChange = GetAccByEmail();
        
        if (userToChange != null)
        {
            Console.WriteLine("Enter new email:");
            string newEmail = Console.ReadLine()!;

            if (!Registration.CheckEmailRegEx(newEmail))
            {
                Console.WriteLine("Invalid email format.");
                return;
            }

            if (registration.CheckEmailTaken(newEmail))
            {
                Console.WriteLine("Email is already taken.");
                return;
            }

        userToChange.Email = newEmail;

        JsonUtil.UploadToJson(accounts, accountPath);
        Console.WriteLine("Email changed successfully.");
        AdminMenu.DisplayChangeAccMenu(user);
        }
    }
    

    public static void ChangePassword(User user)
    {
        FormatJsonJ.FormatAccs();
        User userToChange = GetAccByEmail();

        if (userToChange != null)
        {
            Console.WriteLine("Enter new password:");
            string newPassword = Console.ReadLine();

            if (Registration.CheckPasswordFormat(newPassword))
            {
                userToChange.Password = newPassword;

                JsonUtil.UploadToJson(accounts, accountPath);
                Console.WriteLine("Password changed successfully.");
                AdminMenu.DisplayChangeAccMenu(user);
            }
        }
    }

    public static void ChangePhonenumber(User user)
    {
        FormatJsonJ.FormatAccs();
        User userToChange = GetAccByEmail();

        if (userToChange != null)
        {
            Console.WriteLine("Enter new phonenumber:");
            string newPhoneNumber = Console.ReadLine();

            userToChange.PhoneNumber = newPhoneNumber;

            JsonUtil.UploadToJson(accounts, accountPath);
            Console.WriteLine("Phonenumber changed successfully.");
            AdminMenu.DisplayChangeAccMenu(user);
        }
    }

    public static void ChangeAdminstatus(User user)
    {
        FormatJsonJ.FormatAccs(); 
        User userToChange = GetAccByEmail();
        
        if (userToChange != null)
        {
            Console.WriteLine("Enter Admin status (type true or else false)");
            string input = Console.ReadLine().ToLower();

             bool newAdminStatus = input == "true";

            userToChange.Admin = newAdminStatus;

            JsonUtil.UploadToJson(accounts, accountPath);
            Console.WriteLine("Admin status changed successfully.");
            AdminMenu.DisplayChangeAccMenu(user);
        }
    }
}

