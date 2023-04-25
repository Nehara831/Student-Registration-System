using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_reg_system.Migrations
{
    /// <inheritdoc />
    public partial class mn51 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Users_UserId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_UserId",
                table: "Modules");

            migrationBuilder.CreateTable(
                name: "ModuleUser",
                columns: table => new
                {
                    ModulesModuleId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersIDUser = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleUser", x => new { x.ModulesModuleId, x.UsersIDUser });
                    table.ForeignKey(
                        name: "FK_ModuleUser_Modules_ModulesModuleId",
                        column: x => x.ModulesModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleUser_Users_UsersIDUser",
                        column: x => x.UsersIDUser,
                        principalTable: "Users",
                        principalColumn: "IDUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleUser_UsersIDUser",
                table: "ModuleUser",
                column: "UsersIDUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleUser");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_UserId",
                table: "Modules",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Users_UserId",
                table: "Modules",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "IDUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
