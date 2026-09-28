using konyvtar.Models;
using Microsoft.EntityFrameworkCore;

namespace konyvtar.Config
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
