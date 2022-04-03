using budgetTracker.Dtos.Budget;

namespace budgetTracker.Dtos.Outgoing
{
    public class AddOutgoingDto
    {
        public double Value { get; set; } = 0.0;
        public string  Name { get; set; }
        public GetBudgetDto Budget { get; set; }
    }
}