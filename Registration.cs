using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Globalization;

public class Registration{

    public bool CheckPasswordFormat(string Password){

        string PassIssue;

        if(Password.Length >= 6 && Password.Length <= 18 
            && Password.Any(char.IsUpper) 
            && Password.Any(char.IsLower) 
            && Password.Any(char.IsNumber) 
            && Password.Any(char.IsSymbol)){

            return true; //password is accepted

        }else{

            int passwordLength = Password.Length;
            switch (passwordLength)
            {
                case int n when n < 6:
                    PassIssue = "Password is too short";
                    return false;
                case int n when n > 18:
                    PassIssue = "Password is too long";
                    return false;
                default:
                    if (!Password.Any(char.IsUpper) || !Password.Any(char.IsLower) || !Password.Any(char.IsNumber) || !Password.Any(char.IsSymbol))
                    {
                        PassIssue = "Password does not meet the criteria";
                        return false;
                    }
                return false;
            }
        }
    }


    public bool CheckEmailTaken(User Email){

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


    public bool CheckEmailRegEx(string Email){

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