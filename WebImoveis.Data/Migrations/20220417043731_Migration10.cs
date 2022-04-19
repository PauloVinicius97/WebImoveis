using Microsoft.EntityFrameworkCore.Migrations;

namespace WebImoveis.Data.Migrations
{
    public partial class Migration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyType",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "AddressType",
                table: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PropertyType",
                table: "Property",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AddressType",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
