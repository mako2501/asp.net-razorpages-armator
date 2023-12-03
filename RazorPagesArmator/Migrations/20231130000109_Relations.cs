using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesArmator.Migrations
{
    /// <inheritdoc />
    public partial class Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PortID",
                table: "Ship",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ship_PortID",
                table: "Ship",
                column: "PortID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ship_Port_PortID",
                table: "Ship",
                column: "PortID",
                principalTable: "Port",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ship_Port_PortID",
                table: "Ship");

            migrationBuilder.DropIndex(
                name: "IX_Ship_PortID",
                table: "Ship");

            migrationBuilder.DropColumn(
                name: "PortID",
                table: "Ship");
        }
    }
}
