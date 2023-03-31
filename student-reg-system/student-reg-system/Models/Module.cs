using System;
using System.Collections.Generic;
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

        public Module(int moduleId, string moduleNane, double creditValue)
        {

            ModuleId = moduleId;
            ModuleName = moduleNane;

            CreditValue = creditValue;
        }



    }
}
