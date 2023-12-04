namespace Restaurant;

public class LoginProcess{

    private static string GivenEmail = "";
    
    public static void LoginProcessMailView(){

        Console.WriteLine("welcome to Logging in (Beta version)");    
        Console.WriteLine("please enter your Email");
        GivenEmail = Console.ReadLine()!;

        if(!Login.MailMatches(GivenEmail)){

            Console.Clear();
            Console.WriteLine("this email is not valid or is not registered yet");
            LoginProcessMailView();

        }

        LoginProcessPasswordView(GivenEmail);

    }

    public static void LoginProcessPasswordView(string email){

        Console.WriteLine("please enter your password"); 
            
        string GivenPW = Console.ReadLine()!;

        if(Login.AccountExists(GivenPW, email)){

            Console.WriteLine("Login is succesfull heading to mainscreen");
            Thread.Sleep(2);
            Ingelogdmenu.DisplayIngelogdMenu();

        }else{

            Console.Clear();
            Console.WriteLine("incorrect password email combination");
            LoginProcessPasswordView(email);

        }
    }

}
