using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_reg_system.Migrations
{
    /// <inheritdoc />
    public partial class mm8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_User_UserIDUser",
                table: "Modules");

            migrationBuilder.RenameColumn(
                name: "UserIDUser",
                table: "Modules",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_UserIDUser",
                table: "Modules",
                newName: "IX_Modules_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_User_UserId",
                table: "Modules",
                column: "UserId",
                principalTable: "User",
                principalColumn: "IDUser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_User_UserId",
                table: "Modules");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Modules",
                newName: "UserIDUser");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_UserId",
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
    }
}
