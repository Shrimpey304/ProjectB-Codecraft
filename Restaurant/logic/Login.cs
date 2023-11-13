using Newtonsoft.Json;

namespace Restaurant;

public class Login
{

    public static string LoggedinUser = "";
    public static bool IsLoggedIn = false;

    private static string accountPath = @".\dataStorage\account.json";
    public static bool PassMatches(User Password){

        List<User> accounts = File.Exists(accountPath) 
        ? JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(accountPath) ?? string.Empty) ?? new List<User>()
        : new List<User>(); 

        if(accounts.Contains(Password)){
            return true;
        }else{
            return false;
        }

    }

    public static bool MailMatches(User mail){
        
        List<User> accounts = File.Exists(accountPath) 
        ? JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(accountPath) ?? string.Empty) ?? new List<User>()
        : new List<User>(); 

        if(accounts.Contains(mail)){
            return true;
        }else{
            return false;
        }

    }

    public static void AccountExists(string Password, string mail){
        string key  = mail;
        string val = Password;

        List<User> accounts = File.Exists(accountPath) 
        ? JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(accountPath) ?? string.Empty) ?? new List<User>()
        : new List<User>(); 

        Console.WriteLine(accounts);

    }

    public static bool getStatus(){
        return IsLoggedIn;
    }

    public static string getUser(){
        return LoggedinUser;
    }
}
