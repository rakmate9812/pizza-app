using API.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class AppDbContext : DbContext
    {
        public IConfiguration _config { get; set; }

        public AppDbContext(IConfiguration config)
        {
            _config = config; // dependency injection
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<FooBar> FooBars { get; set; }

    }
}
