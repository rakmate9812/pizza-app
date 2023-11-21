using API.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
            optionsBuilder.UseSqlServer(_config.GetConnectionString("Local"));
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<User> Users { get; set; }

    }
}