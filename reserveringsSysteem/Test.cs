public static class Test
{
    public static void Main()
    {
        // Dictionary<int,List<int>> res = new(){
        //     {1,new List<int>(){1,2,3}},
        //     {2,new List<int>(){2,4,3}},
        //     {3,new List<int>(){5,2,3}},
        // };
        // TableCsvUtil.UploadToCsv(res);
        // string[] strings = TableCsvUtil.ReadFromCsv();
        // foreach (var item in strings)
        // {
        //     System.Console.WriteLine(item);
        // }

        // List<Table> tables = TableJsonUtil.ReadFromJson();
        // foreach (var table in tables)
        // {
        //     System.Console.WriteLine($"{table.ID}|{table.Status}|{table.Type}");
        // }
        
        TableManager manager = new();
        System.Console.WriteLine(manager.ToString());
        

        
        
    }
}