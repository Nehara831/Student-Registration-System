﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using student_reg_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace student_reg_system.database
{
    public class StudentContext:DbContext
    { protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"DataSource={_path}");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<User> Users { get; set; }
   

        public DbSet<LoginAuthentication> LoginAuthentications { get; set; }

        public DbSet<AdminAuthentication> AdminAuthentications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Modules)
                .WithMany(m => m.Students);
        }

        //string projectRootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));
        //string dbPath = Path.Combine("@",Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..")), "sqlite", "StudentData.db");

        private readonly string _path = @"C:\Users\User\OneDrive\Desktop\Student-sys\student-reg-system\sqlite\StudentData.db";
        //private readonly string _path = dbPath;

    }

}
