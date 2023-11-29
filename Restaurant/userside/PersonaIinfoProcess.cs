namespace Restaurant;

public class PersonalInfoTest
{

    public static string ?mail;
    public static string ?pw;
    public static string ?phone;

    public static void DisplayPersonalInfo()
    {
        Console.WriteLine($"Email: {mail}");
        Console.WriteLine($"Password: {pw}");
        Console.WriteLine($"Phone number: {phone}");
    }

    public static void DisplayPIMenu()
    {
        List<string> options = new(){
            "Back",
            "Change email",
            "Change password",
            "Change Phone number"
        };
        List<Action> actions = new(){
            Ingelogdmenu.DisplayIngelogdMenu,
            // MakeReservation.Display,
            // LoginProcess.LoginProcessMailView,
            // RegisterProcess.RegisterProcessView,
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void showUserData(){
        User acc = Login.getUserData(Login.LoggedinUser);
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