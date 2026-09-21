using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Config.DB
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Manufacturer> manufacturers { get; set; }
        public DbSet<Tool> tools { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("SERVER=localhost;DATABASE=vizsga;Uid=root;PWD=rootpassword");
        }
    }
}
