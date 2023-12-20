namespace Restaurant;
public static class TipCalculator
{
    private static decimal total;

    public static void AddTip()
    {
        Console.WriteLine("Would you like to add a tip?");
        string answer = Console.ReadLine();
        if (answer.ToLower() == "yes")
        {
            Console.WriteLine("Type the percentage of tip you would like to add: (for example: 5)");
            string amount = Console.ReadLine();
            int.TryParse(amount, out int percentage);
            if (percentage >= 0 && percentage <= 100)
            {
                decimal tipAmount = total * (percentage / 100);
                total += tipAmount;
                Console.WriteLine($"Tip of {percentage}% added succesfully");
            }
            else
            {
                Console.WriteLine("Percentage rate invalid. Enter a value between 0-100");
            }
        }
    }
}