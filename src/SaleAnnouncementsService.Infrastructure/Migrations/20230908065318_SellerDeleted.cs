using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleAnnouncementsService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SellerDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Sellers_Id",
                table: "Announcements");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Announcements");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SellerId",
                table: "Announcements",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Sellers_Id",
                table: "Announcements",
                column: "Id",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
