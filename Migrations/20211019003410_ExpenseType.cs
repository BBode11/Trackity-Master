using Microsoft.EntityFrameworkCore.Migrations;

namespace Trackity.Migrations
{
    public partial class ExpenseType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExpenseTypeId",
                table: "Expenses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    ExpenseTypeId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.ExpenseTypeId);
                });

            migrationBuilder.InsertData(
                table: "Type",
                columns: new[] { "ExpenseTypeId", "Name" },
                values: new object[,]
                {
                    { "F", "Fixed" },
                    { "R", "Recurring" },
                    { "N", "Non-Recurring" },
                    { "W", "Whammy" }
                });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1,
                column: "ExpenseTypeId",
                value: "F");

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 2,
                column: "ExpenseTypeId",
                value: "F");

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 3,
                column: "ExpenseTypeId",
                value: "R");

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 4,
                column: "ExpenseTypeId",
                value: "R");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseTypeId",
                table: "Expenses",
                column: "ExpenseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Type_ExpenseTypeId",
                table: "Expenses",
                column: "ExpenseTypeId",
                principalTable: "Type",
                principalColumn: "ExpenseTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Type_ExpenseTypeId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpenseTypeId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpenseTypeId",
                table: "Expenses");
        }
    }
}
