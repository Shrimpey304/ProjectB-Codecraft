namespace Restaurant;
public static class TipCalculator
{
    private static decimal total;

    public static decimal AddTip(decimal total)
    {
        Console.WriteLine("Would you like to add a tip?");
        string answer = Console.ReadLine();
        if (answer.ToLower() == "yes")
        {
            return CalculateTip(total);
        }
        else
        {
            Console.WriteLine("Enjoy the rest of your day/evening!");
            return total;
        }
    }

    public static decimal CalculateTip(decimal total)
    {
        Console.WriteLine("Enter the percentage of tip you would like to add: (for example: 5)");
        string amount = Console.ReadLine();
        if (int.TryParse(amount, out int percentage) && percentage >= 0 && percentage <= 100)
            {
                decimal tipAmount = total * (percentage / 100m);
                decimal newTotal = total + tipAmount;
                Console.WriteLine($"\nTip of {percentage}% added succesfully");
                Thread.Sleep(2000);
                return newTotal;
            }
        else
            {
                Console.WriteLine("Percentage rate invalid. Enter a value between 0-100");
                Thread.Sleep(2000);
                return total;
            }
    }
}