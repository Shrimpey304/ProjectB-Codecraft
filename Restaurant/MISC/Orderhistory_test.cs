namespace Restaurant;

public class OrderHistoryTest
{
    public List<Ingelogdmenu> windowInstance = new();

    public void DisplayOrderHistory(User user){
        Console.Clear();
        Header.DisplayHeader();
        ConsoleKeyInfo key;
        do{
            if (user.tableHistory.Count > 0){
                foreach (var reservation in user.tableHistory){
                    System.Console.WriteLine($"Resevation code: {reservation.Key}\ntable number: {reservation.Value.Position}\nseats: {reservation.Value.Type}\nDate {reservation.Value.reservationDate}\n");
                    Console.WriteLine("----------------------------");
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
