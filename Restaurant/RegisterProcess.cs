namespace Restaurant;

public class RegisterProcess{

    public static void RegisterProcessView(){

        Registration REG = new Registration();

        Console.WriteLine("welcome to registration (alpha version)");    
        Console.WriteLine("please enter your Email");
        string ?GivenEmail = "";
        while(Registration.CheckEmailRegEx(GivenEmail!) == false){
            string mail = Console.ReadLine()!;
            GivenEmail += mail + "";
        }
        Console.WriteLine(GivenEmail);

        Console.WriteLine("please enter your password"); 
        Console.WriteLine("Capital, lower, number, token");
        string ?GivenPW = "";
        while(GivenPW.Length < 4){ //Registration.CheckPasswordFormat(GivenPW!) == false
            string pass = Console.ReadLine()!;
            GivenPW += pass + "";
            Console.WriteLine("initial pw");
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
        string PhoneNR = Console.ReadLine();

        REG.CreateAccount(GivenEmail, GivenPW, PhoneNR);
        Ingelogdmenu.DisplayIngelogdMenu();
    }

}