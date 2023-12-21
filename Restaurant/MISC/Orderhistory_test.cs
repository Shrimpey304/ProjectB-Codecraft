namespace Restaurant;

public class OrderHistoryTest
{
    public List<Ingelogdmenu> windowInstance = new();

    public void DisplayOrderHistory(User user){
        ConsoleKeyInfo key;
        do{
            if (user.tableHistory.Count > 0){
                foreach (var reservation in user.tableHistory){
                    System.Console.WriteLine($"Resevation code: {reservation.Key} table number {reservation.Value.Position} sits {reservation.Value.Type}\n");
                }
            }else{
                System.Console.WriteLine("you have no current reservation.\n");
            }
            System.Console.WriteLine("PRESS ENTER TO GO BACK");
            key = Console.ReadKey(false);
        }while(key.Key != ConsoleKey.Enter);
        windowInstance[0].FromMR(windowInstance[0].logOut);        
    }
}
