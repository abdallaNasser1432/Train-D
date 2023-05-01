using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Train_D.Migrations
{
    /// <inheritdoc />
    public partial class editeLangAndLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Stations",
                type: "DECIMAL(16,14)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(12,9)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Stations",
                type: "DECIMAL(16,14)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(12,9)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Stations",
                type: "DECIMAL(12,9)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(16,14)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Stations",
                type: "DECIMAL(12,9)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(16,14)",
                oldNullable: true);
        }
    }
}
