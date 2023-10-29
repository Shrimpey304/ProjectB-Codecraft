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
        try
        {
            tables = TableJsonUtil.ReadFromJson<Table>(fileName);
            if (tables is null)
            {
                throw new NullReferenceException();
            }
            return tables;
        }
        catch (NullReferenceException)
        {
            tables = PopulateTables();
            TableJsonUtil.UploadToJson<Table>(tables, fileName);
            return tables;
        }
    }

    public static List<Reservations>? LoadReservations(string fileName)
    {
        List<Reservations> reservations;
        try
        {
            reservations = TableJsonUtil.ReadFromJson<Reservations>(fileName)!;
            return reservations;
        }
        catch (Exception)
        {
            return null;
        }
    }

    private static List<Table> PopulateTables()
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