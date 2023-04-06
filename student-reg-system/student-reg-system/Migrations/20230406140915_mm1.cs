using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_reg_system.Migrations
{
    /// <inheritdoc />
    public partial class mm1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "PhoneUser");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentStudent",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentStudent",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "PhoneUser",
                table: "Users",
                newName: "Phone");
        }
    }
}
