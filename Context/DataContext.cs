using Microsoft.EntityFrameworkCore;
using System;

namespace App
{
    public class DataContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string not found.");
            }
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
