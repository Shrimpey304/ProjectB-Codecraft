namespace Restaurant;

public class Reservations : IEquatable<Reservations>
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

    public bool Equals(Reservations reservations)
    {
        if (reservations is null)
        {
            return false;
        }
        return this.ReservationDate == reservations.ReservationDate;
    }

    public override bool Equals(object obj) => Equals(obj as Reservations);
    public override int GetHashCode() => (ReservationDate).GetHashCode();

    public override string ToString()
    {
        return $"Date:{ReservationDate} Tables:{TimeSlotList.Count}";
    }

}
