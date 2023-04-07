using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_reg_system.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModuleStudent",
                columns: table => new
                {
                    ModulesModuleId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentssStudentIDStudent = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleStudent", x => new { x.ModulesModuleId, x.StudentssStudentIDStudent });
                    table.ForeignKey(
                        name: "FK_ModuleStudent_Modules_ModulesModuleId",
                        column: x => x.ModulesModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleStudent_Students_StudentssStudentIDStudent",
                        column: x => x.StudentssStudentIDStudent,
                        principalTable: "Students",
                        principalColumn: "StudentIDStudent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleStudent_StudentssStudentIDStudent",
                table: "ModuleStudent",
                column: "StudentssStudentIDStudent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleStudent");
        }
    }
}
