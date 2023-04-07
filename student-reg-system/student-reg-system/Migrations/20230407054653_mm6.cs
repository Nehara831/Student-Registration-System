using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_reg_system.Migrations
{
    /// <inheritdoc />
    public partial class mm6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_User_UserUserIDUser",
                table: "Modules");

            migrationBuilder.RenameColumn(
                name: "UserUserIDUser",
                table: "Modules",
                newName: "UserIDUser");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_UserUserIDUser",
                table: "Modules",
                newName: "IX_Modules_UserIDUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_User_UserIDUser",
                table: "Modules",
                column: "UserIDUser",
                principalTable: "User",
                principalColumn: "IDUser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_User_UserIDUser",
                table: "Modules");

            migrationBuilder.RenameColumn(
                name: "UserIDUser",
                table: "Modules",
                newName: "UserUserIDUser");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_UserIDUser",
                table: "Modules",
                newName: "IX_Modules_UserUserIDUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_User_UserUserIDUser",
                table: "Modules",
                column: "UserUserIDUser",
                principalTable: "User",
                principalColumn: "IDUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
