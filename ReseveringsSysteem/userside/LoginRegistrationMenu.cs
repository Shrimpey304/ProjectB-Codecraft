namespace LogReg{
public class LoginRegistrationMenu{
    
    public static void Menu(){

        Console.WriteLine("  _                 _         __  __                  ");
        Console.WriteLine(" | |               (_)       |  \\/  |                 ");
        Console.WriteLine(" | |     ___   __ _ _ _ __   | \\  / | ___ _ __  _   _ ");
        Console.WriteLine(" | |    / _ \\ / _` | | '_ \\  | |\\/| |/ _ \\ '_ \\| | | |");
        Console.WriteLine(" | |___| (_) | (_| | | | | | | |  | |  __/ | | | |_| |");
        Console.WriteLine(" |______\\___/ \\__, |_|_| |_| |_|  |_|\\___|_| |_|\\__,_|");
        Console.WriteLine("               __/ |                                  ");
        Console.WriteLine("              |___/                                   ");

        Console.WriteLine("1: Register\n2: Login\n");
        string ?choise = Console.ReadLine();
        switch(choise){
            case "1":
                RegisterProcess.RegisterProcessText();
            break;
            case "2":
                LoginProcess.LoginProcessText();
            break;
            default:
                Console.WriteLine("not a valid input");
                Thread.Sleep(2000);
                Menu();
            break;
        }

    }

}
}