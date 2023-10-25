using System.Globalization;

namespace Restaurant;

public static class MakeReservation 
{
    private static TableManager tableManager = new();
    
    public static void Display()
    {
        System.Console.WriteLine("[1] Make reservation.\n[2] Remove reservation\n[3] Check availability.");
        int inp = int.Parse(Console.ReadLine()!);
        switch (inp)
        {
            case 1:
                System.Console.WriteLine("enter your party size");
                int partySize = ValidatePartySize();
                System.Console.WriteLine("enter your reservation date\n(yyyy-mm-dd)");
                DateOnly reservationDate = (DateOnly)ValidateDate()!;
                MenuChoice.ChooseMenu();
                tableManager.AddReservation(reservationDate, partySize);
                break;
            case 2:
                System.Console.WriteLine("On what date is your reservation");
                DateOnly date = (DateOnly)ValidateDate()!;
                System.Console.WriteLine("what is the table id of your reservation");
                int tableId = Convert.ToInt32(Console.ReadLine());
                tableManager.RemoveReservation(date, tableId);
                break;
            case 3:
                System.Console.WriteLine("what date do you want to check");
                DateOnly date1 = (DateOnly)ValidateDate()!;
                List<int> tables = tableManager.CheckDateAvailability(date1);
                foreach (int item in tables)
                {
                    System.Console.WriteLine(item);
                }
                break;
        }
    }

    private static int ValidatePartySize()
    {
        int partySize = int.Parse(Console.ReadLine()!);
        while (partySize < 2 || partySize > 8)
        {
            System.Console.WriteLine("Invalide party size...\nPlease re-enter your party size");
            partySize = int.Parse(Console.ReadLine()!);
        }
        return partySize;
    }

    private static DateOnly? ValidateDate()
    {
        
        while (true)
        {
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
