using InnovaCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace InnovaCatalog.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ):base(options)
        {
            
        }

        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogBrand>().HasData(new CatalogBrand
            {
                CatalogBrandId = 1,
                CatalogBrandName = "CatalogBrandName1"

            });
            modelBuilder.Entity<CatalogType>().HasData(new CatalogType
            {
                CatalogTypeId = 1,
                CatalogTypeName = "CatalogTypeName1"

            });
            modelBuilder.Entity<CatalogItem>().HasData(new CatalogItem
            {
                CatalogId = 1,
                Name = "Ejemplo",
                Description = "Descripcion del ejemplo",
                Price = 99.99m,
                PictureFileName = "Ejemplo.Jpeg",
                PictureUri = "https://benitomango.blob.core.windows.net/mango/14.jpg",
                CatalogTypeId = 1,
                CatalogBrandId = 1,
                AvailableStock = 5,
                RestockThreshold = 3,
                MaxStockThreshold = 10,
                OnReorder = true

            });
            modelBuilder.Entity<CatalogItem>().HasData(new CatalogItem
            {
                CatalogId = 2,
                Name = "Ejemplo2",
                Description = "Descripcion del ejemplo 2",
                Price = 99.99m,
                PictureFileName = "Ejemplo2.Jpeg",
                PictureUri = "https://benitomango.blob.core.windows.net/mango/12.jpg",
                CatalogTypeId = 1,
                CatalogBrandId = 1,
                AvailableStock = 5,
                RestockThreshold = 3,
                MaxStockThreshold = 10,
                OnReorder = true

            });
            modelBuilder.Entity<CatalogItem>().HasData(new CatalogItem
            {
                CatalogId = 3,
                Name = "Ejemplo3",
                Description = "Descripcion del ejemplo 3",
                Price = 99.99m,
                PictureFileName = "Ejemplo3.Jpeg",
                PictureUri = "https://benitomango.blob.core.windows.net/mango/13.jpg",
                CatalogTypeId = 1,
                CatalogBrandId = 1,
                AvailableStock = 5,
                RestockThreshold = 3,
                MaxStockThreshold = 10,
                OnReorder = true

            });
            modelBuilder.Entity<CatalogItem>().HasData(new CatalogItem
            {
                CatalogId = 4,
                Name = "Ejemplo3",
                Description = "Descripcion del ejemplo 3",
                Price = 99.99m,
                PictureFileName = "Ejemplo3.Jpeg",
                PictureUri = "https://benitomango.blob.core.windows.net/mango/13.jpg",
                CatalogTypeId = 1,
                CatalogBrandId = 1,
                AvailableStock = 5,
                RestockThreshold = 3,
                MaxStockThreshold = 10,
                OnReorder = true

            });
        }


    }
}
