using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesArmator.Migrations
{
    /// <inheritdoc />
    public partial class New_DataAnnotations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Length",
                table: "Ship",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,0)");

            migrationBuilder.AlterColumn<int>(
                name: "Beam",
                table: "Ship",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Length",
                table: "Ship",
                type: "decimal(3,0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Beam",
                table: "Ship",
                type: "decimal(3,0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
