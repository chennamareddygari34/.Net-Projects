using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAcountEstatementApp.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_currency_accounts_AccountNumber",
                table: "currency");

            migrationBuilder.DropIndex(
                name: "IX_currency_AccountNumber",
                table: "currency");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_currency_AccountNumber",
                table: "currency",
                column: "AccountNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_currency_accounts_AccountNumber",
                table: "currency",
                column: "AccountNumber",
                principalTable: "accounts",
                principalColumn: "AccountNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
