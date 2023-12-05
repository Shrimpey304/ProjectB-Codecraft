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

    public static User? AccountExists(string password, string mail){
        string key = mail;
        string val = password;

        List<User> accounts = JsonUtil.ReadFromJson<User>(accountPath)!;

        User? account = accounts.FirstOrDefault(acc => acc.Email == mail && acc.Password == password)!;
        Console.WriteLine(account);

        LoggedinUser = key;

        return account;

    }

    public static User getUserData(string mail){

        if(IsLoggedIn && MailMatches(mail)){
            List<User> accounts = JsonUtil.ReadFromJson<User>(accountPath)!;

            User account = accounts.FirstOrDefault(acc => acc.Email == mail)!;
            return account;
        }
        return null!;
    }

    public static bool getStatus(){
        return IsLoggedIn;
    }

    public static string getUser(){
        if(LoggedinUser != ""){
            return LoggedinUser;
        }else{
            return "Guest";
        }
    }
}
