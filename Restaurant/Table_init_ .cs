namespace Restaurant;

public static class Table_init_
{
    public static List<Table>? LoadFromJson()
    {
        List<Table> tables;
        try
        {
            tables = TableJsonUtil.ReadFromJson();
            return tables;
        }
        catch (Exception)
        {
            tables = PopulateTables();
            TableJsonUtil.UploadToJson(tables);
            return tables;
        }
    }

    public static Dictionary<DateOnly,List<int>>? LoadFromCsv()
    {
        Dictionary<DateOnly,List<int>> reservations = new();
        try
        {
            
            string[] reservationsCsv = TableCsvUtil.ReadFromCsv();
            foreach (var item in reservationsCsv)
            {
                string[] splitCsv = item.Split(";");
                string[] stringInts = splitCsv[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
                DateOnly date = DateOnly.Parse(splitCsv[0]);
                List<int> tableIds = Array.ConvertAll(stringInts, int.Parse).ToList();
                reservations.Add(date, tableIds);
            }
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