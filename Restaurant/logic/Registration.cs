namespace Restaurant;

using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Globalization;


public class Registration{

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


    public static bool CheckEmailTaken(User Email){

        //Open the accounts json as a list

        List<User> accounts = File.Exists("accounts.json") 
        ? JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("accounts.json") ?? string.Empty) ?? new List<User>()
        : new List<User>(); 

        if(accounts.Contains(Email)){
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


    public void CreateAccount(string Email, string Password, string PhoneNumber){

        string email = Email;
        string password = Password;
        string phonenumber = PhoneNumber;

        List<User> accounts = File.Exists("accounts.json") 
        ? JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("accounts.json") ?? string.Empty) ?? new List<User>()
        : new List<User>();

        var account = new User { Email = email, Password = password, PhoneNumber = phonenumber};
        accounts.Add(account);
        File.WriteAllText("accounts.json", JsonConvert.SerializeObject(accounts, Formatting.Indented) ?? string.Empty);
        
    }
}