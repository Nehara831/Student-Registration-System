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
    [Migration("20230407054447_mm5")]
    partial class mm5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

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

                    b.Property<int>("UserUserIDUser")
                        .HasColumnType("INTEGER");

                    b.HasKey("ModuleId");

                    b.HasIndex("UserUserIDUser");

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

                    b.ToTable("User");
                });

            modelBuilder.Entity("student_reg_system.Models.Module", b =>
                {
                    b.HasOne("student_reg_system.Models.User", "UserUser")
                        .WithMany()
                        .HasForeignKey("UserUserIDUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserUser");
                });
#pragma warning restore 612, 618
        }
    }
}
