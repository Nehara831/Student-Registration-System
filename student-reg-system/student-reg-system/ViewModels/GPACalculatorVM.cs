using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using student_reg_system.database;
using student_reg_system.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_reg_system.ViewModels
{

    partial class GPACalculatorVM : ObservableObject
    {

        [ObservableProperty]
        public int? studentId;

        [ObservableProperty]
        public string? studentName;

        [ObservableProperty]
        public ObservableCollection<Module> moduleList = new ObservableCollection<Module>();
        [ObservableProperty]
        public ObservableCollection<char> gradeList = new ObservableCollection<char>();
        
        public GPACalculatorVM() {
            GradeList = new ObservableCollection<char>() { 'A', 'B', 'C', 'D', 'F' };
           
        }
        [RelayCommand]
        public void Search()
        {
            using (StudentContext context = new StudentContext())
            {
                var student = context.Students.Include(s => s.Modules).FirstOrDefault(s => s.StudentIDStudent == StudentId);
                using(var db=new StudentContext()) {
                    student.Modules = db.Students.Include(s => s.Modules).FirstOrDefault(s => s.StudentIDStudent == student.StudentIDStudent).Modules;
                }

                ModuleList = new ObservableCollection<Module> (student.Modules);
                StudentName = student.FirstNameStudent + " " + student.LastNameStudent;
            }

           

        }
        [RelayCommand]
       public  void CalculateGPA(object selectedModule)
        {
            Module module = selectedModule as Module;
            if (module != null)
            {
                
            }
        }
    }
}
