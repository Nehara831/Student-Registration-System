using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_reg_system.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentUser",
                columns: table => new
                {
                    StudentsStudentIDStudent = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersIDUser = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUser", x => new { x.StudentsStudentIDStudent, x.UsersIDUser });
                    table.ForeignKey(
                        name: "FK_StudentUser_Students_StudentsStudentIDStudent",
                        column: x => x.StudentsStudentIDStudent,
                        principalTable: "Students",
                        principalColumn: "StudentIDStudent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentUser_Users_UsersIDUser",
                        column: x => x.UsersIDUser,
                        principalTable: "Users",
                        principalColumn: "IDUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentUser_UsersIDUser",
                table: "StudentUser",
                column: "UsersIDUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentUser");
        }
    }
}
