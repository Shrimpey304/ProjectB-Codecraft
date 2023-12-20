namespace Restaurant;

public class LoginProcess
{

    private Ingelogdmenu ingelogdmenu = new();
    private Login login = new();
    private static string GivenEmail = "";
    
    public void LoginProcessMailView()
    {

        Console.WriteLine("welcome to Logging in (Beta version)");    
        Console.WriteLine("please enter your Email");
        GivenEmail = Console.ReadLine()!;

        if(!login.MailMatches(GivenEmail)){

            Console.Clear();
            Console.WriteLine("this email is not valid or is not registered yet");
            LoginProcessMailView();

        }
        

        LoginProcessPasswordView(GivenEmail);

    }

    public void LoginProcessPasswordView(string email)
    {

        Console.WriteLine("please enter your password"); 
        string GivenPW = Console.ReadLine()!;
        User? user = login.AccountExists(GivenPW, email);

        if(user is not null)
        {
            bool isAdmin = Login.IsAdmin(GivenPW, email);
            if (isAdmin)
            {
                Console.WriteLine("Login is successful heading to admin panel.");
                // AdminMenu.DisplayAdminMenu(); 
            }
            else
            {
                Console.WriteLine("Login is succesfull heading to mainscreen.");
                Thread.Sleep(2);
                ingelogdmenu.user = user;
                ingelogdmenu.logOut.Add(login);
                ingelogdmenu.DisplayIngelogdMenu();
                ///UserChangeAcc.UserSeeOwnAcc(email);
            }
        }
        else
        {

            Console.Clear();
            Console.WriteLine("incorrect password email combination");
            LoginProcessPasswordView(email);

        }
    }

    

}
