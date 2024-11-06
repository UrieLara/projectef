using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class ColumnAssignedPersoniTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedPerson",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedPerson",
                table: "Task");
        }
    }
}
