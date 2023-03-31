using Microsoft.EntityFrameworkCore;
using student_reg_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_reg_system.database
{
    
        public class UserContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite($"DataSource={_path1}\"");
            }

            public DbSet<User> Users { get; set; }
            private readonly string _path1 = @"C:\Users\User\OneDrive\Desktop\Student-sys\student-reg-system\sqlite\UserData.db";

    }

}
