namespace Restaurant;

public class TableManager 
{
    public List<Table> Tables {get;set;}
    public Dictionary<DateOnly, List<int>>? ReservedTable {get; private set;}

    public TableManager()
    {
        Tables = Table_init_.LoadFromJson()!;
        ReservedTable = Table_init_.LoadFromCsv();
    }

    public bool AddReservation(DateOnly date, int id)
    {
        if (ReservedTable is null)
        {
            List<int> tableIds = new() {id};
            ReservedTable = new()
            {
                { date, tableIds }
            };
            TableCsvUtil.UploadToCsv(ReservedTable);
            return true;
        }else if (CheckAvailability(date, id))
        {
            ReservedTable[date].Add(id);
            TableCsvUtil.UploadToCsv(ReservedTable);
            return true;
        }
        return false;
    }

    public bool RemoveReservation(DateOnly date, int id)
    {
        if (ReservedTable is null)
        {
            return false;
        }else if (CheckAvailability(date, id))
        {
            ReservedTable[date].Remove(id);
            return true;
        }
        return false;
    }

    public bool AddTable(int id, int type)
    {
        if (TableExists(id))
        {
            Tables.Add(new Table(id, type));
            TableJsonUtil.UploadToJson(Tables);
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
                UpdateResevations(id);
                return true;
            }
        }
        return false;
    }

    private void UpdateResevations(int id)
    {
        foreach (var item in ReservedTable.Values)
        {
            if (item.Contains(id))
            {
                item.Remove(id);
            }
        }
        TableCsvUtil.UploadToCsv(ReservedTable);
    }

    private bool TableExists(int id)
    {
        foreach (Table table in Tables)
        {
            if (table.ID == id)
            {
                return false;
            }
        }
        return true;
    }

    private bool CheckAvailability(DateOnly date, int id)
    {
        List<int> tableIds = ReservedTable[date];
        if (tableIds.Contains(id))
        {
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        return $"table amount {Tables.Count}, resvered dates count {ReservedTable.Count}";
    }
}
