namespace Restaurant;

public class AdminEditAccs
{
    private static string accountPath = @".\dataStorage\account.json";
    public static Registration registration = new();
    public static void ChangeEmail(){
    AdminAccounts.SeeAccountsA();

    Console.WriteLine("Enter the email of the account that you want to change:");
    string currentEmail = Console.ReadLine()!;

    List<User> accounts = JsonUtil.ReadFromJson<User>(accountPath)!;
    User userToChange = accounts.FirstOrDefault(acc => acc.Email == currentEmail)!;

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

        userToChange.ChangeEmail(newEmail);

        JsonUtil.UploadToJson(accounts, accountPath);
        Console.WriteLine("Email changed successfully.");
        AdminMenu.DisplayChangeAccMenu();
    }
    else
    {
        Console.WriteLine("Account not found.");
    }
}

    public static void ChangePassword()
{
    AdminAccounts.SeeAccountsA();

    Console.WriteLine("Enter the email of the account that you want to cahnge:");
    string userEmail = Console.ReadLine();

    List<User> accounts = JsonUtil.ReadFromJson<User>(accountPath);
    User userToChange = accounts.FirstOrDefault(acc => acc.Email == userEmail);

    if (userToChange != null)
    {
        Console.WriteLine($"Enter the new password for {userEmail}:");
        string newPassword = Console.ReadLine();

        if (Registration.CheckPasswordFormat(newPassword))
        {
            // Change the password using the method from the User class
            userToChange.ChangePassword(newPassword);

            JsonUtil.UploadToJson(accounts, accountPath);
            Console.WriteLine("Password changed successfully.");
            AdminMenu.DisplayChangeAccMenu();
        }
        else
        {
            Console.WriteLine("Invalid password");
        }
    }
    else
    {
        Console.WriteLine("Account not found.");
    }
}

    public static void ChangePhonenumber()
    {
        AdminAccounts.SeeAccountsA(); 

        Console.WriteLine("Enter the email of the account that you want to change:");
        string userEmail = Console.ReadLine();

        List<User> accounts = JsonUtil.ReadFromJson<User>(accountPath);
        User userToChange = accounts.FirstOrDefault(acc => acc.Email == userEmail);

        if (userToChange != null)
        {
            Console.WriteLine($"Enter the new phonenumber for {userEmail}:");
            string newPhoneNumber = Console.ReadLine();

            // Change the phone number using the extension method
            userToChange.ChangePhonenumber(newPhoneNumber);

            JsonUtil.UploadToJson(accounts, accountPath);
            Console.WriteLine("Phonenumber changed successfully.");
            AdminMenu.DisplayChangeAccMenu();
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    public static void ChangeAdminstatus()
    {
        AdminAccounts.SeeAccountsA(); 

        Console.WriteLine("Enter the email of the account that you want to change:");
        string userEmail = Console.ReadLine();

        List<User> accounts = JsonUtil.ReadFromJson<User>(accountPath);
        User userToChange = accounts.FirstOrDefault(acc => acc.Email == userEmail);

        if (userToChange != null)
        {
            Console.WriteLine("Enter Admin status (true or false");
            string input = Console.ReadLine().ToLower();

            bool newAdminStatus = input == "true";

            // Change the admin status using the method from the User class
            userToChange.ChangeAdminstatus(newAdminStatus);

            JsonUtil.UploadToJson(accounts, accountPath);
            Console.WriteLine("Admin status changed successfully.");
            AdminMenu.DisplayChangeAccMenu();
        }
        else
        {
        Console.WriteLine("Account not found.");
        }
    }
}

