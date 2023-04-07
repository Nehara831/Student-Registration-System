using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using student_reg_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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




        private readonly string _path = @"C:\Users\User\OneDrive\Desktop\Student-sys\student-reg-system\sqlite\StudentData.db";

    }

}
