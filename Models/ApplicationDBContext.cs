using DataBaseManegmentSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Add_Database_Model.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>  options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>()
                .Property(x => x.DateTime)
                .HasDefaultValueSql("GETDATE()");
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderItem>  OrderItems { get; set; }

    }
}
