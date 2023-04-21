using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_reg_system.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdressStudent",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateofBirthStudent",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstNameStudent",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastNameStudent",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdressStudent",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DateofBirthStudent",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FirstNameStudent",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LastNameStudent",
                table: "Students");
        }
    }
}
