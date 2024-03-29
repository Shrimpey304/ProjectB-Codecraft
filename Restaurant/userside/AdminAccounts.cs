namespace Restaurant;

public class AdminAccounts
{

    private static string accountPath = @".\dataStorage\account.json";
    public static void SeeAccountsA()
    {
        FormatJsonJ.FormatAccs();
        Console.WriteLine("Press enter to go back to change accounts menu");
        Console.ReadLine();
        AdminMenu.DisplayChangeAccMenu(); 
    }
    
    public static void AddAccountsA()
    {
        FormatJsonJ.FormatAccs();

        Registration REG = new Registration();
  
        Console.WriteLine("Make new account: ");
        Console.WriteLine("Enter Email");
        string ?GivenEmail = "";
        while(Registration.CheckEmailRegEx(GivenEmail!) == false){
            string mail = Console.ReadLine()!;
            GivenEmail += mail;
        }

        Console.WriteLine("Enter password"); 
        Console.WriteLine("Capital, lower, number");
        string ?GivenPW = "";
        while(Registration.CheckPasswordFormat(GivenPW!) == false){
            string pass = Console.ReadLine()!;
            GivenPW += pass;
        }
        Console.WriteLine(GivenPW);
        

        Console.Write("Retype the password\n");
        string ?RetypePW = Console.ReadLine();
        if(Registration.CheckPasswordSimilar(GivenPW!, RetypePW!) == true){
            Console.WriteLine("registratie succesvol");
        }else{
            Console.WriteLine("failed");
        }

        Console.WriteLine("Enter phone number");
        string PhoneNR = Console.ReadLine()!;

        Console.WriteLine("Enter Admin status (true or false)");
        bool isAdmin = Convert.ToBoolean(Console.ReadLine()!);

        REG.CreateAccount(GivenEmail, GivenPW, PhoneNR!, isAdmin);
        AdminMenu.DisplayChangeAccMenu();
    }

    public static void RemoveAccountsA()
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
            AdminMenu.DisplayChangeAccMenu();
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }
}