namespace Restaurant;

public class AdminAccounts
{

    private static string accountPath = @".\dataStorage\account.json";

    public User user;

    public static void SeeAccountsA(User user)
    {
        FormatJsonJ.FormatAccs();
        Console.WriteLine("Press enter to go back to change accounts menu");
        Console.ReadLine();
        AdminMenu.DisplayChangeAccMenu(user); 
    }
    
    public static void AddAccountsA(User user)
    {
        RegisterProcess REG = new();
        Console.WriteLine("Going to register");
        REG.RegisterMail(user);
    }

    public static void RemoveAccountsA(User user)
    {
        FormatJsonJ.FormatAccs();

        Console.WriteLine("Enter the email of the account that you want to remove:");
        string emailToRemove = Console.ReadLine();

        List<User> accounts = JsonUtil.ReadFromJson<User>(accountPath);
        User userToRemove = accounts.FirstOrDefault(acc => acc.Email == emailToRemove);

        if (userToRemove != null)
        {
            accounts.Remove(userToRemove);
            JsonUtil.UploadToJson(accounts, accountPath);
            Console.WriteLine("Account removed.");
            AdminMenu.DisplayChangeAccMenu(user);
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }
}