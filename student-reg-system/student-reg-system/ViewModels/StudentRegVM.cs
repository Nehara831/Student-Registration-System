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
using student_reg_system.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
        public int noOfStudents;

        [ObservableProperty]
        public string? department;
        [ObservableProperty]
        public int userIdObservable;
        [ObservableProperty]
        public string userFullNameObservable;
        [ObservableProperty]
        public string userLNameObservable;
        [ObservableProperty]
        public string userDepartmentObservable;
        [ObservableProperty]
        public string userEmailObservable;


        [ObservableProperty]
        public int testName;
        [ObservableProperty]
        public static string testName2;

        [ObservableProperty]
        public static ObservableCollection<Student> studentList;

        [ObservableProperty]
        public ObservableCollection<Module> moduleListStudent;
        

        public static List<Module> SelectedModulesStudent;
        public StudentRegVM()
        {
            LoadStudent();

            UserIdObservable = LoginViewVM.CurrentUserId;
            SelectedModulesStudent = new List<Module>();

            
        }
            ////

            [RelayCommand]

            public void AddStudent()

            {

                using (var db = new StudentContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.IDUser == LoginViewVM.CurrentUserId);
                    // create new student object
                    Student student = new Student()
                    {
                        StudentIDStudent = Id,
                        FirstNameStudent = FName,
                        LastNameStudent = LName,
                        DateofBirthStudent = DoB,
                        AdressStudent = Adres,
                        DepartmentStudent = Department,
                        Modules =SelectedModulesStudent.ToList(),
                        Users=new List<User>() { user},
                    };

                

                SelectedModulesStudent = StudentRegView.SelectedModules;
                // MessageBox.Show($"Selected Module List Length = {SelectedModulesStudent.Count}");
                

                
                

                    // add student to Students table
                    db.Students.Add(student);

                // find the user with the specified ID and add the student to their list of students

                /*if (user != null)
                {
                    if (user.Students == null)
                    {
                        user.Students = new List<Student>();
                    }
                    user.Students.Add(student);
                }*/
                foreach (Module module in SelectedModulesStudent)
                {
                    // Check if the module is already being tracked by the context
                    var existingModule = db.Modules.Find(module.ModuleId);

                    // If the module is not being tracked, add it to the context
                    if (existingModule == null)
                    {
                        db.Modules.Add(module);
                    }

                    // Add the module to the student's collection
                    if (student != null)
                    {
                        if (student.Modules == null)
                        {
                            student.Modules = new List<Module>();
                        }

                        // If the module is being tracked, use the existing entity rather than adding a new one
                        student.Modules.Add(existingModule ?? module);
                    }
                }


                foreach (Module moduleSt in SelectedModulesStudent)
                {
                    if (moduleSt.Students == null)
                    {
                        moduleSt.Students = new List<Student>();
                    }
                    moduleSt.Students.Add(student);
                }
                

                // save changes to database
                db.SaveChanges();

                    // reload the list of students
                    LoadStudent();

                    /*int length1 = SelectedModulesStudent.Count;
                    MessageBox.Show($"lenth {length1}");*/

                    ClearTextBoxes();
                }
            }

        public void LoadStudent()
        {
            using (var db = new StudentContext())
            {

                var user = db.Users.Include(u => u.Students).SingleOrDefault(u => u.IDUser == LoginViewVM.CurrentUserId);

                // StudentList = new ObservableCollection<Student>(db.Students);
                if (user != null && user.Students != null)
                {
                    StudentList = new ObservableCollection<Student>(user.Students);
                }

                UserIdObservable = user.IDUser;
                UserFullNameObservable = user.FirstNameUser + " " + user.LastNameUser;
                UserLNameObservable = user.LastNameUser;
                UserDepartmentObservable = user.DepartmentUser + "  Department";
                UserEmailObservable = user.EmailUser;
                NoOfStudents = studentList.Count;

                var modules = db.Modules
                    .Where(m => m.Department == user.DepartmentUser)
                    .ToList();


                ModuleListStudent = new ObservableCollection<Module>(modules);

                


                
            

        }

        }
        [RelayCommand] 
        public void ShowModules()
        {
            using (var db = new StudentContext()) {
                var testStudent = db.Students.Include(s => s.Modules).FirstOrDefault(s => s.StudentIDStudent == TestName);


                TestName2 = "";
                if (testStudent != null)
                {
                    
                    if (testStudent.Modules != null)
                    {
                        foreach (Module module in testStudent.Modules)
                        {
                            TestName2 += " " + module.ModuleName;
                        }
                    }

                }
            }
            
        }


                [RelayCommand]
                public void ClearTextBoxes()
                {
                    var window = Application.Current.Windows.OfType<StudentRegView>().SingleOrDefault(x => x.IsActive);

                    window.IdTextBox.Text = "";
                    window.FNameTextBox.Text = "";
                    window.LNameTextBox.Text = "";
                    window.DepartmentTextBox.Text = "";
                    window.UserIdTextBox.Text = "";
                    window.AdressTextBox.Text = "";
                }
                //



            }


        }
