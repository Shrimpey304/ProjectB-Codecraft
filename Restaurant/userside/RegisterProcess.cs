namespace Restaurant;

public class RegisterProcess{

    private Ingelogdmenu ingelogdmenu = new();
    private Registration REG = new Registration();
    protected const string filePath = @".\dataStorage\account.json";
    private static string GivenEmail = "";
    
    public void RegisterMail(){

        Console.Clear();
        Header.DisplayHeader();
        Console.WriteLine($"\u001B[35m" + "Welcome to the registration page!\n\n");
        Console.WriteLine($"\u001B[35m" + "Please enter the email you would like to register\n");
        Console.Write(">   ");

        GivenEmail = Console.ReadLine()!;

        if(!Registration.CheckEmailRegEx(GivenEmail)){
            if(!REG.CheckEmailTaken(GivenEmail)){
                Console.Clear();
                Console.WriteLine($"\u001B[35m" + "this email is already registered");
                RegisterMail();
            }
            Console.WriteLine($"\u001B[35m" + "this is not a valid email format");
        }

        RegisterPassword(GivenEmail);
    }

    public void RegisterPassword(string email){

        Console.Clear();
        Header.DisplayHeader();
        Console.WriteLine($"\u001B[35m" + "\nPlease enter a password with atleast:\n 1 capital letter, 1 lower letter, a number and a punctuation mark. the password must be 8 characters or more");
        Console.Write(">   ");

        string pass = Console.ReadLine();

        if(!Registration.CheckPasswordFormat(pass)){
            RegisterPassword(email);
        }

        RegisterPasswordConfirmation(email, pass);
        
    }

    public void RegisterPasswordConfirmation(string email, string pass){

        Console.Clear();
        Header.DisplayHeader();
        Console.WriteLine($"\u001B[35m" + "\nPlease enter the password again");
        Console.Write(">   ");
        
        string passconfirm = Console.ReadLine();

        if(!Registration.CheckPasswordSimilar(pass, passconfirm)){
            RegisterPasswordConfirmation(email, pass);
        }

        RegisterPhone(email, passconfirm);
    }

    public void RegisterPhone(string email, string pass){

        Console.Clear();
        Header.DisplayHeader();
        Console.WriteLine($"\u001B[35m" + "Please enter your phone number");
        Console.Write(">   ");

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


    // public void RegisterProcessView(){

    //     Console.WriteLine("welcome to registration (alpha version)");    
    //     Console.WriteLine("please enter your Email");
    //     string ?GivenEmail = "";
    //     while(Registration.CheckEmailRegEx(GivenEmail!) == false){
    //         Console.Clear();
    //         Console.WriteLine("invalid email format");
    //         string mail = Console.ReadLine()!;
    //         GivenEmail += mail + "";
    //     }

    //     Console.WriteLine("please enter your password"); 
    //     Console.WriteLine("Capital, lower, number");
    //     string ?GivenPW = "";
    //     while(Registration.CheckPasswordFormat(GivenPW!) == false){
    //         string pass = Registration.HashPassword();
    //         GivenPW += pass + "";
    //     }
    //     Console.WriteLine(GivenPW);
        

    //     Console.Write("please retype the password\n");
    //     string ?RetypePW = Registration.HashPassword();
    //     if(Registration.CheckPasswordSimilar(GivenPW!, RetypePW!) == true){
    //         Console.WriteLine("registratie succesvol");
    //     }else{
    //         Console.WriteLine("failed");
    //     }

    //     Console.WriteLine("please write your phone number");
    //     string PhoneNR = Console.ReadLine()!;
    //     Registration.CheckPhoneNumberFormat(PhoneNR);

    //     User user = REG.CreateAccount(GivenEmail, GivenPW, PhoneNR!, false);
    //     ingelogdmenu.user = user;
    //     // ingelogdmenu.logOut.Add(REG);
    //     JsonUtil.UpdateSingleObject(user, filePath);
    //     Login.IsLoggedIn = true;
    //     Login.LoggedinUser = user.Email;
    //     ingelogdmenu.DisplayIngelogdMenu();
    // }
}