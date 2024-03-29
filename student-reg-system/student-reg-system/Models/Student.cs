﻿using MessagePack;
using student_reg_system.database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace student_reg_system.Models
{
    public class Student
    {
        [Key]
        [ForeignKey("Users")]
        public int StudentIDStudent { get; set; }
        
        public string FirstNameStudent { get; set; }
        public string LastNameStudent{ get; set; }
        public DateOnly DateofBirthStudent { get; set; }
        public string AdressStudent { get; set; }
      //  public bool IsSelected { get; set; }

        public string DepartmentStudent { get; set; }
        public ICollection<Module> Modules { get; set; }

        public ICollection<User> Users { get; set; }

        public Student()
        {

            

        }
        
            public double CalculateGPA()
        {
            double point = 0;
            double sumOfCredits = 0.0000001;
            foreach (var module in Modules)
            {
                point = point + module.GradePoint * module.CreditValue;
                sumOfCredits += module.CreditValue;
            }

            double GPA = point / sumOfCredits;

            return GPA;
        }
    }
}