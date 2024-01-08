namespace Restaurant;

public class LoginProcess
{

    private Ingelogdmenu ingelogdmenu = new();
    private Login login = new();
    private static string GivenEmail = "";
    
    public void LoginProcessMailView()
    {
        Console.Clear();
        Header.DisplayHeader();
        Console.WriteLine($"\u001B[35m" + "Welcome to the login page!\n\n");    
        Console.WriteLine($"\u001B[35m" + "Please enter your Email\n");
        Console.Write(">  ");
        GivenEmail = Console.ReadLine()!;

        if(!login.MailMatches(GivenEmail)){

            Console.Clear();
            Console.WriteLine("this email is not valid");
            LoginProcessMailView();

        }

        LoginProcessPasswordView(GivenEmail);

    }

    public void LoginProcessPasswordView(string email)
    {

        Console.WriteLine($"\u001B[35m" + "\nPlease enter your password\n"); 
        Console.Write(">  ");
        string GivenPW = Console.ReadLine()!;
        User? user = login.AccountExists(GivenPW, email);

        if(user is not null)
        {
            Login.IsLoggedIn = true;
            bool isAdmin = Login.IsAdmin(GivenPW, email);
            if (isAdmin)
            {
                Console.WriteLine("Login is successful, heading to admin panel.");
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
