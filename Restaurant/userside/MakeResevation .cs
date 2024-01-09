using System.Globalization;

namespace Restaurant;

public class MakeReservation : MasterDisplay
{
    public User? User;

    private TableManager tableManager;

    public static IEnumerable<IFoodItems> foodItems;

    public List<Ingelogdmenu> windowInstance = new();
    public RegisterProcess register = new();

    public MakeReservation(User? user){
        User = user;
        tableManager = new(User);
    }

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
            windowInstance[0].DisplayIngelogdMenu
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
        if (User == null)
        {
            Console.WriteLine("You need to be registered to make a reservation.");
            register.RegisterMail();
        }
        else
        {
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
        }

        List<Reservations>? ReservationCode = tableManager.AddReservation(reservationDate, selectedTime, table);

        if (ReservationCode is null)
        {
            System.Console.WriteLine("Reservation unavailable. Please try again.");
            MakeReserve();
            
        }else
        {
            
            MenuCard menuCard = new();
            menuCard.windowInstanceStack.Push(MakeReserve);
            menuCard.FromMain(true);
            if (foodItems is not null)
            {
                List<string> options = new(){"Go to checkout", "Go back to reservation menu"};
                int selectedOption2 = DisplayUtil.Display(options);
                if (selectedOption2 == 0)
                {
                    menuCard.AddWine(table, reservationDate, foodItems);
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

    public void CheckOut(Table table, DateOnly? date, IEnumerable<IFoodItems> order)
    {
        Ingelogdmenu ingelogdmenu = new();
        ingelogdmenu.user = User;
        ConsoleKeyInfo key;
        decimal totalWithTip = TipCalculator.AddTip(FoodManager.GetTotal(order));
        do
        {
            Console.Clear();
            System.Console.WriteLine($"Your reservation is set on {date}\nwith a party size of {table.Type} people.\nYour order:");
            foreach (var item in order)
            {
                System.Console.WriteLine(item.GetString());
            }
            System.Console.WriteLine($"Your Total with tip: {totalWithTip:F2}\nPress ENTER to go back to home menu.");
            key = Console.ReadKey(false);
        } while (key.Key != ConsoleKey.Enter);
        ingelogdmenu.DisplayIngelogdMenu();
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

}
