using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SleepTracker.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SleepSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SleepTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    WakeUpTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    SleepQuality = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepSession", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SleepSession",
                columns: new[] { "Id", "Date", "Notes", "SleepQuality", "SleepTime", "WakeUpTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dobry sen, bez pobudek", 4, new TimeSpan(0, 23, 0, 0, 0), new TimeSpan(0, 6, 30, 0, 0) },
                    { 2, new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zbyt późno spać, zmęczenie rano", 2, new TimeSpan(0, 0, 30, 0, 0), new TimeSpan(0, 7, 45, 0, 0) },
                    { 3, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Najlepszy sen w tygodniu!", 5, new TimeSpan(0, 22, 45, 0, 0), new TimeSpan(0, 6, 0, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SleepSession");
        }
    }
}
