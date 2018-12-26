using Microsoft.EntityFrameworkCore;
using Tp.Models.DbEntities;

namespace Tp.Migration.Data.DbContexts
{
    public partial class MigrationContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<PlayerCategory> PlayerCategories { get; set; }
    }
}