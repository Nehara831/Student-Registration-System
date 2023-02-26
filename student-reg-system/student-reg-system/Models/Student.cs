using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_reg_system.Models
{
    public class Student
    {
        public int StudentIDStudent { get; set; }

        public string FirstNameStudent { get; set; }
        public string LastNameStudent{ get; set; }
        public DateTime DateofBirthStudent { get; set; }
        public string AdressStudent { get; set; }
        public List<Module> Modules = new List<Module>();

        public Student(int id, string fname, string lname, DateTime date, string adress)
        {
            StudentIDStudent = id;
            FirstNameStudent = fname;
            LastNameStudent = lname;
            DateofBirthStudent = date;
            AdressStudent = adress;

        }
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
