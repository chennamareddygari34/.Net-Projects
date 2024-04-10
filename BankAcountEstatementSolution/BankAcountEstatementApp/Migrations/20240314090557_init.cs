using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BankAcountEstatementApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    AccountNumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    AccountHolderName = table.Column<string>(type: "text", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    AccountCreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.AccountNumber);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<byte[]>(type: "bytea", nullable: false),
                    Key = table.Column<byte[]>(type: "bytea", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "statements",
                columns: table => new
                {
                    StatementId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountNumber = table.Column<int>(type: "integer", nullable: false),
                    PeriodStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PeriodEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statements", x => x.StatementId);
                    table.ForeignKey(
                        name: "FK_statements_accounts_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "accounts",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_statements_AccountNumber",
                table: "statements",
                column: "AccountNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "statements");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "accounts");
        }
    }
}
