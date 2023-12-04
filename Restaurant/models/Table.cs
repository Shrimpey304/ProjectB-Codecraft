namespace Restaurant;

public class Table : IEquatable<Table>
{
    public int Position {get;set;}
    public bool Status {get;set;} = true;
    public int Type {get;set;}
    public TimeOnly? ReservationTime {get;set;}

    public Table(int position, int type, TimeOnly? reservationtime = null)
    {
        Position = position;
        Type = type;
        ReservationTime = reservationtime;
    }

    public bool Equals(Table table)
    {
        if (table is null)
        {
            return false;
        }
        return this.Position == table.Position && this.Type == table.Type;
    }

    public override bool Equals(object obj) => Equals(obj as Table);
    public override int GetHashCode() => (Position, Type).GetHashCode();

    public override string ToString()
    {
        return $"Table Position:{Position}, Status:{Status}, Table type:{Type}";
    }
}