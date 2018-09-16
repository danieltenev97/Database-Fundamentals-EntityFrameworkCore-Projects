using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_BillsPaymentSystem.Migrations
{
    public partial class entityconvert2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "PaymentMethods",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "PaymentMethods",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");
        }
    }
}
