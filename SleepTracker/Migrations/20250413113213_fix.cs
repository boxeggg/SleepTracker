using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SleepTracker.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SleepSession",
                table: "SleepSession");

            migrationBuilder.RenameTable(
                name: "SleepSession",
                newName: "SleepSessions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SleepSessions",
                table: "SleepSessions",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SleepSessions",
                table: "SleepSessions");

            migrationBuilder.RenameTable(
                name: "SleepSessions",
                newName: "SleepSession");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SleepSession",
                table: "SleepSession",
                column: "Id");
        }
    }
}
