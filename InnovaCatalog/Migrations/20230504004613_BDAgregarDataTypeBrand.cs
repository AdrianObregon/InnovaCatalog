using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnovaCatalog.Migrations
{
    /// <inheritdoc />
    public partial class BDAgregarDataTypeBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CatalogBrands",
                columns: new[] { "CatalogBrandId", "CatalogBrandName" },
                values: new object[] { 1, "CatalogBrandName1" });

            migrationBuilder.InsertData(
                table: "CatalogTypes",
                columns: new[] { "CatalogTypeId", "CatalogTypeName" },
                values: new object[] { 1, "CatalogTypeName1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CatalogBrands",
                keyColumn: "CatalogBrandId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CatalogTypes",
                keyColumn: "CatalogTypeId",
                keyValue: 1);
        }
    }
}
