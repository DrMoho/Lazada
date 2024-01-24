using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lazada.Migrations
{
    /// <inheritdoc />
    public partial class Migrate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percent",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UnPrice",
                table: "Products",
                newName: "OrPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrPrice",
                table: "Products",
                newName: "UnPrice");

            migrationBuilder.AddColumn<int>(
                name: "Percent",
                table: "Products",
                type: "int",
                nullable: true);
        }
    }
}
