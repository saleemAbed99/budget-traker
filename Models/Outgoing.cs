namespace budgetTracker.Models
{
    public class Outgoing
    {
        public int Id { get; set; }
        public double Value { get; set; } = 0.0;
        public string  Name { get; set; }
        public Budget Budget { get; set; }
    }
}