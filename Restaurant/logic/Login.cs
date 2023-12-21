using Newtonsoft.Json;

namespace Restaurant;

public class Login : MasterLogin{

    public List<User> Accounts;
    public static string LoggedinUser = "";
    public static bool IsLoggedIn = false;

    

    public Login(){
        Accounts = JsonUtil.ReadFromJson<User>(filePath);
    }

    public bool MailMatches(string mail){
        List<User> accounts = JsonUtil.ReadFromJson<User>(filePath)!;
        User mailExist = accounts.FirstOrDefault(account => account.Email == mail)!;
        if(mailExist != null){
            return true;
        }else{
            return false;
        }
    }

    public User? AccountExists(string password, string mail){
        string key = mail;
        string val = password;

        User? account = Accounts.FirstOrDefault(acc => acc.Email == mail && acc.Password == password)!;
        LoggedinUser = key;
        return account;

    }

    public User getUserData(string mail){

        if(IsLoggedIn && MailMatches(mail)){
            User account = Accounts.FirstOrDefault(acc => acc.Email == mail)!;
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

    public static bool IsAdmin(string password, string mail)
        {
            List<User> accounts = JsonUtil.ReadFromJson<User>(filePath);
            User account = accounts.FirstOrDefault(acc => acc.Email == mail && acc.Password == password && acc.Admin);

            return account != null;
        }

    public override void LogOut(User user)
    {
        int userIndex = Accounts.FindIndex(item => item.Email == user.Email);
        if (userIndex != -1){
            Accounts[userIndex] = user;
            JsonUtil.UploadToJson(Accounts, filePath);
        }else{
            throw new NullReferenceException();
        }
    }
}
