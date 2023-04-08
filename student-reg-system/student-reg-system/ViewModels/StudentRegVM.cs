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
        public int userIdObservable;
        

        
       // [ObservableProperty]
       // public string selectedModule3;

        [ObservableProperty]
        public static  ObservableCollection<Student> studentList;

        [ObservableProperty]
        public static  ObservableCollection<Module> moduleList;

        public StudentRegVM()
        {
           

            UserIdObservable = LoginViewVM.CurrentUserId;
            LoadStudent();


        }
        [RelayCommand]

        public void AddStudent()
        {
            using (var db = new StudentContext())
            {
                var user = db.Users.Find(UserIdObservable);
                // create new student object
                Student student = new Student()
                {
                    StudentIDStudent = Id,
                    FirstNameStudent = FName,
                    LastNameStudent = LName,
                    DateofBirthStudent = DoB,
                    AdressStudent = Adres,
                    DepartmentStudent = Department,
                    Users = new List<User>() { user }
                };

                // add student to Students table
                db.Students.Add(student);

                // find the user with the specified ID and add the student to their list of students
               
                if (user != null)
                {
                    if (user.Students == null)
                    {
                        user.Students = new List<Student>();
                    }
                    user.Students.Add(student);
                }

                // save changes to database
                db.SaveChanges();

                // reload the list of students
                LoadStudent();
            }
        }

        public void LoadStudent()
        {
            using (var db = new StudentContext())
            {

                 
                var user = db.Users.Find(UserIdObservable);
                // StudentList = new ObservableCollection<Student>(db.Students);
                if (user != null && user.Students != null)
                  {
                    StudentList = new ObservableCollection<Student>(user.Students);
                }








            }
        }




    }



    }



