using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WebImoveis.Data.Migrations
{
    public partial class ReduzindoEscopo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentProperty");

            migrationBuilder.DropTable(
                name: "Rent");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Property_AddressId",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Property",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Property_AddressId",
                table: "Property",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Property_AddressId",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Property");

            migrationBuilder.AddColumn<short>(
                name: "Number",
                table: "Address",
                type: "SMALLINT",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    Cpf = table.Column<string>(type: "CHAR(11)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Rent",
                columns: table => new
                {
                    RentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RenterId = table.Column<int>(type: "int", nullable: false),
                    RentingDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    RentingExpiration = table.Column<DateTime>(type: "DATE", nullable: false),
                    RentingPrice = table.Column<decimal>(type: "DECIMAL(20,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rent", x => x.RentId);
                    table.ForeignKey(
                        name: "FK_Rent_User_RenterId",
                        column: x => x.RenterId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentProperty",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    RentId = table.Column<int>(type: "int", nullable: false),
                    RentPropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentProperty", x => new { x.PropertyId, x.RentId });
                    table.ForeignKey(
                        name: "FK_RentProperty_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentProperty_Rent_RentId",
                        column: x => x.RentId,
                        principalTable: "Rent",
                        principalColumn: "RentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Property_AddressId",
                table: "Property",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rent_RenterId",
                table: "Rent",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_RentProperty_RentId",
                table: "RentProperty",
                column: "RentId");
        }
    }
}
