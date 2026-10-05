using kereparok.Models;
using Microsoft.EntityFrameworkCore;

namespace kereparok.DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Marka> markak {  get; set; }
        public DbSet<Kerekpar> kerekparok {  get; set; }
    }
}
