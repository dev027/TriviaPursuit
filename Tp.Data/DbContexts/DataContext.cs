using Microsoft.EntityFrameworkCore;

namespace Tp.Data.DbContexts
{
    public partial class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            const string connectionString = "data source=WRIGHT1\\SQLEXPRESS01;" +
                                            "initial catalog=TrivialPursuit;" +
                                            "Integrated Security=True";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}