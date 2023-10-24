namespace Restaurant;

public class RegisterProcess{
    
    public static void RegisterProcessEmail(){
        Console.WriteLine("welcome to registration (alpha version)");    
        string ?GivenEmail = "";
        while(Registration.CheckEmailRegEx(GivenEmail!) == false){
            string mail = Console.ReadLine()!;
            GivenEmail += mail + "";
        }
        
    }

    public static void RegisterProcessPassword(){

        Console.Write("please enter your password"); 
        string ?GivenPW = "";
        while(Registration.CheckPasswordFormat(GivenPW!) == false){
            string pass = Console.ReadLine()!;
            GivenPW += pass + "";
        }

        Console.Write("please retype the password");
        string ?RetypePW = Console.ReadLine();
        bool PWSimilar = Registration.CheckPasswordSimilar(GivenPW!, RetypePW!);
        if(PWSimilar == true){
            Console.WriteLine("registratie succesvol");
        }
    }

}
