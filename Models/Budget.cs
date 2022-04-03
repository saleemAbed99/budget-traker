using System.Collections.Generic;

namespace budgetTracker.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public double MonthlyIncome { get; set; }
        public double Total { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Outgoing> Outgoings { get; set; }
    }
}