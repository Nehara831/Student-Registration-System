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
using System.Collections;
using System.Windows.Media;

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
       /* [ObservableProperty]*/
        
        [ObservableProperty]
        public static string testName2;

        [ObservableProperty]
        public static ObservableCollection<Student> studentList;

        [ObservableProperty]
        public ObservableCollection<Module> moduleListStudent;


        //public static ObservableCollection<Module> SelectedModulesStudent;

        //[ObservableProperty]
        //public ObservableCollection<Module> existingModules;
        //public RelayCommand<Module> UpdateModuleSelectionCommand;


        public List<Module> selectedModules = new List<Module>();

        public bool IsSelectedModule { get; set; }
       /* {
            get { return isSelectedModule; }
            set
            {
                isSelectedModule = value;
                OnPropertyChanged(nameof(IsSelectedModule));
            }
        }*/

      

    public StudentRegVM()
        {
            LoadStudent();

            UserIdObservable = LoginViewVM.CurrentUserId;
            //UpdateModuleSelectionCommand = new RelayCommand<Module>(UpdateModuleSelection);
            //SelectedModulesStudent = new ObservableCollection<Module>();


        }
        public StudentRegVM(Student student)
        {

            Id = student.StudentIDStudent;
            FName = student.FirstNameStudent;
            LName = student.LastNameStudent;
            Adres = student.AdressStudent;
            DoB = student.DateofBirthStudent;
            Department = student.DepartmentStudent;
            //SelectedModulesStudent = new ObservableCollection<Module> ();
            //UpdateModuleSelectionCommand = new RelayCommand<Module>(UpdateModuleSelection);
            LoadStudent();



        }



        public void updateStudent()
        {
            using (var db = new StudentContext())
            {
                // Get the student entity to update
                


                // Update the properties of the student entity
                /*  editedStudent.FirstNameStudent = FName;
                  editedStudent.LastNameStudent = LName;
                  editedStudent.AdressStudent = Adres;
                  editedStudent.DateofBirthStudent = DoB;

                  // Clear the existing modules for the student
                  editedStudent.Modules.Clear();

                  // Get the list of selected modules from the view model
                  SelectedModulesStudent = StudentRegView.SelectedModules;

                  // Add the selected modules to the student entity
                  foreach (Module module in SelectedModulesStudent)
                  {
                      editedStudent.Modules.Add(module);
                  }

                  // Update the students for each selected module
                  foreach (Module selectedModule in SelectedModulesStudent)
                  {
                      if (selectedModule != null)
                      {
                          // Get the module entity to update
                          var editedModule = db.Modules
                              .Include(m => m.Students)
                              .FirstOrDefault(m => m.ModuleId == selectedModule.ModuleId);

                          // Check if the student is already associated with the module
                          Student selectedStudent = editedModule.Students
                              .FirstOrDefault(s => s.StudentIDStudent == Id);

                          if (selectedStudent == null)
                          {
                              // If the student is not associated with the module, add it
                              selectedStudent = db.Students.FirstOrDefault(s => s.StudentIDStudent == Id);
                              editedModule.Students.Add(selectedStudent);
                          }
                          else
                          {
                              // If the student is already associated with the module, update its properties
                              selectedStudent.FirstNameStudent = FName;
                              selectedStudent.LastNameStudent = LName;
                              selectedStudent.AdressStudent = Adres;
                              selectedStudent.DateofBirthStudent = DoB;

                              // Clear the existing modules for the student
                              selectedStudent.Modules.Clear();

                              // Add the selected modules to the student entity
                              foreach (Module module in SelectedModulesStudent)
                              {
                                  selectedStudent.Modules.Add(module);
                              }
                          }
                      }
                  }*/

               
            }
        }


    
        [RelayCommand]

        public void AddStudent()

        {

            using (var db = new StudentContext())
            {
                // for Editing student details

                // Check if the module is already being tracked by the context


                Student existingStudent = db.Students.Find(Id);
                var user = db.Users.FirstOrDefault(u => u.IDUser == LoginViewVM.CurrentUserId);
                // If the module is not being tracked, add it to the context
/*                if (existingStudent != null)
                {
                    if (existingStudent.Modules == null)
                    {
                        ExistingModules = new ObservableCollection<Module>();
                    }
                    ExistingModules = (ObservableCollection<Module>)existingStudent.Modules;
                    db.Remove(existingStudent);
                    db.SaveChanges();
                }*/

                foreach (var module in ModuleListStudent)
                {
                    bool isSelected = module.IsSelected;

                    if (isSelected)
                    {
                  

                        selectedModules.Add(db.Modules.FirstOrDefault(u => u.ModuleName == module.ModuleName));
                        MessageBox.Show($"Item added..! {module.ModuleName}");

                    }
                    else
                    {
                        MessageBox.Show("Item not added");
                    }

                }

                //MessageBox.Show($"Selected module List: {selectedModules.Count()}");

                List<Module> tempList = new List<Module>
                {
                   db.Modules.FirstOrDefault(u => u.ModuleName == "Analog Electronics"),
                   db.Modules.FirstOrDefault(u => u.ModuleName == "Measurements")

                };
               // MessageBox.Show($"Temp module List: {tempList.Count()}");
                // create new student object
                Student student = new Student()
                {
                    StudentIDStudent = Id,
                    FirstNameStudent = FName,
                    LastNameStudent = LName,
                    DateofBirthStudent = DoB,
                    AdressStudent = Adres,
                    DepartmentStudent = Department,
                  
                    Modules = selectedModules,
                    Users = new List<User>() { user },

                };

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //  SelectedModulesStudent = StudentRegView.SelectedModules;

                /* var checkstu = db.Students.Include(u => u.Modules).FirstOrDefault(u => u.StudentIDStudent == Id);
                 var mod = checkstu.Modules.FirstOrDefault(u => u.ModuleName == "Analog");
                 IsSelectedModule = mod.IsSelected;
                 MessageBox.Show($"selected   {IsSelectedModule}");*/



                // add student to Students table
                db.Students.Add(student);
                if (user != null)
                {
                    if (user.Students == null)
                    {
                        user.Students = new List<Student>();
                    }
                    user.Students.Add(student);
                }
                /* foreach (Module module in SelectedModulesStudent)
                 {*/
                // Check if the module is already being tracked by the context
                //var existingModule = db.Modules.Find(module.ModuleId);

                // If the module is not being tracked, add it to the context


                // Add the module to the student's collection
                /* if (student != null)
                 {
                     if (student.Modules == null)
                     {
                         student.Modules = new List<Module>();
                     }

                     // If the module is being tracked, use the existing entity rather than adding a new one
                     student.Modules.Add(existingModule ?? module);
                 }*/
                //}


                /*                foreach (Module moduleSt in SelectedModulesStudent)
                                {
                                    if (moduleSt.Students == null)
                                    {
                                        moduleSt.Students = new List<Student>();
                                    }
                                    moduleSt.Students.Add(student);
                                }*/
                // save changes to database
                db.SaveChanges();
                //////////////////////////////////////////////////////////
                /* var checkstu = db.Students.Include(u => u.Modules).FirstOrDefault(u => u.StudentIDStudent == Id);
                 var mod = checkstu.Modules.FirstOrDefault(u => u.ModuleName == "Analog");
                 IsSelectedModule = mod.IsSelected;*/
                //  MessageBox.Show($"selected   {IsSelectedModule}");

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



                var modules = db.Modules
                    .Where(m => m.Department == user.DepartmentUser)
                    .ToList();


                ModuleListStudent = new ObservableCollection<Module>(modules);







            }

        }
        [RelayCommand]
        public void ShowModules()
        {
            
            using (var db = new StudentContext())
            {
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

            window.AdressTextBox.Text = "";
        }
        //

/*        private void UpdateModuleSelection(Module module)
        {
            *//*            using (var db = new StudentContext())
                        {
                            var stu = db.Students.Include(u => u.Modules).FirstOrDefault(u => u.StudentIDStudent == Id);
                            var mod = stu.Modules.FirstOrDefault(m => m.ModuleId == module.ModuleId);

                            if (mod != null)
                            {
                                mod.IsSelected = !module.IsSelected;
                            }
                            if (stu != null)
                            {
                                if (stu.Modules == null)
                                {
                                    stu.Modules = new List<Models.Module>();
                                }

                                // If the module is being tracked, use the existing entity rather than adding a new one
                                stu.Modules.Add(mod ?? module);
                            }
                            if (module.Students == null)
                            {
                                module.Students = new List<Student>();
                            }
                            module.Students.Add(stu);
                            db.SaveChanges();
                        }*//*

            //tempModule = module;
        
        }*/


    }

}     
