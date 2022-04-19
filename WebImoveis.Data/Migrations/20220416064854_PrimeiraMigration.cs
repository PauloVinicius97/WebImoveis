using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WebImoveis.Data.Migrations
{
    public partial class PrimeiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "CHAR(8)", nullable: false),
                    Number = table.Column<short>(type: "SMALLINT", nullable: false),
                    Street = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Neighborhood = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Town = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Uf = table.Column<string>(type: "CHAR(2)", nullable: false),
                    AddressType = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Cpf = table.Column<string>(type: "CHAR(11)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    UserType = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(120)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(20,2)", nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    PropertyType = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Property_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rent",
                columns: table => new
                {
                    RentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RenterId = table.Column<int>(nullable: false),
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
                    RentId = table.Column<int>(nullable: false),
                    PropertyId = table.Column<int>(nullable: false),
                    RentPropertyId = table.Column<int>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentProperty");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "Rent");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
