using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Train_D.Migrations
{
    /// <inheritdoc />
    public partial class CreateTrainAndClassesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    TrainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.TrainId);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassName = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    TrainId = table.Column<int>(type: "int", nullable: false),
                    Coaches = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeatsCoach = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => new { x.TrainId, x.ClassName });
                    table.ForeignKey(
                        name: "FK_Classes_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "TrainId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Trains");
        }
    }
}
