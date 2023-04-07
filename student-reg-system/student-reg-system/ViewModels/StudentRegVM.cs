using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using student_reg_system.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using student_reg_system.database;
using System.Windows.Documents;
using System.Windows.Input;


namespace student_reg_system.ViewModels
{
    partial class StudentRegVM : ObservableObject
    {
        [ObservableProperty]
        public int id;

        [ObservableProperty]
        public string? fName;
        [ObservableProperty]
        public string? lName;
        [ObservableProperty]
        public DateOnly doB;
        [ObservableProperty]
        public string? adres;
       
        [ObservableProperty]
        public string? department;
        [ObservableProperty]
        private bool? isMale;
        [ObservableProperty]
        private bool? isFemale;

        
       // [ObservableProperty]
       // public string selectedModule3;

        [ObservableProperty]
        public  ObservableCollection<Student> studentList;

        [ObservableProperty]
        public static  ObservableCollection<Module> moduleList;

        public StudentRegVM()
        {
            LoadStudent();
            /*
            using (var db = new StudentContext())
            {
                var TestObj =from modules in db.Modules
                             from students in db.Students
                             where modules.ModuleId==students.


                .ToList();
                StudentList = new ObservableCollection<Student>(list);
            }

            */





        }
        [RelayCommand]

        public void AddStudent()
        {
            Student student = new Student()
            {
                StudentIDStudent = Id,
               

                FirstNameStudent = FName,
                LastNameStudent = LName,
                DateofBirthStudent = DoB,
                AdressStudent = Adres,
                DepartmentStudent=Department,
        };
           
            using (var db = new StudentContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
         LoadStudent();
        }
        
        public void LoadStudent()
        {
            using (var db = new StudentContext())
            {
                var list = db.Students
                

                .ToList();
                StudentList= new ObservableCollection<Student>(list);
            }
        }

       

    }


}
