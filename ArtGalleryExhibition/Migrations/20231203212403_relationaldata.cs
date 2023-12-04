using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGalleryExhibition.Migrations
{
    public partial class relationaldata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Exhibition_ExhibitionId",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtWork_Artist_ArtistId",
                table: "ArtWork");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtWork_Exhibition_ExhibitionId",
                table: "ArtWork");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Exhibition",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ExhibitionId",
                table: "ArtWork",
                newName: "ExhibitionID");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "ArtWork",
                newName: "ArtistID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ArtWork",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_ArtWork_ExhibitionId",
                table: "ArtWork",
                newName: "IX_ArtWork_ExhibitionID");

            migrationBuilder.RenameIndex(
                name: "IX_ArtWork_ArtistId",
                table: "ArtWork",
                newName: "IX_ArtWork_ArtistID");

            migrationBuilder.RenameColumn(
                name: "ExhibitionId",
                table: "Artist",
                newName: "ExhibitionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Artist",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Artist_ExhibitionId",
                table: "Artist",
                newName: "IX_Artist_ExhibitionID");

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "Exhibition",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "Exhibition",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Exhibition",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                name: "FK_ArtWork_Artist_ArtistID",
                table: "ArtWork",
                column: "ArtistID",
                principalTable: "Artist",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtWork_Exhibition_ExhibitionID",
                table: "ArtWork",
                column: "ExhibitionID",
                principalTable: "Exhibition",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Exhibition_ExhibitionID",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtWork_Artist_ArtistID",
                table: "ArtWork");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtWork_Exhibition_ExhibitionID",
                table: "ArtWork");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Exhibition",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ExhibitionID",
                table: "ArtWork",
                newName: "ExhibitionId");

            migrationBuilder.RenameColumn(
                name: "ArtistID",
                table: "ArtWork",
                newName: "ArtistId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ArtWork",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ArtWork_ExhibitionID",
                table: "ArtWork",
                newName: "IX_ArtWork_ExhibitionId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtWork_ArtistID",
                table: "ArtWork",
                newName: "IX_ArtWork_ArtistId");

            migrationBuilder.RenameColumn(
                name: "ExhibitionID",
                table: "Artist",
                newName: "ExhibitionId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Artist",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Artist_ExhibitionID",
                table: "Artist",
                newName: "IX_Artist_ExhibitionId");

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "Exhibition",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "Exhibition",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Exhibition",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExhibitionId",
                table: "ArtWork",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExhibitionId",
                table: "Artist",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Exhibition_ExhibitionId",
                table: "Artist",
                column: "ExhibitionId",
                principalTable: "Exhibition",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtWork_Artist_ArtistId",
                table: "ArtWork",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtWork_Exhibition_ExhibitionId",
                table: "ArtWork",
                column: "ExhibitionId",
                principalTable: "Exhibition",
                principalColumn: "Id");
        }
    }
}
