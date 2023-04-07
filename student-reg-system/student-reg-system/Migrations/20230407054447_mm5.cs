using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_reg_system.Migrations
{
    /// <inheritdoc />
    public partial class mm5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddColumn<int>(
                name: "UserUserIDUser",
                table: "Modules",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_UserUserIDUser",
                table: "Modules",
                column: "UserUserIDUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_User_UserUserIDUser",
                table: "Modules",
                column: "UserUserIDUser",
                principalTable: "User",
                principalColumn: "IDUser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_User_UserUserIDUser",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_UserUserIDUser",
                table: "Modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserUserIDUser",
                table: "Modules");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "IDUser");
        }
    }
}
