namespace Restaurant;

public class AdminReservations
{
    private static string reservationPath = @".\dataStorage\Reservations.json";
        
    public static void FormatReservations()
    {
        List<Reservations> reservations = JsonUtil.ReadFromJson<Reservations>(reservationPath);

        Console.WriteLine(" ");
        Console.WriteLine("Reservations:");
        Console.WriteLine("---------------------------");

        foreach (var reservation in reservations)
        {
            foreach (var timeSlot in reservation.TimeSlotList)
            {
                foreach (var slot in timeSlot.Value)
                {
                    
                    Console.WriteLine($"Reservation date: {slot.reservationDate}");
                    Console.WriteLine($"Reservation Time: {slot.ReservationTime}");
                    Console.WriteLine($"Position: {slot.Position}");
                    Console.WriteLine($"Type: {slot.Type}");
                    Console.WriteLine("---------------------------");
                }
            }
        }
    }

    public static void SeeReservationsA(User user)
    {
        FormatReservations();
        Console.WriteLine("Press enter to go back to change reservation menu");
        Console.ReadLine();
        AdminMenu.DisplayChangeResvMenu(user); 
    }




    /// <summary>
    /// make resv change in makeresrevation later
    /// </summary>
    public static void RemovReservationA()
    {
        Console.WriteLine("test...");
    }

    public static void ChangeReservationA()
    {
        Console.WriteLine("test...");
    }

}