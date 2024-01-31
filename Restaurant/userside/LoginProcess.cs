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
            Console.WriteLine("Invalid email, please stick to the following format: your_email@your_webmail.com");
            Thread.Sleep(3000);

            LoginProcessMailView();

        }

        LoginProcessPasswordView(GivenEmail);

    }

    public void LoginProcessPasswordView(string email)
    {
        Console.Clear();
        Header.DisplayHeader();
        Console.WriteLine($"\u001B[35m" + "\nPlease enter your password\n"); 
        Console.Write(">  ");
        string GivenPW = Registration.HashPassword();
        User? user = login.AccountExists(GivenPW, email);

        if(user is not null)
        {
            Login.IsLoggedIn = true;
            bool isAdmin = Login.IsAdmin(GivenPW, email);
            if (isAdmin)
            {
                Console.WriteLine("Login is successful, heading to admin panel.");
                Thread.Sleep(2000);
                AdminMenu.DisplayAdminMenu(user); 
            }
            else
            {
                Console.WriteLine("Login is succesful heading to mainscreen.");
                Thread.Sleep(2000);
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
            Thread.Sleep(3000);
            LoginProcessPasswordView(email);

        }
    }

    

}
