namespace Restaurant;

public class Table
{
    public int ID {get;set;}
    public bool Status {get;set;} = true;
    public int Type {get;set;}
    public int TableNumber { get; set; }
    public int AmountOfSpaceAtTable { get; set; }

    public Table(int id, int type)
    {
        ID = id;
        Type = type;
    }

    public override string ToString()
    {
        return $"Table id:{ID}, Status:{Status}, Table type:{Type}";
    }

    
}