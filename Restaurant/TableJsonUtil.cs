namespace Restaurant;

using Newtonsoft.Json;

public static class TableJsonUtil
{
    private static string fileName {get;set;} = @"C:dataStorage\Tables.json";
    private static readonly JsonSerializerSettings _options
        = new() { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented };
    public static void UploadToJson(List<Table> tables)
    {
        using var streamWriter = File.CreateText(fileName);
        using var jsonWriter = new JsonTextWriter(streamWriter);
        JsonSerializer.CreateDefault(_options).Serialize(jsonWriter, tables);
    }

    public static List<Table>? ReadFromJson()
    {
        try
        {
            StreamReader reader = new StreamReader(fileName);
            string jsonString = reader.ReadToEnd();
            reader.Close();
            List<Table> tables = JsonConvert.DeserializeObject<List<Table>>(jsonString)!;
            return tables;
        }
        catch (FileNotFoundException)
        {
            
            throw new Exception();
        }
    }
}