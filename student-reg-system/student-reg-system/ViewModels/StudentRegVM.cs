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
        private bool? isMale;
        [ObservableProperty]
        private bool? isFemale;

        [ObservableProperty]
        public string selectedModule1;
        [ObservableProperty]
        public string selectedModule2;
       // [ObservableProperty]
       // public string selectedModule3;

        [ObservableProperty]
        public  ObservableCollection<Student> studentList;

        [ObservableProperty]
        public ObservableCollection<Module> moduleList;

        public StudentRegVM()
        {
            LoadStudent();
            
           
            

            moduleList = new ObservableCollection<Module>()
            {
             new Module(3305, "Signal and Systems", 3),
             new Module(3301, "Analog Electronics", 3),
             new Module(3302, "Data Structures and Algorithems", 3),
             new Module(3203, "Measurement", 2),
             new Module(3251, "GUI Prgramming", 2),
             new Module(3250, "Programming  Project", 3),

             
        };
          
            
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
