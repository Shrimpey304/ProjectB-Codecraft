namespace Restaurant;

public class PersonalInfoTest
{

    public static string ?mail;
    public static string ?pw;
    public static string ?phone;
    public List<Ingelogdmenu> windowInstance = new();

    public void DisplayPersonalInfo(User user)
    {
        Console.Clear();
        Header.DisplayHeader();

        Console.WriteLine($"\u001B[35m" +"Your user data:\n\n");

        ConsoleKeyInfo key;
        do{
            Console.WriteLine($">  Email: {user.Email}\n");
            Console.WriteLine($">  Password: {user.Password}\n");
            Console.WriteLine($">  Phone number: {user.PhoneNumber}\n");
            System.Console.WriteLine($"\x1B[4m" +"\nPRESS ENTER TO GO BACK" + $"\x1B[0m");
            key = Console.ReadKey(false);
        }while (key.Key != ConsoleKey.Enter);
        windowInstance[0].FromMR(windowInstance[0].logOut);
    }

    // public void DisplayPIMenu()
    // {
    //     List<string> options = new(){
    //         "Back"
    //     };
    //     List<Action> actions = new(){
    //         ingelogdmenu.DisplayIngelogdMenu,
    //     };
    //     int selectedOption = DisplayUtil.Display(options);
    //     actions[selectedOption]();
    // }

    public void showUserData(){
        Login login = new();
        User acc = login.getUserData(Login.LoggedinUser);
        if(acc != null){
            mail = acc.Email!;
            pw = acc.Password!;
            phone = acc.PhoneNumber!;
            for(int i = 0; i < pw.Length; i++){
                Console.Write("*");
            }
        }
    }

}