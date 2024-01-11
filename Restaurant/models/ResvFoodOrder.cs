public class ResvFoodOrder
{
    public int Position { get; set; }
    public DateOnly? ReservationDate { get; set; }
    public int Type { get; set; }
    public string ReservationTime { get; set; }
    public List<string> OrderedFood { get; set; }
}
