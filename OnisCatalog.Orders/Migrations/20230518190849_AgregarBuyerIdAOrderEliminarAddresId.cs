using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnisCatalog.Orders.Migrations
{
    /// <inheritdoc />
    public partial class AgregarBuyerIdAOrderEliminarAddresId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Address_AddressId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Order",
                newName: "ShipToAddressAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_AddressId",
                table: "Order",
                newName: "IX_Order_ShipToAddressAddressId");

            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Address_ShipToAddressAddressId",
                table: "Order",
                column: "ShipToAddressAddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Address_ShipToAddressAddressId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "ShipToAddressAddressId",
                table: "Order",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ShipToAddressAddressId",
                table: "Order",
                newName: "IX_Order_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Address_AddressId",
                table: "Order",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
