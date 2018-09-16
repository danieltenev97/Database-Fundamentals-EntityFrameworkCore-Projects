using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShop.Data.Migrations
{
    public partial class conversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AgeRestriction",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AgeRestriction",
                table: "Books",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
