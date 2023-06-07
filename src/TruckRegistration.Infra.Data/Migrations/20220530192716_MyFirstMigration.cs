using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TruckRegistration.Infra.Data.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Truck",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    ManufactureYear = table.Column<int>(type: "int", nullable: false),
                    ModelYear = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Renavam = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Color = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truck", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Truck");
        }
    }
}
