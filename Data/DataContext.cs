using budgetTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace budgetTracker.Data
{
    // Create a session with the database
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Outgoing> Outgoings { get; set; }
    }
}