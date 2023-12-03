using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGalleryExhibition.Migrations
{
    public partial class updateddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExhibitionId",
                table: "Artist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artist_ExhibitionId",
                table: "Artist",
                column: "ExhibitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Exhibition_ExhibitionId",
                table: "Artist",
                column: "ExhibitionId",
                principalTable: "Exhibition",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Exhibition_ExhibitionId",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_ExhibitionId",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "ExhibitionId",
                table: "Artist");
        }
    }
}
