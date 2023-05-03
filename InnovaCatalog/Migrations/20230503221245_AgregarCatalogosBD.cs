using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InnovaCatalog.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCatalogosBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CatalogItems",
                columns: new[] { "CatalogId", "AvailableStock", "CatalogBrandId", "CatalogTypeId", "Description", "MaxStockThreshold", "Name", "OnReorder", "PictureFileName", "PictureUri", "Price", "RestockThreshold" },
                values: new object[,]
                {
                    { 1, 5, 1, 1, "Descripcion del ejemplo", 10, "Ejemplo", true, "Ejemplo.Jpeg", "https://benitomango.blob.core.windows.net/mango/14.jpg", 99.99m, 3 },
                    { 2, 5, 1, 1, "Descripcion del ejemplo 2", 10, "Ejemplo2", true, "Ejemplo2.Jpeg", "https://benitomango.blob.core.windows.net/mango/12.jpg", 99.99m, 3 },
                    { 3, 5, 1, 1, "Descripcion del ejemplo 3", 10, "Ejemplo3", true, "Ejemplo3.Jpeg", "https://benitomango.blob.core.windows.net/mango/13.jpg", 99.99m, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "CatalogId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "CatalogId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "CatalogId",
                keyValue: 3);
        }
    }
}
