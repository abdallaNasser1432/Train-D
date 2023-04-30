using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Train_D.Migrations
{
    /// <inheritdoc />
    public partial class cahngeDeleteBehaviorOnTripsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassTrips_Trips_TripId",
                table: "ClassTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Trips_TripId",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTrips_Trips_TripId",
                table: "ClassTrips",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "TripId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Trips_TripId",
                table: "Tickets",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "TripId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassTrips_Trips_TripId",
                table: "ClassTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Trips_TripId",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTrips_Trips_TripId",
                table: "ClassTrips",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "TripId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Trips_TripId",
                table: "Tickets",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "TripId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
