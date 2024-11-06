using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedPerson",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("c27fda36-f8f1-4c56-9435-64bcf0168902"), null, "Actividades personales", 50 },
                    { new Guid("c27fda36-f8f1-4c56-9435-64bcf01689f7"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "iTaskId", "AssignedPerson", "CategoryId", "CreationDate", "Description", "Title", "iTaskPriority" },
                values: new object[,]
                {
                    { new Guid("1e4e8aef-411f-45c6-bef0-581660f9b411"), null, new Guid("c27fda36-f8f1-4c56-9435-64bcf0168902"), new DateTime(2024, 11, 4, 11, 34, 40, 745, DateTimeKind.Local).AddTicks(8577), null, "Pagar tarjeta", 1 },
                    { new Guid("1e4e8aef-411f-45c6-bef0-581660f9b42c"), null, new Guid("c27fda36-f8f1-4c56-9435-64bcf01689f7"), new DateTime(2024, 11, 4, 11, 34, 40, 743, DateTimeKind.Local).AddTicks(6740), null, "Revisar pago de servicios", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "iTaskId",
                keyValue: new Guid("1e4e8aef-411f-45c6-bef0-581660f9b411"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "iTaskId",
                keyValue: new Guid("1e4e8aef-411f-45c6-bef0-581660f9b42c"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("c27fda36-f8f1-4c56-9435-64bcf0168902"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("c27fda36-f8f1-4c56-9435-64bcf01689f7"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssignedPerson",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
