using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PcAppMaster.Migrations
{
    public partial class databae : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "drinks",
                columns: table => new
                {
                    DrDrinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrDrinkName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrDrinkPrice = table.Column<int>(type: "int", nullable: false),
                    DrDrinkQut = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drinks", x => x.DrDrinkId);
                });

            migrationBuilder.CreateTable(
                name: "hoursPrices",
                columns: table => new
                {
                    HpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HpTypePc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HpSinglePrice = table.Column<int>(type: "int", nullable: false),
                    HpMultiPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoursPrices", x => x.HpId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserKind = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    Dvid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DvNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devices", x => x.Dvid);
                    table.ForeignKey(
                        name: "FK_devices_hoursPrices_HpId",
                        column: x => x.HpId,
                        principalTable: "hoursPrices",
                        principalColumn: "HpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receipts",
                columns: table => new
                {
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecPcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecTotalMinutes = table.Column<int>(type: "int", nullable: false),
                    RecHoursType = table.Column<bool>(type: "bit", nullable: false),
                    RecHoursPrice = table.Column<int>(type: "int", nullable: false),
                    RecDrinkPrice = table.Column<int>(type: "int", nullable: false),
                    ReceiptForDrinksRfDrinkId = table.Column<int>(type: "int", nullable: true),
                    RecTotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receipts", x => x.BillId);
                });

            migrationBuilder.CreateTable(
                name: "receiptForDrinks",
                columns: table => new
                {
                    RfDrinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfDrink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfDrinkQut = table.Column<int>(type: "int", nullable: false),
                    RfDrinkprice = table.Column<int>(type: "int", nullable: false),
                    RfDrinkTotal = table.Column<int>(type: "int", nullable: false),
                    ReceiptBillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receiptForDrinks", x => x.RfDrinkId);
                    table.ForeignKey(
                        name: "FK_receiptForDrinks_receipts_ReceiptBillId",
                        column: x => x.ReceiptBillId,
                        principalTable: "receipts",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_devices_HpId",
                table: "devices",
                column: "HpId");

            migrationBuilder.CreateIndex(
                name: "IX_receiptForDrinks_ReceiptBillId",
                table: "receiptForDrinks",
                column: "ReceiptBillId");

            migrationBuilder.CreateIndex(
                name: "IX_receipts_ReceiptForDrinksRfDrinkId",
                table: "receipts",
                column: "ReceiptForDrinksRfDrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_receipts_receiptForDrinks_ReceiptForDrinksRfDrinkId",
                table: "receipts",
                column: "ReceiptForDrinksRfDrinkId",
                principalTable: "receiptForDrinks",
                principalColumn: "RfDrinkId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_receiptForDrinks_receipts_ReceiptBillId",
                table: "receiptForDrinks");

            migrationBuilder.DropTable(
                name: "devices");

            migrationBuilder.DropTable(
                name: "drinks");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "hoursPrices");

            migrationBuilder.DropTable(
                name: "receipts");

            migrationBuilder.DropTable(
                name: "receiptForDrinks");
        }
    }
}
