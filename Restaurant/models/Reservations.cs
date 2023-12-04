namespace Restaurant;

public class Reservations
{
    public DateOnly? ReservationDate {get;set;}
    public Dictionary<string , List<Table>> TimeSlotList {get;set;}

    public Reservations(DateOnly? reservation)
    {
        ReservationDate = reservation;
        TimeSlotList = new(){
            {"12pm",new()},
            {"2pm",new()},
            {"4pm",new()},
            {"6pm",new()},
            {"8pm",new()}
        };
    }

    public override string ToString()
    {
        return $"Date:{ReservationDate} Tables:{TimeSlotList.Count}";
    }
}
