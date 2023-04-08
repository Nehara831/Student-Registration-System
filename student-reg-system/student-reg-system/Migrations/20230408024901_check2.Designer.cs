﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using student_reg_system.database;

#nullable disable

namespace student_reg_system.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20230408024901_check2")]
    partial class check2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("ModuleStudent", b =>
                {
                    b.Property<int>("ModulesModuleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentsStudentIDStudent")
                        .HasColumnType("INTEGER");

                    b.HasKey("ModulesModuleId", "StudentsStudentIDStudent");

                    b.HasIndex("StudentsStudentIDStudent");

                    b.ToTable("ModuleStudent");
                });

            modelBuilder.Entity("StudentUser", b =>
                {
                    b.Property<int>("StudentsStudentIDStudent")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersIDUser")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentsStudentIDStudent", "UsersIDUser");

                    b.HasIndex("UsersIDUser");

                    b.ToTable("StudentUser");
                });

            modelBuilder.Entity("student_reg_system.Models.LoginAuthentication", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginId");

                    b.ToTable("LoginAuthentications");
                });

            modelBuilder.Entity("student_reg_system.Models.Module", b =>
                {
                    b.Property<int>("ModuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("CreditValue")
                        .HasColumnType("REAL");

                    b.Property<char>("Grade")
                        .HasColumnType("TEXT");

                    b.Property<double>("GradePoint")
                        .HasColumnType("REAL");

                    b.Property<string>("ModuleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ModuleId");

                    b.HasIndex("UserId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("student_reg_system.Models.Student", b =>
                {
                    b.Property<int>("StudentIDStudent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdressStudent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DateofBirthStudent")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentStudent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstNameStudent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastNameStudent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StudentIDStudent");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("student_reg_system.Models.User", b =>
                {
                    b.Property<int>("IDUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DepartmentUser")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailUser")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstNameUser")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastNameUser")
                        .HasColumnType("TEXT");

                    b.Property<int>("PhoneUser")
                        .HasColumnType("INTEGER");

                    b.HasKey("IDUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ModuleStudent", b =>
                {
                    b.HasOne("student_reg_system.Models.Module", null)
                        .WithMany()
                        .HasForeignKey("ModulesModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("student_reg_system.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsStudentIDStudent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentUser", b =>
                {
                    b.HasOne("student_reg_system.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsStudentIDStudent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("student_reg_system.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersIDUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("student_reg_system.Models.Module", b =>
                {
                    b.HasOne("student_reg_system.Models.User", "User")
                        .WithMany("Modules")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("student_reg_system.Models.User", b =>
                {
                    b.Navigation("Modules");
                });
#pragma warning restore 612, 618
        }
    }
}
