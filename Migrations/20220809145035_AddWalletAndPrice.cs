using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LieTunesReview.Migrations
{
    public partial class AddWalletAndPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Wallet",
                table: "User",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Song",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wallet",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Song");
        }
    }
}
