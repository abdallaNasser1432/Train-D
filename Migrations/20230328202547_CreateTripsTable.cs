using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Train_D.Migrations
{
    /// <inheritdoc />
    public partial class CreateTripsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripName = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "[StartStation]+'-'+[EndStaion]"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ArrivalTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    StartStation = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    EndStaion = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    TrainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                    table.ForeignKey(
                        name: "FK_Trips_Stations_EndStaion",
                        column: x => x.EndStaion,
                        principalTable: "Stations",
                        principalColumn: "StationName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trips_Stations_StartStation",
                        column: x => x.StartStation,
                        principalTable: "Stations",
                        principalColumn: "StationName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trips_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "TrainId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_EndStaion",
                table: "Trips",
                column: "EndStaion");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_StartStation",
                table: "Trips",
                column: "StartStation");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TrainId",
                table: "Trips",
                column: "TrainId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
