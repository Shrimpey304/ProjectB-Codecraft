using System.Globalization;

namespace Restaurant;

public class MakeReservation : MasterDisplay
{
private TableManager tableManager = new();

    public static IEnumerable<IFoodItems> foodItems;

    public List<Ingelogdmenu> windowInstance = new();
    
    public User? User;

    public MakeReservation(User? user=null) => User = user;

    public void Display()
    {
        // windowInstanceStack.Clear();
        // windowInstanceStack.Push(MainMenu.DisplayMainMenu);
        List<string> options = new(){
            "Make Reservation",
            "Remove Reservation",
            "Check Availablity",
            "press ENTER or click ESC to go back"
        };
        List<Action> actions = new(){
            MakeReserve,
            RemoveReserve,
            CheckAvailablity,
            GoBack
        };
        int selectedOption = DisplayUtil.Display(options);    
        actions[selectedOption]();
    }

    public void MakeReserve()
    {
        
        //tableManager.User = User;
        //int? partySize = null;
        DateOnly? reservationDate = null;
        string? selectedTime = null;
        Table? table = null;

        while (reservationDate is null || selectedTime is null || table is null)
        {
            Console.Clear();
            System.Console.WriteLine("enter your reservation date\n(yyyy-mm-dd)");
            string dateSrting = Console.ReadLine();
            reservationDate = TableManager.ValidateDate(dateSrting);
            if (reservationDate is null) {continue;}
            IEnumerable<string> timeSlots = tableManager.GetAvailableTimeSlots(reservationDate);
            if (timeSlots.Count() == 0) {continue;}
            int selectedOption = DisplayUtil.Display(timeSlots.ToList());
            selectedTime = timeSlots.ToList()[selectedOption];
            IEnumerable<Table> tables = tableManager.GetAvailableTables(reservationDate, selectedTime);
            if (tables.Count() == 0) {continue;}
            IEnumerable<string> tableString = TableManager.GetTablesString(tables.ToList());
            int selectedOption1 = DisplayUtil.Display(tableString.ToList());
            table = tables.ToList()[selectedOption1];
        }

        string ReservationCode = tableManager.AddReservation(reservationDate, selectedTime, table);

        if (ReservationCode is null)
        {
            System.Console.WriteLine("Reservation unavailable. Please try again.");
            MakeReserve();
            
        }else
        {
            
            MenuCard menuCard = new();
            menuCard.windowInstanceStack.Push(MakeReserve);
            menuCard.Display();
            if (foodItems is not null)
            {
                List<string> options = new(){"Go to checkout", "Go back to reseravtion menu"};
                int selectedOption2 = DisplayUtil.Display(options);
                if (selectedOption2 == 0)
                {
                    CheckOut(table, reservationDate, foodItems, ReservationCode);
                }else
                {
                    Display();
                }
            }else
            {
                Display();
            }
        }
    }

    private void CheckOut(Table table, DateOnly? date, IEnumerable<IFoodItems> order, string reservationCode)
    {
        Ingelogdmenu ingelogdmenu = new();
        ConsoleKeyInfo key;
        do
        {
            Console.Clear();
            System.Console.WriteLine($"Your reservation is set on {date}\nwith a party size of {table.Type} people.\nYour order:");
            foreach (var item in order)
            {
                System.Console.WriteLine(item.GetString());
            }
            System.Console.WriteLine($"Your Total: {FoodManager.GetTotal(order)}\nPress ENTER to go back to home menu.");
            key = Console.ReadKey(false);
        } while (key.Key != ConsoleKey.Enter);
        User.tableHistory[reservationCode] = table;
        GoBack();
    }

    private void RemoveReserve()
    {
        // System.Console.WriteLine("On what date is your reservation");
        // DateOnly date = (DateOnly)ValidateDate()!;
        // System.Console.WriteLine("what is the table id of your reservation");
        // int tableId = Convert.ToInt32(Console.ReadLine());
        // if (tableManager.RemoveReservation(date, tableId))
        // {
        //     System.Console.WriteLine("press ENTER to go back");
        //     if (Console.ReadKey(false).Key == ConsoleKey.Enter)
        //     {
        //         Display();
        //     }
        // }else
        // {
        //     System.Console.WriteLine("Reservation doesn't exist. Please try again.");
        //     RemoveReserve();
        // }
    }

    private static void CheckAvailablity()
    {
        // Console.Clear();
        // System.Console.WriteLine("what date do you want to check");
        // DateOnly date1 = (DateOnly)ValidateDate()!;
        // List<string> tables = tableManager.CheckDateAvailability(date1);
        // foreach (string item in tables)
        // {
        //     System.Console.WriteLine(item);
        // }
        // System.Console.WriteLine("press ENTER to go back");
        // if (Console.ReadKey(false).Key == ConsoleKey.Enter)
        // {
        //     Display();
        // }
    }

    private void GoBack(){
        windowInstance[0].FromMR(windowInstance[0].logOut);
    }
}
