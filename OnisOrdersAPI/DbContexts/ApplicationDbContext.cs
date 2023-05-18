using Microsoft.EntityFrameworkCore;
using OnisOrdersAPI.Models;

namespace OnisOrdersAPI.DbContexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .OwnsOne(o => o.ShipToAddress, a => {
                    a.WithOwner();

                    a.Property(a => a.ZipCode)
                    .HasMaxLength(18)
                    .IsRequired(); 
                    
                    a.Property(a => a.Street)
                    .HasMaxLength(180)
                    .IsRequired(); 
                    
                    a.Property(a => a.State)
                    .HasMaxLength(60); 

                    a.Property(a => a.Country)
                    .HasMaxLength(90)
                    .IsRequired();

                    a.Property(a => a.City)
                    .HasMaxLength(100)
                    .IsRequired();
                });
            modelBuilder.Entity<OrderItem>()
                .OwnsOne(o => o.ItemOrdered, a =>
                {
                    a.WithOwner();

                    a.Property(a => a.CatalogItemId)
                    .IsRequired();

                    a.Property(a => a.ProductName)
                    .HasMaxLength(50)
                    .IsRequired();

                    a.Property(a => a.PictureUri)
                    .HasMaxLength(50)
                    .IsRequired();
                });
        }
    }
}
