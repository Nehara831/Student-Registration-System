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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;

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
        private int userIdObservable;
        

        
       // [ObservableProperty]
       // public string selectedModule3;

        [ObservableProperty]
        public  ObservableCollection<Student> studentList;

        [ObservableProperty]
        public static  ObservableCollection<Module> moduleList;

        public StudentRegVM()
        {
            LoadStudent();

            UserIdObservable = LoginViewVM.CurrentUserId;


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

            using (var db = new StudentContext())
            {



                // Alternatively, retrieve multiple users using a LINQ query
                var users = db.Users.Where(u => u.IDUser == UserIdObservable).ToList();

                // Associate the student with the user(s)


                foreach (var u in users)
                {
                    if (u.Students == null)
                    {
                        u.Students = new List<Student>();
                    }
                    u.Students.Add(student);
                }
        
                // Save the changes to the database
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
