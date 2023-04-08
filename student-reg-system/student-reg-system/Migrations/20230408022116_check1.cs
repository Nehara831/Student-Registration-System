using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_reg_system.Migrations
{
    /// <inheritdoc />
    public partial class check1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleStudent_Students_StudentssStudentIDStudent",
                table: "ModuleStudent");

            migrationBuilder.RenameColumn(
                name: "StudentssStudentIDStudent",
                table: "ModuleStudent",
                newName: "StudentsStudentIDStudent");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleStudent_StudentssStudentIDStudent",
                table: "ModuleStudent",
                newName: "IX_ModuleStudent_StudentsStudentIDStudent");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleStudent_Students_StudentsStudentIDStudent",
                table: "ModuleStudent",
                column: "StudentsStudentIDStudent",
                principalTable: "Students",
                principalColumn: "StudentIDStudent",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleStudent_Students_StudentsStudentIDStudent",
                table: "ModuleStudent");

            migrationBuilder.RenameColumn(
                name: "StudentsStudentIDStudent",
                table: "ModuleStudent",
                newName: "StudentssStudentIDStudent");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleStudent_StudentsStudentIDStudent",
                table: "ModuleStudent",
                newName: "IX_ModuleStudent_StudentssStudentIDStudent");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleStudent_Students_StudentssStudentIDStudent",
                table: "ModuleStudent",
                column: "StudentssStudentIDStudent",
                principalTable: "Students",
                principalColumn: "StudentIDStudent",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
