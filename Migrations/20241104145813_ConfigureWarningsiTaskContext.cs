using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureWarningsiTaskContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "iTaskId",
                keyValue: new Guid("1e4e8aef-411f-45c6-bef0-581660f9b411"),
                column: "CreationDate",
                value: new DateTime(2024, 11, 4, 11, 58, 12, 442, DateTimeKind.Local).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "iTaskId",
                keyValue: new Guid("1e4e8aef-411f-45c6-bef0-581660f9b42c"),
                column: "CreationDate",
                value: new DateTime(2024, 11, 4, 11, 58, 12, 440, DateTimeKind.Local).AddTicks(3535));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "iTaskId",
                keyValue: new Guid("1e4e8aef-411f-45c6-bef0-581660f9b411"),
                column: "CreationDate",
                value: new DateTime(2024, 11, 4, 11, 34, 40, 745, DateTimeKind.Local).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "iTaskId",
                keyValue: new Guid("1e4e8aef-411f-45c6-bef0-581660f9b42c"),
                column: "CreationDate",
                value: new DateTime(2024, 11, 4, 11, 34, 40, 743, DateTimeKind.Local).AddTicks(6740));
        }
    }
}
