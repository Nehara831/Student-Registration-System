using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_reg_system.Migrations
{
    /// <inheritdoc />
    public partial class mm3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameUser",
                table: "Users",
                newName: "LastNameUser");

            migrationBuilder.AddColumn<string>(
                name: "FirstNameUser",
                table: "Users",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstNameUser",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LastNameUser",
                table: "Users",
                newName: "NameUser");
        }
    }
}
