using Microsoft.EntityFrameworkCore.Migrations;

namespace WebImoveis.Data.Migrations
{
    public partial class Migration9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AddressType",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AddressType",
                table: "Address",
                type: "VARCHAR(100)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
