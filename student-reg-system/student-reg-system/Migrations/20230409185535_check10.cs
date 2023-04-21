using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_reg_system.Migrations
{
    /// <inheritdoc />
    public partial class check10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Modules",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Modules",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Modules");
        }
    }
}
