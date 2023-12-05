using Microsoft.EntityFrameworkCore.Migrations;

using System;


#nullable disable

namespace ArtGalleryExhibition.Migrations
{
    public partial class cartitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "ArtistID",
                table: "ArtWork",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtworkID = table.Column<int>(type: "int", nullable: true),
                    CartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_ArtWork_ArtworkID",
                        column: x => x.ArtworkID,
                        principalTable: "ArtWork",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderPlaced = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtworkID = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_ArtWork_ArtworkID",
                        column: x => x.ArtworkID,
                        principalTable: "ArtWork",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtWork_ArtistID",
                table: "ArtWork",
                column: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ArtworkID",
                table: "CartItems",
                column: "ArtworkID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ArtworkID",
                table: "OrderDetails",
                column: "ArtworkID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtWork_Artist_ArtistID",
                table: "ArtWork",
                column: "ArtistID",
                principalTable: "Artist",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtWork_Artist_ArtistID",
                table: "ArtWork");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

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
    }
}
