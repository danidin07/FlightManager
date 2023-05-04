using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class NewFlightBrandAfterFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Brund",
                table: "Flights",
                newName: "Brand");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Flights",
                newName: "Brund");
        }
    }
}
