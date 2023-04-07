using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace student_reg_system.Models
{
    public class Student
    {
        [Key]
        public int StudentIDStudent { get; set; }
        
        public string FirstNameStudent { get; set; }
        public string LastNameStudent{ get; set; }
        public DateOnly DateofBirthStudent { get; set; }
        public string AdressStudent { get; set; }
        
        public string DepartmentStudent { get; set; }
        public ICollection<Module> Modules { get; set; }


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