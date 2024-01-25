using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSimulation.DataAccess.Migrations
{
    public partial class AddedFiscalyearTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FiscalYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FiscalYearName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalYears", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FiscalYears",
                columns: new[] { "Id", "EndDate", "FiscalYearName", "StartDate" },
                values: new object[] { 1, new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "FY24", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "FiscalYears",
                columns: new[] { "Id", "EndDate", "FiscalYearName", "StartDate" },
                values: new object[] { 2, new DateTime(2025, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "FY25", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "FiscalYears",
                columns: new[] { "Id", "EndDate", "FiscalYearName", "StartDate" },
                values: new object[] { 3, new DateTime(2026, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "FY26 ", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FiscalYears");
        }
    }
}
