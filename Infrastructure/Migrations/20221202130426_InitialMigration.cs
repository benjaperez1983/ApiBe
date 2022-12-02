using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PricesHeader",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricesHeader", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "PricesDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<int>(type: "int", nullable: true),
                    open = table.Column<double>(type: "float", nullable: true),
                    high = table.Column<double>(type: "float", nullable: true),
                    low = table.Column<double>(type: "float", nullable: true),
                    close = table.Column<double>(type: "float", nullable: true),
                    volume = table.Column<int>(type: "int", nullable: true),
                    adjclose = table.Column<double>(type: "float", nullable: true),
                    amount = table.Column<double>(type: "float", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data = table.Column<double>(type: "float", nullable: true),
                    PricesHeaderguid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricesDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PricesDetail_PricesHeader_PricesHeaderguid",
                        column: x => x.PricesHeaderguid,
                        principalTable: "PricesHeader",
                        principalColumn: "guid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PricesDetail_PricesHeaderguid",
                table: "PricesDetail",
                column: "PricesHeaderguid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PricesDetail");

            migrationBuilder.DropTable(
                name: "PricesHeader");
        }
    }
}
