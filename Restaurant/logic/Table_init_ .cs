namespace Restaurant;
/*
discription:
    The Table_init_ class is a static class that gets called everytime
    TableManager gets initialized. Table_init_ loads stored data into TableManager to be used.
uses:
    *this class should only be called in TableManager.(atleast for now)*
*/
public static class Table_init_
{
    public static List<Table> LoadTables(string fileName)
    {
        List<Table> tables;
        tables = JsonUtil.ReadFromJson<Table>(fileName);
        if (tables is null || tables.Count == 0)
        {
            tables = PopulateTables();
            JsonUtil.UploadToJson<Table>(tables, fileName);
            return tables;
        }
        return tables;
    
    }

    public static List<Reservations>? LoadReservations(string fileName)
    {
        List<Reservations> reservations;
        try
        {
            reservations = JsonUtil.ReadFromJson<Reservations>(fileName)!;
            return reservations;
        }
        catch (Exception)
        {
            return null;
        }
    }

    internal static List<Table> PopulateTables()
    {
        List<Table> tables = new(){
            new Table(1, 2),
            new Table(2, 2),
            new Table(3, 8),
            new Table(4, 4),
            new Table(5, 4)
        };
        return tables;
    }
}