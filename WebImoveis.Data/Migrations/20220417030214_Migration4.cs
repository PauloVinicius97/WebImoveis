using Microsoft.EntityFrameworkCore.Migrations;

namespace WebImoveis.Data.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "User",
                type: "CHAR(11)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(11)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "User",
                type: "CHAR(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(11)",
                oldNullable: true);
        }
    }
}
