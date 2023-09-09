using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleAnnouncementsService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PhotosAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoLinks",
                table: "Announcements");

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnnoncementId = table.Column<Guid>(type: "uuid", nullable: false),
                    MainPhotoLink = table.Column<string>(type: "text", nullable: false),
                    SeckondPhotoLink = table.Column<string>(type: "text", nullable: false),
                    ThirdPhotoLink = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Announcements_AnnoncementId",
                        column: x => x.AnnoncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_AnnoncementId",
                table: "Photo",
                column: "AnnoncementId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.AddColumn<string>(
                name: "PhotoLinks",
                table: "Announcements",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
