using filmek.Models;
using Microsoft.EntityFrameworkCore;

namespace filmek.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Filmek> filmek { get; set; }
        public DbSet<Studiok> studiok { get; set; }
    }
}
