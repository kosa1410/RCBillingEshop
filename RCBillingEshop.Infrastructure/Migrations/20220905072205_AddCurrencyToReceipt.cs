using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCBillingEshop.Infrastructure.Migrations
{
    public partial class AddCurrencyToReceipt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Receipts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Receipts");
        }
    }
}
