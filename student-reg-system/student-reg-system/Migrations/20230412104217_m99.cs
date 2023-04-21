using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_reg_system.Migrations
{
    /// <inheritdoc />
    public partial class m99 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Modules");

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Students");

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Modules",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
