using Microsoft.EntityFrameworkCore.Migrations;

namespace PcAppMaster.Migrations
{
    public partial class xx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrDrinkId",
                table: "receiptForDrinks");

            migrationBuilder.AddColumn<int>(
                name: "ReceiptForDrinksRfDrinkId",
                table: "drinks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_drinks_ReceiptForDrinksRfDrinkId",
                table: "drinks",
                column: "ReceiptForDrinksRfDrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_drinks_receiptForDrinks_ReceiptForDrinksRfDrinkId",
                table: "drinks",
                column: "ReceiptForDrinksRfDrinkId",
                principalTable: "receiptForDrinks",
                principalColumn: "RfDrinkId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_drinks_receiptForDrinks_ReceiptForDrinksRfDrinkId",
                table: "drinks");

            migrationBuilder.DropIndex(
                name: "IX_drinks_ReceiptForDrinksRfDrinkId",
                table: "drinks");

            migrationBuilder.DropColumn(
                name: "ReceiptForDrinksRfDrinkId",
                table: "drinks");

            migrationBuilder.AddColumn<int>(
                name: "DrDrinkId",
                table: "receiptForDrinks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
