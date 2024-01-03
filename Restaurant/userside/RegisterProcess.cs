namespace Restaurant;

public class RegisterProcess{

    private Ingelogdmenu ingelogdmenu = new();
    private Registration REG = new Registration();
    protected const string filePath = @".\dataStorage\account.json";
    
    public void RegisterProcessView(){

        Console.WriteLine("welcome to registration (alpha version)");    
        Console.WriteLine("please enter your Email");
        string ?GivenEmail = "";
        while(Registration.CheckEmailRegEx(GivenEmail!) == false){
            string mail = Console.ReadLine()!;
            GivenEmail += mail + "";
        }

        Console.WriteLine("please enter your password"); 
        Console.WriteLine("Capital, lower, number");
        string ?GivenPW = "";
        while(Registration.CheckPasswordFormat(GivenPW!) == false){
            string pass = Registration.HashPassword();
            GivenPW += pass + "";
        }
        Console.WriteLine(GivenPW);
        

        Console.Write("please retype the password\n");
        string ?RetypePW = Registration.HashPassword();
        if(Registration.CheckPasswordSimilar(GivenPW!, RetypePW!) == true){
            Console.WriteLine("registratie succesvol");
        }else{
            Console.WriteLine("failed");
            
        }

        Console.WriteLine("please write your phone number");
        string PhoneNR = Console.ReadLine()!;
        Registration.CheckPhoneNumberFormat(PhoneNR);

        User user = REG.CreateAccount(GivenEmail, GivenPW, PhoneNR!, false);
        ingelogdmenu.user = user;
        // ingelogdmenu.logOut.Add(REG);
        JsonUtil.UpdateSingleObject(user, filePath);
        Login.IsLoggedIn = true;
        Login.LoggedinUser = user.Email;
        ingelogdmenu.DisplayIngelogdMenu();
    }
}