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
        public string? NameUser { get; set; }
        public string? EmailUser { get; set; }

        public int Phone { get; set; }

        public string? DepartmentUser { get; set; }
        
        public List<Module> Modules = new List<Module>();
        
    }
}
