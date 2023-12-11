using System.Globalization;

namespace Restaurant;

public static class MakeReservation 
{
    private static TableManager tableManager = new();
    public static IEnumerable<IFoodItems> foodItems;
    public static void Display()
    {
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
            MainMenu.DisplayMainMenu
            //Ingelogdmenu.DisplayIngelogdMenu
        };
        int selectedOption = DisplayUtil.Display(options);
        actions[selectedOption]();
    }

    public static void MakeReserve()
    {
        
        
        int? partySize = null;
        DateOnly? reservationDate = null;
        while (partySize is null)
        {
            Console.Clear();
            System.Console.WriteLine("enter your party size");
            string partySizeString = Console.ReadLine()!;
            partySize = TableManager.ValidatePartySize(partySizeString);
        }

        while (reservationDate is null)
        {
            Console.Clear();
            System.Console.WriteLine("enter your reservation date\n(yyyy-mm-dd)");
            string dateSrting = Console.ReadLine();
            reservationDate = TableManager.ValidateDate(dateSrting);
        }

        if (!tableManager.AddReservation(reservationDate, partySize))
        {
            System.Console.WriteLine("Reservation unavailable. Please try again.");
            MakeReserve();
            
        }else
        {
            MenuCard.Display();
            if (foodItems is not null)
            {
                List<string> options = new(){"Go to checkout", "Go back to reseravtion menu"};
                int selectedOption = DisplayUtil.Display(options);
                if (selectedOption == 0)
                {
                    CheckOut(partySize, reservationDate, foodItems);
                }
            }else
            {
                Display();
            }
        }
    }

    private static void CheckOut(int? partySize, DateOnly? date, IEnumerable<IFoodItems> order)
    {
        ConsoleKeyInfo key;
        do
        {
            Console.Clear();
            System.Console.WriteLine($"Your reservation is set on {date}\nwith a party size of {partySize} people.\nYour order:");
            foreach (var item in order)
            {
                System.Console.WriteLine(item.GetString());
            }
            System.Console.WriteLine($"Your Total: {FoodManager.GetTotal(order)}\nPress ENTER to go back to home menu.");
            key = Console.ReadKey(false);
        } while (key.Key != ConsoleKey.Enter);
        MainMenu.DisplayMainMenu();
    }

    private static void RemoveReserve()
    {
        System.Console.WriteLine("On what date is your reservation");
        DateOnly date = (DateOnly)ValidateDate()!;
        System.Console.WriteLine("what is the table id of your reservation");
        int tableId = Convert.ToInt32(Console.ReadLine());
        if (tableManager.RemoveReservation(date, tableId))
        {
            System.Console.WriteLine("press ENTER to go back");
            if (Console.ReadKey(false).Key == ConsoleKey.Enter)
            {
                Display();
            }
        }else
        {
            System.Console.WriteLine("Reservation doesn't exist. Please try again.");
            RemoveReserve();
        }
    }

    private static void CheckAvailablity()
    {
        Console.Clear();
        System.Console.WriteLine("what date do you want to check");
        DateOnly date1 = (DateOnly)ValidateDate()!;
        List<string> tables = tableManager.CheckDateAvailability(date1);
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

    private static DateOnly? ValidateDate()
    {
        
        while (true)
        {
            System.Console.WriteLine("enter your reservation date\n(yyyy-mm-dd)");
            string dateSrting = Console.ReadLine();
            if (DateOnly.TryParseExact(dateSrting, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None ,out DateOnly dt))
            {
                return DateOnly.Parse(dateSrting);
            }
            System.Console.WriteLine("Invalide Date...\nPlease re-enter your reservation date.");
        }
        return null;
    }
}


