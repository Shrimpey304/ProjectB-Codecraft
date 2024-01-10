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
    private List<string> timeSlots = new() {"12:00 pm", "2:00 pm", "4:00 pm", "6:00 pm", "8:00 pm"};
    private const int codeLength = 8;
    private const string timeFormate = "HH:mm tt";
    private const string tablesFileName = @"C:dataStorage\Tables.json";
    private const string reseravtionFileName = @"C:dataStorage\Reservations.json";
    private const string userFileName = @".\dataStorage\account.json";

    public TableManager(User? user)
    {
        User = user;
        Tables = Table_init_.LoadTables(tablesFileName)!;
        ReservedTable = Table_init_.LoadReservations(reseravtionFileName);
    }

    public TableManager(string tablefilename)
    {
        Tables = Table_init_.LoadTables(tablefilename)!;
        ReservedTable = new();
    }
    public List<Reservations>? AddReservation(DateOnly? date, string time, Table table, string filename = reseravtionFileName)
    {
        string ReservationCode;
        table.reservationDate = date;
        table.ReservationTime = time;
        if (ReservedTable.Any(item => item.ReservationDate == date))
        {
            Reservations reservations = ReservedTable.Find(item => item.ReservationDate == date)!;
            List<Table> tables = reservations.TimeSlotList[time];
            tables.Add(table);
            ReservationCode = GenerateCode();
            User.tableHistory[ReservationCode] = table;
            JsonUtil.UpdateSingleObject<User>(User, userFileName);
            JsonUtil.UpdateSingleObject<Reservations>(reservations, filename);
            return ReservedTable;
        }
        Reservations reservations1 = new(date);
        List<Table> tables1 = reservations1.TimeSlotList[time];
        tables1.Add(table);
        ReservedTable.Add(reservations1);
        ReservationCode = GenerateCode();
        
        User.tableHistory[ReservationCode] = table;
        JsonUtil.UpdateSingleObject<User>(User,userFileName);
        JsonUtil.UploadToJson<Reservations>(ReservedTable, filename);
        return ReservedTable;
    }

    public List<string> GetReservationCodes(){
        return User.tableHistory.Keys.ToList();
    }

    public void RemoveReservation(string reservationcode){
        Table table = User.tableHistory[reservationcode];
        Reservations reservation = GetReservation(table.reservationDate);
        List<Table> timeslot = reservation.TimeSlotList[table.ReservationTime];
        timeslot.Remove(table);
        User.tableHistory.Remove(reservationcode);
        JsonUtil.UpdateSingleObject<User>(User, userFileName);
        JsonUtil.UpdateSingleObject<Reservations>(reservation, reseravtionFileName);
    }

    public bool AddTable(int position, int type)
    {
        if (Tables.Exists(item => item.Position != position))
        {
            Tables.Add(new Table(position, type));
            JsonUtil.UploadToJson<Table>(Tables, tablesFileName);
            return true;
        }
        return false;
    }

    public bool RemoveTable(int position)
    {
        foreach (Table table in Tables)
        {
            if (table.Position == position)
            {
                Tables.Remove(table);
                JsonUtil.UploadToJson<Table>(Tables, tablesFileName);
                //UpdateResevations(table);
                return true;
            }
        }
        return false;
    }

    public IEnumerable<Table> GetAvailableTables(DateOnly? date, string timeslot)
    {
        List<Table> availableTables = new();
        IEnumerable<Reservations>? reservations = ReservedTable.Count > 0 ? ReservedTable.Where(item => item.ReservationDate == date) : null;
        if (reservations is not null && reservations.ToList().Count > 0){
            List<Table>? timeSlotTables = reservations?.ToList()[0].TimeSlotList[timeslot];
            return timeSlotTables is not null ? Tables.Except(timeSlotTables) : Tables;
        }
        return Tables;
    }

    public IEnumerable<string> GetAvailableTimeSlots(DateOnly? date)
    {
        List<string> AvailbaleTimeSlots = new();
        IEnumerable<Reservations>? reservations = ReservedTable.Where(item => item.ReservationDate == date);
        for (int i = 0; i < timeSlots.Count; i++)
        {
            //TimeOnly time = TimeOnly.ParseExact(timeSlots[i], timeFormate);
            int? timeSlot = reservations.ToList().Count > 0 ? reservations.ToList()[0].TimeSlotList[timeSlots[i]].Count : 0;
            if (reservations is null || timeSlot < 8)
            {
                AvailbaleTimeSlots.Add(timeSlots[i]);
            }
        }
        return AvailbaleTimeSlots;
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

    public DateOnly? ValidateDate(string datestring)
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

    public static IEnumerable<string> GetTablesString(List<Table> tables)
    {
        List<string> outTableString = new();
        foreach (Table table in tables)
        {
            string tableString = table.ToString();
            outTableString.Add(tableString);
        }
        return outTableString;
    }

    public static string GenerateCode()
    {
        Random random = new Random();
        int reservationCodeInt = random.Next(100000, 999999);
        string reservationCode = reservationCodeInt.ToString();
        return reservationCode;
    }
    public override string ToString()
    {
        return $"table amount {Tables.Count}, resvered dates count {ReservedTable.Count}";
    }

    public bool ChangeTableDetails(int currentPosition, int newPosition, int newType)
    {
        List<Table> tables = JsonUtil.ReadFromJson<Table>(tablesFileName);

        Table tableToChange = tables.FirstOrDefault(t => t.Position == currentPosition);

        if (tableToChange != null)
        {
            tableToChange.Position = newPosition;
            tableToChange.Type = newType;

            JsonUtil.UploadToJson<Table>(tables, tablesFileName);

            return true;
        }

        return false;
    }

    public Reservations? GetReservation(string date){
        List<Reservations> reservations = JsonUtil.ReadFromJson<Reservations>(reseravtionFileName);
        DateOnly? dateOnly = ValidateDate(date);
        Reservations? reservation = reservations.Find(item => item.ReservationDate == dateOnly);
        return reservation;
    }

    public Reservations? GetReservation(DateOnly? date){
        List<Reservations> reservations = JsonUtil.ReadFromJson<Reservations>(reseravtionFileName);
        Reservations? reservation = reservations.Find(item => item.ReservationDate == date);
        return reservation is null ? throw new Exception("obj not found") : reservation;
    }

    public List<Table> UpdateResevedTable(int currenttableinfo, int newtableinfo, List<Table> timeslot, bool seating=false){
        Table table = timeslot.Find(item => item.Position == currenttableinfo);
        int tableIndex = timeslot.IndexOf(table);
        if (seating){
            timeslot[tableIndex].Type = newtableinfo;
            return timeslot;
        }
        timeslot[tableIndex].Position = newtableinfo;
        return timeslot;
    }
}
