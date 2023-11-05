namespace Restaurant;

public class Reservations
{
    public DateOnly ReservationDate {get;set;}
    public List<Table>? TablesList {get;set;}

    public Reservations(DateOnly reservation)
    {
        ReservationDate = reservation;
        //Tables = new();
    }

    public override string ToString()
    {
        return $"Date:{ReservationDate} Tables:{TablesList.Count}";
    }
}
