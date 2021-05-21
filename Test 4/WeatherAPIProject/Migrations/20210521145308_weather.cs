using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherAPIProject.Migrations
{
    public partial class weather : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    City = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HighTemperature = table.Column<float>(type: "real", nullable: false),
                    LowTemperature = table.Column<float>(type: "real", nullable: false),
                    Forcast = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.City);
                });

            migrationBuilder.InsertData(
                table: "Weathers",
                columns: new[] { "City", "Date", "Forcast", "HighTemperature", "LowTemperature" },
                values: new object[] { "chennai", new DateTime(2021, 5, 21, 20, 23, 8, 36, DateTimeKind.Local).AddTicks(3967), "sunny", 32f, 17f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weathers");
        }
    }
}
