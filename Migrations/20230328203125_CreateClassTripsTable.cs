using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Train_D.Migrations
{
    /// <inheritdoc />
    public partial class CreateClassTripsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassTrips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    TrainId = table.Column<int>(type: "int", nullable: false),
                    ClassPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTrips", x => new { x.TrainId, x.TripId, x.ClassName });
                    table.ForeignKey(
                        name: "FK_ClassTrips_Classes_TrainId_ClassName",
                        columns: x => new { x.TrainId, x.ClassName },
                        principalTable: "Classes",
                        principalColumns: new[] { "TrainId", "ClassName" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassTrips_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassTrips_TrainId_ClassName",
                table: "ClassTrips",
                columns: new[] { "TrainId", "ClassName" });

            migrationBuilder.CreateIndex(
                name: "IX_ClassTrips_TripId",
                table: "ClassTrips",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassTrips");
        }
    }
}
