namespace Restaurant;
/*
Discription:
    TableManager class is a static class that gets formated data from MakeReservation.
    This class is used to manage the tables, add/remove tables and reservations.
    Only with the admin cam add/remove tables
uses:
--adding(making) reservation-->bool AddReservation(date, id)
    *date = DateOnly *id = int 
    =>returns true if reservation is succesfull else false if reservation failed

--removing reservation-->bool RemoveReservation(date, id)
    *date = DateOnly *id = int 
    =>returns true if removing reservation is succesfull else false if removing reservation failed

--adding table-->bool AddTable(id, type) **this methode is only to be used by the admin**
    *id = int *type = int
    =>returns true if adding table is succesfull else false if adding table failed

--removing table-->bool RemoveTable(id) **this methode is only to be used by the admin**
    *id = int
    =>returns true if removing table is succesfull else false if removing table failed

--checking availability-->list<string> CheckAvailiblity(date)
    *date = DateOnly
    =>returns a list of the availabel tables info
*/
public class TableManager 
{
    public List<Table> Tables {get;set;}
    private List<Reservations> _reseravtions;
    public List<Reservations>? ReservedTable {
        get => _reseravtions;
        set => _reseravtions = value is null ? new() : value;}
    public User? User {get;set;}
    private const string tablesFileName = @"C:dataStorage\Tables.json";
    private const string reseravtionFileName = @"C:dataStorage\Reservations.json";

    private const int MaxSeatingAmount = 48;

    public Dictionary<string, Table> TableDictionary { get; private set; }



    public TableManager()
    {
        Tables = Table_init_.LoadTables(tablesFileName)!;
        ReservedTable = Table_init_.LoadReservations(reseravtionFileName);
    }
    public TableManager(string tablefilename)
    {
        Tables = Table_init_.LoadTables(tablefilename)!;
        ReservedTable = new();
    }

    public bool AddReservation(DateOnly? date, int? id, string filename = reseravtionFileName)
    {
        if (ReservedTable.Count == 0 || !ReservedTable.Exists(item => item.ReservationDate == date))
        {
            Reservations reservations = new(date);
            Table table = Tables.Find(item => item.ID == id)!;
            reservations.TablesList = new()
            {
                table
            };
            ReservedTable.Add(reservations);
            JsonUtil.UploadToJson<Reservations>(ReservedTable, filename);
            return true;
            // u need to fix this cus it dont work like it should...
        } else if (ReservedTable.Exists(item => item.ReservationDate == date) && !ReservedTable.Exists(item => item.TablesList.Exists( Id => Id.ID == id)))
        {
            Reservations reservations = ReservedTable.Find(item => item.ReservationDate == date)!;
            Table table = Tables.Find(item => item.ID == id)!;
            reservations.TablesList.Add(table);
            JsonUtil.UploadToJson<Reservations>(ReservedTable, filename);
            return true;
        }
        return false;
    }

    public bool RemoveReservation(DateOnly date, int id, string filename = reseravtionFileName)
    {
        if (ReservedTable.Exists(item => item.ReservationDate == date) && ReservedTable.Exists(item => item.TablesList.Exists(Id => Id.ID == id)))
        {
            Reservations reservations = ReservedTable.Find(item => item.ReservationDate == date)!;
            Table table = reservations.TablesList.Find(item => item.ID == id)!;
            reservations.TablesList.Remove(table);
            JsonUtil.UploadToJson<Reservations>(ReservedTable, filename);
            return true;
        }
        return false;
    }

    public bool AddTable(int id, int type)
    {
        if (Tables.Exists(item => item.ID != id))
        {
            Tables.Add(new Table(id, type));
            JsonUtil.UploadToJson<Table>(Tables, tablesFileName);
            return true;
        }
        return false;
    }

    public bool RemoveTable(int id)
    {
        foreach (Table table in Tables)
        {
            if (table.ID == id)
            {
                Tables.Remove(table);
                JsonUtil.UploadToJson<Table>(Tables, tablesFileName);
                UpdateResevations(table);
                return true;
            }
        }
        return false;
    }

    public List<string> CheckDateAvailability(DateOnly date)
    {
        List<string> availability = new();
        if (ReservedTable.Exists(item => item.ReservationDate == date))
        {
            Reservations reservations = ReservedTable.Find(item => item.ReservationDate == date);
            foreach (Table table in Tables)
            {
                if (!reservations.TablesList.Contains(table))
                {
                    availability.Add(table.ToString());
                }
            }
            return availability;
        }
        availability.Add("there are no tables currently available.");
        return availability;
    }

    public static int? ValidatePartySize(string partysize)
    {
        try
        {
            int partySize = int.Parse(partysize);
            if (partySize > 2 && partySize < 8)
            {
                return partySize;
            }
            return null;
        }
        catch (System.Exception)
        {
            
            return null;
        }
        
    }

    public static DateOnly? ValidateDate(string datestring)
    {
        string[] dateFormate = {"yyyy-MM-dd"};
        try
        {
            DateOnly date = DateOnly.ParseExact(datestring, dateFormate);
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            if (date >= today)
            {
                return date;
            }
            return null;
        }
        catch (System.Exception)
        {
            return null;
        }
    }

    private void UpdateResevations(Table table)
    {
        foreach (var item in ReservedTable)
        {
            if (item.TablesList.Contains(table))
            {
                item.TablesList.Remove(table);
            }
        }
        JsonUtil.UploadToJson<Reservations>(ReservedTable, reseravtionFileName);
    }
    public override string ToString()
    {
        return $"table amount {Tables.Count}, resvered dates count {ReservedTable.Count}";
    }
}
