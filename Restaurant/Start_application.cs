namespace Restaurant;

class Program
{
    static void Main(string[] args)
    {
        // List<Reservations> reservations1 = new();
        // DateOnly date = DateOnly.Parse(Console.ReadLine());
        // Reservations reservations = new(date);
        // reservations.Tables = new(){
        //     new Table(1, 2),
        //     new Table(2, 2),
        //     new Table(3, 8),
        //     new Table(4, 4),
        //     new Table(5, 4)
        // };
        // reservations1.Add(reservations);
        // TableJsonUtil.UploadToJson(reservations1, );


        // List<Reservations>? reservations = TableJsonUtil.ReadFromJson<Reservations>(@"C:dataStorage\Tables.json");
        // foreach (var item in reservations[0].Tables)
        // {
        //     System.Console.WriteLine(item.ToString());
        // }


        TableManager manager = new();
        //DateOnly date = DateOnly.Parse(Console.ReadLine());
        //manager.AddReservation(date, 1);
        System.Console.WriteLine($"{manager}");
    }
}

