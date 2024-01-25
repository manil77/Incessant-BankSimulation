using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSimulation.DataAccess.Migrations
{
    public partial class AddedFiscalTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FiscalPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FiscalPeriodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalPeriods", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FiscalPeriods",
                columns: new[] { "Id", "EndDate", "FiscalPeriodName", "FiscalYear", "PeriodType", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "FY24Q1", "FY24", "Quarterly", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "FY24Q2", "FY24", "Quarterly", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "FY24Q3", "FY24", "Quarterly", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "FY24Q4", "FY24", "Quarterly", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FiscalPeriods");
        }
    }
}
