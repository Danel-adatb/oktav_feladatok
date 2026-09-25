using Microsoft.EntityFrameworkCore;
using viragbolt.Models;

namespace viragbolt.Config
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("SERVER=localhost;DATABASE=viragbolt;Uid=root;PWD=rootpassword");
        }
    }
}
