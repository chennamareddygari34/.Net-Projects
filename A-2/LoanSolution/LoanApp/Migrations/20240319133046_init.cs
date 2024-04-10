using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bikeloanrequests",
                columns: table => new
                {
                    BikeName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BikePrice = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bikeloanrequests", x => x.BikeName);
                });

            migrationBuilder.CreateTable(
                name: "carloanrequests",
                columns: table => new
                {
                    CarName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CarPrice = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carloanrequests", x => x.CarName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bikeloanrequests");

            migrationBuilder.DropTable(
                name: "carloanrequests");
        }
    }
}
