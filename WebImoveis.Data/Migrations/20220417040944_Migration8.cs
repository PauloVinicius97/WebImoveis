using Microsoft.EntityFrameworkCore.Migrations;

namespace WebImoveis.Data.Migrations
{
    public partial class Migration8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "User",
                type: "CHAR(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(11)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "User",
                type: "CHAR(11)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(11)");

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "User",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
