using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ProductImageFile_Showcase",
                table: "Files",
                type: "boolean",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FileImageFile",
                columns: table => new
                {
                    FilesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageFilesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileImageFile", x => new { x.FilesId, x.ImageFilesId });
                    table.ForeignKey(
                        name: "FK_FileImageFile_Files_FilesId",
                        column: x => x.FilesId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileImageFile_Files_ImageFilesId",
                        column: x => x.ImageFilesId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileImageFile_ImageFilesId",
                table: "FileImageFile",
                column: "ImageFilesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileImageFile");

            migrationBuilder.DropColumn(
                name: "ProductImageFile_Showcase",
                table: "Files");
        }
    }
}
