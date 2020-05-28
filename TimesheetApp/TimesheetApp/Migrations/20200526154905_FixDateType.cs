using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimesheetApp.Migrations
{
    public partial class FixDateType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "ReportedTime",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ReportedTime",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
