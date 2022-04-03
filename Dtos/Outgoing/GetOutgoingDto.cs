namespace budgetTracker.Dtos.Outgoing
{
    public class GetOutgoingDto
    {
        public int Id { get; set; }
        public double Value { get; set; } = 0.0;
        public string  Name { get; set; }
    }
}