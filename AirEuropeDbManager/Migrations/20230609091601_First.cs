using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirEuropeDbManager.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    AircraftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.AircraftId);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.AirportId);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.AppUserId);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AircraftId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seats_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "AircraftId");
                });

            migrationBuilder.CreateTable(
                name: "AirRoutes",
                columns: table => new
                {
                    AirRouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureAirportId = table.Column<int>(type: "int", nullable: false),
                    ArrivalAirportId = table.Column<int>(type: "int", nullable: false),
                    AircraftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirRoutes", x => x.AirRouteId);
                    table.ForeignKey(
                        name: "FK_AirRoutes_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "AircraftId");
                    table.ForeignKey(
                        name: "FK_AirRoutes_Airports_ArrivalAirportId",
                        column: x => x.ArrivalAirportId,
                        principalTable: "Airports",
                        principalColumn: "AirportId");
                    table.ForeignKey(
                        name: "FK_AirRoutes_Airports_DepartureAirportId",
                        column: x => x.DepartureAirportId,
                        principalTable: "Airports",
                        principalColumn: "AirportId");
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Departure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AirRouteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_AirRoutes_AirRouteId",
                        column: x => x.AirRouteId,
                        principalTable: "AirRoutes",
                        principalColumn: "AirRouteId");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId");
                    table.ForeignKey(
                        name: "FK_Reservations_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId");
                });

            migrationBuilder.CreateTable(
                name: "ReservedSeats",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservedSeats", x => new { x.SeatId, x.ReservationId });
                    table.ForeignKey(
                        name: "FK_ReservedSeats_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId");
                    table.ForeignKey(
                        name: "FK_ReservedSeats_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "SeatId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirRoutes_AircraftId",
                table: "AirRoutes",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_AirRoutes_ArrivalAirportId",
                table: "AirRoutes",
                column: "ArrivalAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_AirRoutes_DepartureAirportId",
                table: "AirRoutes",
                column: "DepartureAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirRouteId",
                table: "Flights",
                column: "AirRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AppUserId",
                table: "Reservations",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FlightId",
                table: "Reservations",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedSeats_ReservationId",
                table: "ReservedSeats",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_AircraftId",
                table: "Seats",
                column: "AircraftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservedSeats");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "AirRoutes");

            migrationBuilder.DropTable(
                name: "Aircrafts");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
