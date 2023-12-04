using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGalleryExhibition.Migrations
{
    public partial class addedNameToExhibition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Exhibition_ExhibitionID",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtWork_Exhibition_ExhibitionID",
                table: "ArtWork");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Exhibition",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExhibitionID",
                table: "ArtWork",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExhibitionID",
                table: "Artist",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Exhibition_ExhibitionID",
                table: "Artist",
                column: "ExhibitionID",
                principalTable: "Exhibition",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtWork_Exhibition_ExhibitionID",
                table: "ArtWork",
                column: "ExhibitionID",
                principalTable: "Exhibition",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Exhibition_ExhibitionID",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtWork_Exhibition_ExhibitionID",
                table: "ArtWork");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Exhibition");

            migrationBuilder.AlterColumn<int>(
                name: "ExhibitionID",
                table: "ArtWork",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExhibitionID",
                table: "Artist",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Exhibition_ExhibitionID",
                table: "Artist",
                column: "ExhibitionID",
                principalTable: "Exhibition",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtWork_Exhibition_ExhibitionID",
                table: "ArtWork",
                column: "ExhibitionID",
                principalTable: "Exhibition",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
