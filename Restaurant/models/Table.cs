namespace Restaurant;

public class Table : IEquatable<Table>
{
    public int Position {get;set;}
    public DateOnly? reservationDate {get;set;}
    public int Type {get;set;}
    public TimeOnly? ReservationTime {get;set;}

    public Table(int position, int type)
    {
        Position = position;
        Type = type;
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
        return $"Table Position:{Position}, Status:, Table type:{Type}";
    }
}