namespace Restaurant;

public class Table
{
    public int ID {get;set;}
    public bool Status {get;set;} = true;
    public int Type {get;set;}

    public Table(int id, int type)
    {
        ID = id;
        Type = type;
    }
}