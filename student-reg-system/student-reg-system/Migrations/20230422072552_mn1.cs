using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_reg_system.Migrations
{
    /// <inheritdoc />
    public partial class mn1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "DepartmentStudent",
                table: "Students",
                newName: "EmailAdress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAdress",
                table: "Students",
                newName: "DepartmentStudent");

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
