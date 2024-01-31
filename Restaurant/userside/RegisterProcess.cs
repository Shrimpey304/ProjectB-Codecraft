namespace Restaurant;

public class RegisterProcess{

    private Ingelogdmenu ingelogdmenu = new();
    private Registration REG = new Registration();
    protected const string filePath = @".\dataStorage\account.json";
    private static string GivenEmail = "";
    public User? loggedUser;
    
    public void RegisterMail(User? LoggedinUser = null){
        loggedUser = LoggedinUser;

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
            RegisterPhone(email, pass);
        }


        // ingelogdmenu.logOut.Add(REG);
        if(loggedUser is null){

            User user = REG.CreateAccount(email, pass, phone!, false);
            ingelogdmenu.user = user;
            JsonUtil.UpdateSingleObject(user, filePath);
            Login.IsLoggedIn = true;
            Login.LoggedinUser = user.Email;
            ingelogdmenu.DisplayIngelogdMenu();

        }else{
            ChangeAdminstatus(email, pass, phone);
        }
        
    }
    
    public void ChangeAdminstatus(string email, string password, string phone)
    {
        Console.Clear();
        Header.DisplayHeader();
        Console.WriteLine($"\u001B[35m" + "if you want this account to have admin permissions type: true\n otherwise type: false");
        Console.Write(">   ");
        string makeAdmin = Console.ReadLine();

        if(makeAdmin.ToLower() == "true"){

            Console.WriteLine($"\u001B[35m" + "Registration succesfull with admin permissions");
            User user = REG.CreateAccount(email, password, phone!, true);
            JsonUtil.UpdateSingleObject(user, filePath);
            AdminMenu.DisplayAdminMenu(loggedUser);


        }else if(makeAdmin.ToLower() == "false"){

            Console.WriteLine($"\u001B[35m" + "Registration succesfull without admin permissions");
            User user = REG.CreateAccount(email, password, phone!, false);
            JsonUtil.UpdateSingleObject(user, filePath);
            AdminMenu.DisplayAdminMenu(loggedUser);

        }else{
            ChangeAdminstatus(email, password, phone);
        }

        Login.IsLoggedIn = true;
        Login.LoggedinUser = loggedUser.Email;
        AdminMenu.DisplayAdminMenu(loggedUser);
    }
}