using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSSAssignment.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ImageId",
                table: "Movie",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Image_ImageId",
                table: "Movie",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Image_ImageId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_ImageId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Movie");
        }
    }
}
