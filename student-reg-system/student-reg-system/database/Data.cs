using CommunityToolkit.Mvvm.ComponentModel;
using student_reg_system.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_reg_system.database
{
    public class Data : ObservableObject
    {
        public static ObservableCollection<Student> GetStudents()
        {
            var list=new ObservableCollection<Student>();
            using(var ctx=new StudentContext())
            {
                foreach(var student in ctx.Students)
                {
                    list.Add(student);
                }
            }
            return list;
        }

    }
}
