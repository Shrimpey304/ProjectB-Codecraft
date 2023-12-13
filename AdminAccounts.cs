namespace Restaurant;

public class AdminAccounts
{

    private static string accountPath = @".\dataStorage\account.json";
    
    public static void SeeAccountsA()
    {
        Console.WriteLine("Showing all accounts...");
        string json = File.ReadAllText(accountPath);
        Console.WriteLine(json);
    }

    public static void AddAccountsA()
    {
        SeeAccountsA();

        Registration REG = new Registration();
  
        Console.WriteLine("Enter Email");
        string ?GivenEmail = "";
        while(Registration.CheckEmailRegEx(GivenEmail!) == false){
            string mail = Console.ReadLine()!;
            GivenEmail += mail + "";
        }

        Console.WriteLine("Enter password"); 
        Console.WriteLine("Capital, lower, number");
        string ?GivenPW = "";
        while(Registration.CheckPasswordFormat(GivenPW!) == false){
            string pass = Console.ReadLine()!;
            GivenPW += pass + "";
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

        Console.WriteLine("Admin: (true/false)");
        bool isAdmin = Convert.ToBoolean(Console.ReadLine()!);

        REG.CreateAccount(GivenEmail, GivenPW, PhoneNR!, isAdmin);
        AdminMenu.DisplayChangeAccMenu();
    }

    public static void RemoveAccountsA()
    {
        SeeAccountsA();

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


    public static void ChangeAccountsA()
    {
        SeeAccountsA();

        Console.WriteLine("Enter the email of the account you want to modify:");
        string emailToModify = Console.ReadLine();

        List<User> accounts = JsonUtil.ReadFromJson<User>(accountPath);
        User userToModify = accounts.FirstOrDefault(acc => acc.Email == emailToModify);

        if (userToModify != null)
        {
            Console.WriteLine("Account found. Select the information to change:");
            List<string> options = new(){
                "Change email of selected account",
                "Change password of selected account",
                "Change phone number of selected account",
                "Change admin status of selected account",
                "Go back to change other account",
                "Go back to admin accounts menu"
            };
            List<Action> actions = new(){
                ChangeEmail,
                ChangePassword,
                ChangePhonenumber,
                ChangeAdminstatus,
                ChangeAccountsA,
                AdminMenu.DisplayChangeAccMenu,
            };
            int selectedOption = DisplayUtil.Display(options);
            actions[selectedOption]();
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    public static void ChangeEmail()
    {

        Console.WriteLine("test...");
    }

    public static void ChangePassword()
    {

        Console.WriteLine("test...");
    }

    public static void ChangePhonenumber()
    {

        Console.WriteLine("test...");
    }

    public static void ChangeAdminstatus()
    {

        Console.WriteLine("test...");
    }

}