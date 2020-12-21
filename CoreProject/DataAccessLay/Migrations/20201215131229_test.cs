using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLay.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "courseId",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2020, 12, 15, 13, 12, 29, 70, DateTimeKind.Utc).AddTicks(3988));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "courseId",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2020, 12, 15, 13, 8, 41, 998, DateTimeKind.Utc).AddTicks(690));
        }
    }
}
