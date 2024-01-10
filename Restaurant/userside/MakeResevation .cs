using System.Globalization;

namespace Restaurant;

public class MakeReservation : MasterDisplay
{
    public User? User;

    private TableManager tableManager;

    public static IEnumerable<IFoodItems> foodItems;

    public List<Ingelogdmenu> windowInstance = new();
    public RegisterProcess register = new();
    public Table? table;
    public DateOnly? reservationDate;

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
            "Go Back"
        };
        int selectedOption = DisplayUtil.Display(options);  
        switch (selectedOption)
        {
            case 0:
                tableManager.User = User;
                MakeReserve();
                break;
            case 1:
                if(User is null){throw new Exception("user is null by remove..3");}
                tableManager.User = User;
                RemoveReserve();
                break;
            case 2:
                CheckAvailablity();
                break;
            case 3:
                if(User is null){throw new Exception("user is null by when going back..1");}
                windowInstance[0].user = User;
                windowInstance[0].DisplayIngelogdMenu();
                break;
        }
    }

    public void MakeReserve()
    {
        
        //tableManager.User = User;
        //int? partySize = null;
        // DateOnly? reservationDate = null;
        string? selectedTime = null;
        // Table? table = null;
        if (User == null)
        {
            Console.WriteLine("You need to be registered to make a reservation.");
            Thread.Sleep(2000);
            register.RegisterMail();
        }
        else
        {
            while (reservationDate is null || selectedTime is null || table is null)
        {
            Console.Clear();
            Header.DisplayHeader();
            System.Console.WriteLine("enter your reservation date\n(yyyy-mm-dd)");
            string dateSrting = Console.ReadLine();
            reservationDate = tableManager.ValidateDate(dateSrting);
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
            menuCard.CheckOut = this;
            //menuCard.windowInstanceStack.Push(MakeReserve);
            menuCard.FromMain(true);
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
            System.Console.WriteLine($"Your reservation is set on {date}\n\nwith a party size of {table.Type} people.\n\nYour order:");
            foreach (var item in order)
            {
                System.Console.WriteLine(item.GetString());
                Console.WriteLine("--------------------");
            }
            System.Console.WriteLine($"Your Total (with tip): {totalWithTip:F2}\n\nPress ENTER to go back to home menu.");
            key = Console.ReadKey(false);
        } while (key.Key != ConsoleKey.Enter);
        if(ingelogdmenu.user is null){throw new Exception("user is null when checkout..4");}
        ingelogdmenu.DisplayIngelogdMenu();
    }

    private void RemoveReserve(){
        List<string> reserevationCode = tableManager.GetReservationCodes();
        reserevationCode.Add("Go Back");
        int selectedOption = DisplayUtil.Display(reserevationCode);
        if (selectedOption == reserevationCode.Count -1){
            Display();
        }else{
            tableManager.RemoveReservation(reserevationCode[selectedOption]);
            System.Console.WriteLine("Reservation deleted");
            Thread.Sleep(2500);
            Display();
        }
    }

    private void CheckAvailablity()
    {
        Console.Clear();
        System.Console.WriteLine("what date do you want to check");
        string datestring = Console.ReadLine();
        DateOnly date1 = (DateOnly)tableManager.ValidateDate(datestring)!;
        IEnumerable<string> tables = tableManager.GetAvailableTimeSlots(date1);
        foreach (string item in tables)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine("press ENTER to go back");
        if (Console.ReadKey(false).Key == ConsoleKey.Enter)
        {
            Display();
        }
    }

}
 