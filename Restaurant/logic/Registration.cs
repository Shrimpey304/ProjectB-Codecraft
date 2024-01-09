namespace Restaurant;

using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Globalization;


public class Registration{
    public List<User> Accounts;
    protected const string filePath = @".\dataStorage\account.json";

    public Registration(){
        Accounts = JsonUtil.ReadFromJson<User>(filePath)!;
    }

    public static bool CheckPasswordSimilar(string password, string retypePassword){

        if(password == retypePassword){
            return true;
        }else{
            return false;
        }

    }

    public static bool CheckPasswordFormat(string Password){

        if (Password.Length < 8)
        {
            Console.WriteLine("Password must be at least 8 characters long.");
            return false;
        }

        if (!ContainsUpperCase(Password))
        {
            Console.WriteLine("Password must contain at least one uppercase letter.");
            return false;
        }

        if (!ContainsLowerCase(Password))
        {
            Console.WriteLine("Password must contain at least one lowercase letter.");
            return false;
        }

        if (!ContainsDigit(Password))
        {
            Console.WriteLine("Password must contain at least one digit.");
            return false;
        }

        return true;
    }

    public static bool CheckPhoneNumberFormat(string PhoneNR)
    {
        if (PhoneNR.Length < 8)
        {
            Console.WriteLine("Invalid. Phone number must be longer than 8 characters.");
            return false;
        }
        else
        {
            Console.WriteLine("Phone number stored, registration succesful");
            Thread.Sleep(1500);
            return true;
        }
    }

    public static string HashPassword()
    {
        ConsoleKeyInfo key;
        string password = "";
        do
        {
            key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write(key.KeyChar);
                Thread.Sleep(200); 
                Console.Write("\b*");
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, (password.Length - 1));
                Console.Write("\b \b");
            }

        }while (key.Key != ConsoleKey.Enter);
        Console.WriteLine();
        return password;
    }

    static bool ContainsUpperCase(string password)
    {
        foreach (char c in password)
        {
            if (char.IsUpper(c))
            {
                return true;
            }
        }
        return false;
    }

    static bool ContainsLowerCase(string password)
    {
        foreach (char c in password)
        {
            if (char.IsLower(c))
            {
                return true;
            }
        }
        return false;
    }

    static bool ContainsDigit(string password)
    {
        foreach (char c in password)
        {
            if (char.IsDigit(c))
            {
                return true;
            }
        }
        return false;
    }

    public bool CheckEmailTaken(string email){

        User mailExist = Accounts.FirstOrDefault(account => account.Email == email)!;

        if(mailExist != null){
            return true; //email is taken
        }else{
            return false;//email is not taken
        }

    }


    public static bool CheckEmailRegEx(string Email){

        //regex for Email
        string RegEx = "^[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*$";

        if(!Regex.IsMatch(Email, RegEx))
        {
            return false;
        }
        else
        {
            return true;
        }

    }
    public User CreateAccount(string Email, string Password, string PhoneNumber, bool isAdmin){

        if (Accounts == null)
        {   
            Accounts = new List<User>();
        }   
        User newUser = new User(Email, Password, PhoneNumber, isAdmin);

        Accounts.Add(newUser);

        JsonUtil.UploadToJson(Accounts, filePath);

        return newUser;
    }
}