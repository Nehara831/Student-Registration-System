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
    public class User
    {
        [Key]
        public int IDUser { get; set; }

        public string? FirstNameUser { get; set; }
        public string? LastNameUser { get; set; }
        public string? EmailUser { get; set; }

        public int PhoneUser { get; set; }

        public string? DepartmentUser { get; set; }
        
        public ICollection<Module> Modules { get; set; }

    }
}
