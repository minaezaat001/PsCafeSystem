using Microsoft.EntityFrameworkCore.Migrations;

namespace PcAppMaster.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DrDrinkId",
                table: "receiptForDrinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "HpSinglePrice",
                table: "hoursPrices",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "HpMultiPrice",
                table: "hoursPrices",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrDrinkId",
                table: "receiptForDrinks");

            migrationBuilder.AlterColumn<int>(
                name: "HpSinglePrice",
                table: "hoursPrices",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "HpMultiPrice",
                table: "hoursPrices",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
