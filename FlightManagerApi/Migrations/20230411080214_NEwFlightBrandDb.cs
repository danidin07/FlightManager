using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class NEwFlightBrandDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brund",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brund",
                table: "Flights");
        }
    }
}
