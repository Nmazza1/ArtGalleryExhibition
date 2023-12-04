using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGalleryExhibition.Migrations
{
    public partial class makeworksandartistsoptionalaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtWork_Artist_ArtistID",
                table: "ArtWork");

            migrationBuilder.DropIndex(
                name: "IX_ArtWork_ArtistID",
                table: "ArtWork");

            migrationBuilder.AlterColumn<string>(
                name: "ArtistID",
                table: "ArtWork",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArtistID1",
                table: "ArtWork",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isFeatured",
                table: "ArtWork",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArtWork_ArtistID1",
                table: "ArtWork",
                column: "ArtistID1");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtWork_Artist_ArtistID1",
                table: "ArtWork",
                column: "ArtistID1",
                principalTable: "Artist",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtWork_Artist_ArtistID1",
                table: "ArtWork");

            migrationBuilder.DropIndex(
                name: "IX_ArtWork_ArtistID1",
                table: "ArtWork");

            migrationBuilder.DropColumn(
                name: "ArtistID1",
                table: "ArtWork");

            migrationBuilder.DropColumn(
                name: "isFeatured",
                table: "ArtWork");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistID",
                table: "ArtWork",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArtWork_ArtistID",
                table: "ArtWork",
                column: "ArtistID");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtWork_Artist_ArtistID",
                table: "ArtWork",
                column: "ArtistID",
                principalTable: "Artist",
                principalColumn: "ID");
        }
    }
}
