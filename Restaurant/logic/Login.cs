using Newtonsoft.Json;

namespace Restaurant;

public class Login
{

    public static string LoggedinUser = "";
    public static bool IsLoggedIn = false;

    private static string accountPath = @".\dataStorage\account.json";

    public static bool MailMatches(string mail){
        
        List<User> accounts = JsonUtil.ReadFromJson<User>(accountPath)!;
        User mailExist = accounts.FirstOrDefault(account => account.Email == mail)!;

        if(mailExist != null){
            return true;
        }else{
            return false;
        }

    }

    public static bool AccountExists(string password, string mail){
        string key  = mail;
        string val = password;

        List<User> accounts = JsonUtil.ReadFromJson<User>(accountPath)!;

        User account = accounts.FirstOrDefault(acc => acc.Email == mail && acc.Password == password)!;

        if(account != null){
            return true;
        }else{
            return false;
        }

    }

    public static bool getStatus(){
        return IsLoggedIn;
    }

    public static string getUser(){
        return LoggedinUser;
    }
}
