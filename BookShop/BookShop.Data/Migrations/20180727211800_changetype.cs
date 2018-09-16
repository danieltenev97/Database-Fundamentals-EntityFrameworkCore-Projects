using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShop.Data.Migrations
{
    public partial class changetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AgeRestriction",
                table: "Books",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AgeRestriction",
                table: "Books",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
