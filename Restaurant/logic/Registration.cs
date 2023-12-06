namespace Restaurant;

using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Globalization;


public class Registration
{

    public static bool CheckPasswordSimilar(string password, string retypePassword)
    {

        if (password == retypePassword)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public static bool CheckPhoneNumberFormat(string phoneNumber)
    {
        if (phoneNumber.Length == 10)
        {
            return true;
        }
        else if (phoneNumber.Length > 10)
        {
            Console.WriteLine("Phone number too long, please enter a phone number that's up to 10 digits long");
            return false;
        }
        else
        {
            Console.WriteLine("Phone number too short, please enter a phone number that's 10 digits long");
            return false;
        }
    }

    public static bool CheckPasswordFormat(string Password)
    {

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
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, (password.Length - 1));
                Console.Write("\b \b");
            }

        }while (key.Key != ConsoleKey.Enter);
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
    private static string accountPath = @".\dataStorage\account.json";

    public static bool CheckEmailTaken(string email)
    {

        List<User> accounts = JsonUtil.ReadFromJson<User>(accountPath)!;
        User mailExist = accounts.FirstOrDefault(account => account.Email == email)!;

        if (mailExist != null)
        {
            return true; //email is taken
        }
        else
        {
            return false;//email is not taken
        }

    }


    public static bool CheckEmailRegEx(string Email)
    {

        //regex for Email
        string RegEx = "^[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*$";

        if (!Regex.IsMatch(Email, RegEx))
        {
            return false;
        }
        else
        {
            return true;
        }

    }


    public void CreateAccount(string Email, string Password, string PhoneNumber)
    {

        string email = Email;
        string password = Password;
        string phonenumber = PhoneNumber;

        List<User> acc = JsonUtil.ReadFromJson<User>(accountPath)!;
        if (acc == null)
        {
            acc = new List<User>();
        }
        User account = new User { Email = email, Password = password, PhoneNumber = phonenumber };
        acc.Add(account);
        JsonUtil.UploadToJson(acc, accountPath);
    }
}