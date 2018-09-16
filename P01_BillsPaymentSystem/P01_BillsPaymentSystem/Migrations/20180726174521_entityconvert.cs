using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_BillsPaymentSystem.Migrations
{
    public partial class Entityconvert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "PaymentMethods",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "PaymentMethods",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
