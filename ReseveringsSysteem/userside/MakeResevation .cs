public class MakeResevation 
{
    private TableManager tableManager = new();
    
    public void Display()
    {
        System.Console.WriteLine("[1] Make reservation.\n[2] Remove reservation\n[3] Check availability.");
        int inp = int.Parse(Console.ReadLine()!);
        switch (inp)
        {
            
            default:
                Display();
                break;
        }
    }

    private void MakeReservation()
    {
        System.Console.WriteLine("enter your party size");
        int partySize = int.Parse(Console.ReadLine()!);
        while (partySize < 2 || partySize > 8)
        {
            System.Console.WriteLine("invalide party size\nplease re-enter your party size");
            partySize = int.Parse(Console.ReadLine()!);
        }

        System.Console.WriteLine("enter your reservation date");
        
    }
}