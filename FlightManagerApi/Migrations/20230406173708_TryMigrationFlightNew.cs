using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlightManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class TryMigrationFlightNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Legs",
                columns: new[] { "Id", "CurrentLeg", "FlightId", "IsChangeStatus", "Next", "Number", "WaitTime" },
                values: new object[,]
                {
                    { 1, 1, null, false, 2, 1, 3 },
                    { 2, 2, null, false, 4, 2, 3 },
                    { 3, 4, null, false, 8, 3, 3 },
                    { 4, 8, null, false, 272, 4, 3 },
                    { 5, 16, null, false, 96, 5, 3 },
                    { 6, 32, null, false, 128, 6, 3 },
                    { 7, 64, null, false, 128, 7, 3 },
                    { 8, 128, null, false, 8, 8, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Legs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Legs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Legs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Legs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Legs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Legs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Legs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Legs",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
