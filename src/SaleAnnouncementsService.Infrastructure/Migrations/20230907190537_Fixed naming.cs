using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleAnnouncementsService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fixednaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Selllers_Id",
                table: "Announcements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Selllers",
                table: "Selllers");

            migrationBuilder.RenameTable(
                name: "Selllers",
                newName: "Sellers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Sellers_Id",
                table: "Announcements",
                column: "Id",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Sellers_Id",
                table: "Announcements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers");

            migrationBuilder.RenameTable(
                name: "Sellers",
                newName: "Selllers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Selllers",
                table: "Selllers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Selllers_Id",
                table: "Announcements",
                column: "Id",
                principalTable: "Selllers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
