using System;

namespace Restaurant
{
    public class RemoveReservationA
    {
        public static void AdminRemResv()
        {
            DateOnly date;
            bool validDate = false;

            do
            {
                Console.WriteLine("Enter the reservation date (yyyy-MM-dd):");
                string inputDate = Console.ReadLine();
                
                if (DateOnly.TryParseExact(inputDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out date) && date >= DateOnly.FromDateTime(DateTime.Now))
                {
                    validDate = true;
                }
                else
                {
                    Console.WriteLine("Invalid date format or past date. Please enter a valid future date in yyyy-MM-dd format:");
                }

            } while (!validDate);

            Console.WriteLine("Enter the table ID for the reservation:");
            int tableId;
            while (!int.TryParse(Console.ReadLine(), out tableId))
            {
                Console.WriteLine("Invalid input for table ID. Please enter a valid table ID:");
            }

            TableManager tableManager = new TableManager();
            bool removed = tableManager.RemoveReservation(date, tableId);

            if (removed)
            {
                Console.WriteLine("Reservation removed successfully.");
            }
            else
            {
                Console.WriteLine("Reservation not found. Unable to remove.");
            }
        }
    }
}


