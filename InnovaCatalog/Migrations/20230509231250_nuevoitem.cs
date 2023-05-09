using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnovaCatalog.Migrations
{
    /// <inheritdoc />
    public partial class nuevoitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CatalogItems",
                columns: new[] { "CatalogId", "AvailableStock", "CatalogBrandId", "CatalogTypeId", "Description", "MaxStockThreshold", "Name", "OnReorder", "PictureFileName", "PictureUri", "Price", "RestockThreshold" },
                values: new object[] { 8, 5, 1, 1, "Descripcion del ejemplo 3", 10, "Ejemplo3", true, "Ejemplo3.Jpeg", "https://benitomango.blob.core.windows.net/mango/13.jpg", 99.99m, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "CatalogId",
                keyValue: 4);
        }
    }
}
