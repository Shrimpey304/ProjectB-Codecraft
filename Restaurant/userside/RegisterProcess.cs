namespace Restaurant;

public class RegisterProcess{

    private Ingelogdmenu ingelogdmenu = new();
    private Registration REG = new Registration();
    
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
            string pass = Console.ReadLine()!;
            GivenPW += pass + "";
        }
        Console.WriteLine(GivenPW);
        

        Console.Write("please retype the password\n");
        string ?RetypePW = Console.ReadLine();
        if(Registration.CheckPasswordSimilar(GivenPW!, RetypePW!) == true){
            Console.WriteLine("registratie succesvol");
        }else{
            Console.WriteLine("failed");
        }

        Console.WriteLine("please write your phone number");
        string PhoneNR = Console.ReadLine()!;

        User user = REG.CreateAccount(GivenEmail, GivenPW, PhoneNR!);
        ingelogdmenu.user = user;
        ingelogdmenu.logOut.Add(REG);
        ingelogdmenu.DisplayIngelogdMenu();
    }
}