namespace Restaurant;

public class RegisterProcess{

    private Ingelogdmenu ingelogdmenu = new();
    private Registration REG = new Registration();
    protected const string filePath = @".\dataStorage\account.json";
    private static string GivenEmail = "";
    
    public void RegisterMail(){
        GivenEmail = Console.ReadLine()!;

        if(!Registration.CheckEmailRegEx(GivenEmail)){
            if(!REG.CheckEmailTaken(GivenEmail)){
                Console.Clear();
                Console.WriteLine("this email is already registered");
                RegisterMail();
            }
            Console.WriteLine("this is not a valid email format");
        }

        RegisterPassword(GivenEmail);
    }

    public void RegisterPassword(string email){
        Console.WriteLine("please enter a password with atleast:\n 1 capital letter, 1 lower letter, a number and a readtoken. the password must be 8 characters or more");

        string pass = Console.ReadLine();
        Console.Clear();

        if(!Registration.CheckPasswordFormat(pass)){
            RegisterPassword(email);
        }

        RegisterPasswordConfirmation(email, pass);
        
    }

    public void RegisterPasswordConfirmation(string email, string pass){
        Console.WriteLine("please enter the password again");

        string passconfirm = Console.ReadLine();
        Console.Clear();

        if(!Registration.CheckPasswordSimilar(pass, passconfirm)){
            RegisterPasswordConfirmation(email, pass);
        }

        RegisterPhone(email, passconfirm);
    }

    public void RegisterPhone(string email, string pass){
        Console.WriteLine("please enter your phone number");

        string phone = Console.ReadLine();
        Console.Clear();

        if(!Registration.CheckPhoneNumberFormat(phone)){
            Console.WriteLine("invalid phone number format");
        }

        User user = REG.CreateAccount(email, pass, phone!, false);
        ingelogdmenu.user = user;
        // ingelogdmenu.logOut.Add(REG);
        JsonUtil.UpdateSingleObject(user, filePath);
        Login.IsLoggedIn = true;
        Login.LoggedinUser = user.Email;
        ingelogdmenu.DisplayIngelogdMenu();
    }


    public void RegisterProcessView(){

        Console.WriteLine("welcome to registration (alpha version)");    
        Console.WriteLine("please enter your Email");
        string ?GivenEmail = "";
        while(Registration.CheckEmailRegEx(GivenEmail!) == false){
            Console.Clear();
            Console.WriteLine("invalid email format");
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