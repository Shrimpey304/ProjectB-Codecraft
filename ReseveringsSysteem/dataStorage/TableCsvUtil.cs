public static class TableCsvUtil
{
    private static string fileName {get;set;} = @"C:dataStorage\Reservations.csv";
    public static void UploadToCsv(Dictionary<DateOnly,List<int>> reservations)
    {
        StreamWriter writer = new(fileName);
        foreach (var item in reservations)
        {
            string tempId = "";
            foreach (var id in item.Value)
            {
                tempId += id.ToString();
                tempId += ",";
            }
            writer.WriteLine($"{item.Key};{tempId}");
        }
        writer.Close();
    }

    public static string[]? ReadFromCsv() // => ["dt;int,int..", "dt;int,..."]
    {
        StreamReader reader = new(fileName);
        string contents = reader.ReadToEnd();
        if (contents == string.Empty)
        {
            reader.Close();
            throw new Exception($"{fileName} is empty");
        }
        reader.Close();
        string[] contentsLine = contents.Split("/n", StringSplitOptions.RemoveEmptyEntries);
        return contentsLine;
    }
}