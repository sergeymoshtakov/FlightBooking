using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightBooking.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddAirportCoordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirportCoordinates",
                columns: table => new
                {
                    AirportCoordinatesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AirportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportCoordinates", x => x.AirportCoordinatesId);
                    table.ForeignKey(
                        name: "FK_AirportCoordinates_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirportCoordinates_AirportId",
                table: "AirportCoordinates",
                column: "AirportId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirportCoordinates");
        }
    }
}
