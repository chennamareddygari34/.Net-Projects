using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CompanyWebApiApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    DepartmentNumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmentName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.DepartmentNumber);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<string>(type: "text", nullable: false),
                    EmployeeEmail = table.Column<string>(type: "text", nullable: false),
                    EmployeePhone = table.Column<int>(type: "integer", nullable: false),
                    EmployeeSalary = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "DepartmentNumber", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Operations" },
                    { 2, "HR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
