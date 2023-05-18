using Microsoft.EntityFrameworkCore;

namespace OnisCatalog.Orders.DbContexts
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //public DbSet<Order> Order { get; set; }
        //public DbSet<OrderItem> OrderItem { get; set; }
        //public DbSet<Address> Address { get; set; }
        //public DbSet<CatalogItemOrdered> CatalogItemOrdered { get; set; }
        //public DbSet<Basket> Baskey { get; set; }
        //public DbSet<BasketItem> BasketItem { get; set; }
    }
}
