namespace Restaurant;

public class AdminEditResv
{
    public User User;
    private static string reservationsPath = @".\dataStorage\Reservations.json";
    private static List<Table> tables = JsonUtil.ReadFromJson<Table>(reservationsPath)!;
    private static List<Reservations> reservations = JsonUtil.ReadFromJson<Reservations>(reservationsPath)!;
//     private (Reservations reservation, Table table) GetReservationByDetails()
//     {
//         TableManager manager = new(User);
//         Console.WriteLine("Enter the reservation date (YYYY-MM-DD):");
//         string resvDateString = Console.ReadLine();
//         Reservations reservations =  manager.GetReservation(resvDateString);

//         FormatReservationsByDate(reservations, resvDate);
//         Console.WriteLine("Enter time slot ('12:00 pm'):");
//         string timeSlot = Console.ReadLine();

//         Console.WriteLine("Enter the table position:");
//         if (!int.TryParse(Console.ReadLine(), out int position))
//         {
//             Console.WriteLine("Invalid input");
//             return (null, null);
//         }

//         Reservations reservationToChange = reservations.FirstOrDefault(reservation =>
//             reservation.ReservationDate == resvDate && reservation.TimeSlotList.ContainsKey(timeSlot));

//         if (reservationToChange == null)
//         {
//             Console.WriteLine("Reservation not found.");
//             return (null, null);
//         }

//         Table tableToChange = reservationToChange.TimeSlotList[timeSlot].FirstOrDefault(table => table.Position == position);

//         if (tableToChange == null)
//         {
//             Console.WriteLine("Table not found for the given position.");
//             return (null, null);
//         }

//         return (reservationToChange, tableToChange);
        

//         return (null, null);
//     }

    

//     public static void ChangeTableTypeR()
//     {
//         (Reservations reservationToChange, Table tableToChange) = GetReservationByDetails();

//         if (tableToChange != null)
//         {
//             Console.WriteLine("Enter the new type for the table:");
//             int newType;
//             if (!int.TryParse(Console.ReadLine(), out newType))
//             {
//                 Console.WriteLine("Invalid input.");
//                 return;
//             }

//             tableToChange.Type = newType;

//             // Find the specific table within the reservation and update its type
//             foreach (var reservation in reservations)
//             {
//                 if (reservation == reservationToChange)
//                 {
//                     foreach (var timeSlotTables in reservation.TimeSlotList.Values)
//                     {
//                         foreach (var table in timeSlotTables)
//                         {
//                             if (table.Position == tableToChange.Position)
//                             {
//                                 table.Type = newType;
//                                 break;
//                             }
//                         }
//                     }
//                     break;
//                 }
//             }

//             // Upload only reservations back to the JSON
//             JsonUtil.UploadToJson(reservations, reservationsPath);
//             Console.WriteLine("Type changed successfully.");
//             AdminMenu.DisplayChangeResvMenu();
//         }
//     }
    public static void FormatReservationsByDate(User user)
    {
        Console.WriteLine("Enter the reservation date (YYYY-MM-DD):");
        string resvDateString = Console.ReadLine();

        if (DateOnly.TryParse(resvDateString, out DateOnly resvDate))
        {
            Console.WriteLine(" ");
            Console.WriteLine($"Reservations for {resvDate}");
            Console.WriteLine("--------------");

            bool reservationsFound = false;

            foreach (var reservation in reservations)
            {
                foreach (var timeSlot in reservation.TimeSlotList)
                {
                    foreach (var slot in timeSlot.Value)
                    {
                        if (DateOnly.TryParse(slot.reservationDate.ToString(), out DateOnly slotDate) && slotDate == resvDate)
                        {
                            Console.WriteLine($"Reservation date: {slot.reservationDate}");
                            Console.WriteLine($"Reservation Time: {slot.ReservationTime}");
                            Console.WriteLine($"Position: {slot.Position}");
                            Console.WriteLine($"Type: {slot.Type}");
                            Console.WriteLine("--------------");
                        }
                    }
                }
            }
            if (!reservationsFound)
        {
            Console.WriteLine("No reservations found for the entered date.");
        }
        }
        else
        {
            Console.WriteLine("Invalid date format.");
        }
    }


    public static void SeeReservationsDateA(User user)
    {
        FormatReservationsByDate(user);
        Console.WriteLine("Press enter to go back to change reservation menu");
        Console.ReadLine();
        AdminMenu.DisplayChangeResvMenu(user); 
    }
}
 
