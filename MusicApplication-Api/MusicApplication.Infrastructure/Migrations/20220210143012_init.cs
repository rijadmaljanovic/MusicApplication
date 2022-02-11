using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApplication.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SongName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtistName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SongUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    IsFavourite = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Song_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hip Hop" },
                    { 2, "Blues" },
                    { 3, "Rock" },
                    { 4, "Dance" }
                });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "Id", "ArtistName", "CategoryId", "CreatedAt", "IsFavourite", "ModifiedAt", "Rating", "SongName", "SongUrl" },
                values: new object[,]
                {
                    { 1, "Eminem", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1990), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1990), 5, "Lose Urself", "https://www.youtube.com/watch?v=_Yhyp-_hX2s" },
                    { 2, "50 Cent", 1, new DateTime(2021, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), true, new DateTime(2021, 8, 2, 9, 30, 52, 0, DateTimeKind.Unspecified), 3, "In Da Club", "https://www.youtube.com/watch?v=5qm8PH4xAss" },
                    { 3, "The Rolling Stones", 3, new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), false, new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), 5, "Paint It, Black", "https://www.youtube.com/watch?v=O4irXQhgMqg" },
                    { 4, "The Rolling Stones", 3, new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), false, new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), 5, "Miss You", "https://www.youtube.com/watch?v=KuRxXRuAz-I" },
                    { 5, "Stromae", 4, new DateTime(2012, 2, 2, 1, 30, 52, 0, DateTimeKind.Unspecified), true, new DateTime(2020, 1, 3, 5, 30, 52, 0, DateTimeKind.Unspecified), 3, "Alors On Danse", "https://www.youtube.com/watch?v=VHoT4N43jK8" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Song_CategoryId",
                table: "Song",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
