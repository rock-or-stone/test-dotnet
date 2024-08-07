using Microsoft.EntityFrameworkCore;
using System;

namespace App
{
    public class DataContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=sqldata,1433;InitialCatalog=OnlineShopDb;Database=OnlineShopDb;User=sa;Password=P@ssW0rd;TrustServerCertificate=true;");
        }
    }
}
