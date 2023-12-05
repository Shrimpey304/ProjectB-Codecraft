namespace Restaurant;

public class PersonalInfoTest
{

    public static string ?mail;
    public static string ?pw;
    public static string ?phone;
    Ingelogdmenu ingelogdmenu = new();

    public void DisplayPersonalInfo()
    {
        Console.WriteLine($"Email: {mail}");
        Console.WriteLine($"Password: {pw}");
        Console.WriteLine($"Phone number: {phone}");
    }

    public void DisplayPIMenu()
    {
        List<string> options = new(){
            "Back"
        };
        List<Action> actions = new(){
            ingelogdmenu.DisplayIngelogdMenu,
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public void showUserData(){
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