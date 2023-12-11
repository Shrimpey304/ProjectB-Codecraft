namespace Restaurant;

public class RegisterProcess
{

    public static void RegisterProcessView()
    {

        Registration REG = new Registration();

        Console.WriteLine("welcome to registration (alpha version)");
        Console.WriteLine("please enter your Email");
        string? GivenEmail = "";
        while (Registration.CheckEmailRegEx(GivenEmail!) == false)
        {
            string mail = Console.ReadLine()!;
            GivenEmail += mail + "";
        }

        Console.WriteLine("please enter your password");
        Console.WriteLine("Capital, lower, number");
        string? GivenPW = Registration.HashPassword(); ///added HashPassword + removed Console.ReadLine
        while (Registration.CheckPasswordFormat(GivenPW!) == false) ///Problem with hash: if password is wrong (less than 8 digits for example) hash doesn't take place 
        {
            string pass = Console.ReadLine()!;
            GivenPW += pass + "";
        }
        Console.WriteLine("\n" + GivenPW);


        Console.Write("please retype the password\n");
        string? RetypePW = Registration.HashPassword(); ///added HashPassword + removed Console.ReadLine
        Console.WriteLine("\nplease write your phone number");
        string PhoneNR = Console.ReadLine()!;
        Registration.CheckPhoneNumberFormat(PhoneNR);

        REG.CreateAccount(GivenEmail, GivenPW, PhoneNR!);
        Ingelogdmenu.DisplayIngelogdMenu();
        if (Registration.CheckPasswordSimilar(GivenPW!, RetypePW!) == true)
        {
            Console.WriteLine("\nregistratie succesvol");
        }
        else
        {
            Console.WriteLine("failed");
        }

    }

}