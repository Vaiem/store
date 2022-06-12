using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class ShippedOder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Shipped",
                table: "OdersDB",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shipped",
                table: "OdersDB");
        }
    }
}
