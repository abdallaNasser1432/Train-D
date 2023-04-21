using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Train_D.Migrations
{
    /// <inheritdoc />
    public partial class HandleLatitudeAndLongitudeDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Stations",
                type: "DECIMAL(4,12)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(12,9)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Stations",
                type: "DECIMAL(4,12)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(12,9)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Stations",
                type: "DECIMAL(12,9)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(4,12)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Stations",
                type: "DECIMAL(12,9)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(4,12)");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => new { x.UserId, x.Id });
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
