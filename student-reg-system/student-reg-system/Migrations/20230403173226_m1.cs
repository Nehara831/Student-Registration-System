using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_reg_system.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModuleName = table.Column<string>(type: "TEXT", nullable: false),
                    Grade = table.Column<char>(type: "TEXT", nullable: false),
                    CreditValue = table.Column<double>(type: "REAL", nullable: false),
                    GradePoint = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IDUser = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameUser = table.Column<string>(type: "TEXT", nullable: true),
                    EmailUser = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartmentUser = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IDUser);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
