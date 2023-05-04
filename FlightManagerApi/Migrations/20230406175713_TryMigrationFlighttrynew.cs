using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class TryMigrationFlighttrynew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logger_Flights_FlightId",
                table: "Logger");

            migrationBuilder.DropForeignKey(
                name: "FK_Logger_Legs_LegId",
                table: "Logger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logger",
                table: "Logger");

            migrationBuilder.RenameTable(
                name: "Logger",
                newName: "Loggers");

            migrationBuilder.RenameIndex(
                name: "IX_Logger_LegId",
                table: "Loggers",
                newName: "IX_Loggers_LegId");

            migrationBuilder.RenameIndex(
                name: "IX_Logger_FlightId",
                table: "Loggers",
                newName: "IX_Loggers_FlightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loggers",
                table: "Loggers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Loggers_Flights_FlightId",
                table: "Loggers",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loggers_Legs_LegId",
                table: "Loggers",
                column: "LegId",
                principalTable: "Legs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loggers_Flights_FlightId",
                table: "Loggers");

            migrationBuilder.DropForeignKey(
                name: "FK_Loggers_Legs_LegId",
                table: "Loggers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loggers",
                table: "Loggers");

            migrationBuilder.RenameTable(
                name: "Loggers",
                newName: "Logger");

            migrationBuilder.RenameIndex(
                name: "IX_Loggers_LegId",
                table: "Logger",
                newName: "IX_Logger_LegId");

            migrationBuilder.RenameIndex(
                name: "IX_Loggers_FlightId",
                table: "Logger",
                newName: "IX_Logger_FlightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logger",
                table: "Logger",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Logger_Flights_FlightId",
                table: "Logger",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logger_Legs_LegId",
                table: "Logger",
                column: "LegId",
                principalTable: "Legs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
