using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LieTunesReview.Migrations
{
    public partial class AddPurchaseDateAndRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfPurchase",
                table: "UserSong",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "UserSong",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfPurchase",
                table: "UserSong");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "UserSong");
        }
    }
}
