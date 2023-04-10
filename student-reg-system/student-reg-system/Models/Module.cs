using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_reg_system.Models
{
    public class Module
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public char Grade { get; set; }
        public double CreditValue { get; set; }
        public double GradePoint { get; set; }
        public bool IsSelected { get; set; }
        public User User { get; set; }
        public string Department { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }
        public ICollection<Student> Students { get; set; }

        public Module(int moduleId, string moduleName, double creditValue)
        {

            ModuleId = moduleId;
            ModuleName = moduleName;
            CreditValue = creditValue;
        }
        public Module() { }


    }
}
