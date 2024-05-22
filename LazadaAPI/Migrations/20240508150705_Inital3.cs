using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LazadaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Inital3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_ApplicationUserId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ApplicationUserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUsersId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ApplicationUsersId",
                table: "Carts",
                column: "ApplicationUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_ApplicationUsersId",
                table: "Carts",
                column: "ApplicationUsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_ApplicationUsersId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ApplicationUsersId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ApplicationUsersId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ApplicationUserId",
                table: "Carts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_ApplicationUserId",
                table: "Carts",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
