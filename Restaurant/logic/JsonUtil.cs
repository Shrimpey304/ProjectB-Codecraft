namespace Restaurant;

using Newtonsoft.Json;
/*
discription:
    this static class reads and writes data to and from json files.
uses:
--writing to a json file-->void UploadToJson<T>(list<T>,filename)
    *T can be any class out models *list<T> can be a list any class out models
    *filename = @"C:dataStorage\filename"
--reading from json--> List<T> readFromJson<T>(filename)
    *filename = @"C:dataStorage\filname"
    =>returns a list<T> where T is the given class 
*/
public static class JsonUtil
{
    private static readonly JsonSerializerSettings _options
        = new() { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented };
    public static void UploadToJson<T>(List<T> ToUpload, string fileName) where T : class
    {
        using var streamWriter = File.CreateText(fileName);
        using var jsonWriter = new JsonTextWriter(streamWriter);
        JsonSerializer.CreateDefault(_options).Serialize(jsonWriter, ToUpload);
    }

    public static void UpdateSingleObject<T>(T toWrite, string fileName) where T : class{
        List<T> objList = ReadFromJson<T>(fileName);
        if (toWrite != null && objList != null) //added null checking
        {
            int index = objList.FindIndex(item => item.GetHashCode() == toWrite.GetHashCode());
            if (index != -1){
                objList[index] = toWrite;
            }else{
                objList.Add(toWrite);
            }
            UploadToJson(objList, fileName);
        }
    }

    public static List<T>? ReadFromJson<T>(string fileName) where T : class
    {
        try
        {
            StreamReader reader = new StreamReader(fileName);
            string jsonString = reader.ReadToEnd();
            reader.Close();
            List<T> outList = JsonConvert.DeserializeObject<List<T>>(jsonString)!;
            return outList;
        }
        catch (Exception)
        {
            return null;
        }
    }
}