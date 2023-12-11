using System;
using System.IO;

namespace Restaurant
{
    public class MakeAdminAccs
    {
        public static void AddUser()
        {

        Registration REG = new Registration();
  
        Console.WriteLine("Enter Email");
        string ?GivenEmail = "";
        while(Registration.CheckEmailRegEx(GivenEmail!) == false){
            string mail = Console.ReadLine()!;
            GivenEmail += mail + "";
        }

        Console.WriteLine("Enter password"); 
        Console.WriteLine("Capital, lower, number");
        string ?GivenPW = "";
        while(Registration.CheckPasswordFormat(GivenPW!) == false){
            string pass = Console.ReadLine()!;
            GivenPW += pass + "";
        }
        Console.WriteLine(GivenPW);
        

        Console.Write("Retype the password\n");
        string ?RetypePW = Console.ReadLine();
        if(Registration.CheckPasswordSimilar(GivenPW!, RetypePW!) == true){
            Console.WriteLine("registratie succesvol");
        }else{
            Console.WriteLine("failed");
        }

        Console.WriteLine("Enter phone number");
        string PhoneNR = Console.ReadLine()!;

        Console.WriteLine("Admin: (true/false)");
        bool isAdmin = Convert.ToBoolean(Console.ReadLine()!);

        REG.CreateAccount(GivenEmail, GivenPW, PhoneNR!, isAdmin);
        ChangeAccMenu.DisplayChangeAccMenu();
    }
    }
}




