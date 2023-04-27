using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSSAssignment.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_ReleaseDate_ReleaseDateId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "MovieGenreMap");

            migrationBuilder.DropTable(
                name: "ReleaseDate");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Movie_ReleaseDateId",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "ReleaseDateId",
                table: "Movie",
                newName: "Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Movie",
                newName: "ReleaseDateId");

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseDate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenreMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenreMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieGenreMap_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenreMap_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ReleaseDateId",
                table: "Movie",
                column: "ReleaseDateId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenreMap_GenreId",
                table: "MovieGenreMap",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenreMap_MovieId",
                table: "MovieGenreMap",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_ReleaseDate_ReleaseDateId",
                table: "Movie",
                column: "ReleaseDateId",
                principalTable: "ReleaseDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
