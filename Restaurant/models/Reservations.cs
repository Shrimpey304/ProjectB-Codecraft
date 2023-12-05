namespace Restaurant;

public class Reservations
{
    public DateOnly? ReservationDate {get;set;}
    public Dictionary<string , List<Table>> TimeSlotList {get;set;}

    public Reservations(DateOnly? reservation)
    {
        ReservationDate = reservation;
        TimeSlotList = new(){
            {"12:00 pm",new()},
            {"2:00 pm",new()},
            {"4:00 pm",new()},
            {"6:00 pm",new()},
            {"8:00 pm",new()}
        };
    }

    public override string ToString()
    {
        return $"Date:{ReservationDate} Tables:{TimeSlotList.Count}";
    }
}
