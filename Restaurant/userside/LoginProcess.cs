namespace Restaurant;

public class LoginProcess{

    private Ingelogdmenu ingelogdmenu = new();
    private static string GivenEmail = "";
    
    public void LoginProcessMailView(){

        Console.WriteLine("welcome to Logging in (alpha version)");    
        Console.WriteLine("please enter your Email");
        GivenEmail = Console.ReadLine()!;

        if(!Login.MailMatches(GivenEmail)){

            Console.Clear();
            Console.WriteLine("this email is not valid or is not registered yet");
            LoginProcessMailView();

        }

        LoginProcessPasswordView(GivenEmail);

    }

    public void LoginProcessPasswordView(string email){

        Console.WriteLine("please enter your password"); 
            
        string GivenPW = Console.ReadLine()!;
        User? user = Login.AccountExists(GivenPW, email);

        if(user is not null){

            Console.WriteLine("Login is succesfull heading to mainscreen");
            Thread.Sleep(2);
            ingelogdmenu.user = user;
            ingelogdmenu.DisplayIngelogdMenu();

        }else{

            Console.Clear();
            Console.WriteLine("incorrect password email combination");
            LoginProcessPasswordView(email);

        }
    }

}
