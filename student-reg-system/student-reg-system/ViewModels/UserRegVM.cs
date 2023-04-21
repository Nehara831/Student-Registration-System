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
using System.Windows.Data;
using System.Windows;
using student_reg_system.database;
using student_reg_system.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;

namespace student_reg_system.ViewModels
{
    partial class UserRegVM : ObservableObject
    {

        [ObservableProperty]
        public static int userId;
        [ObservableProperty]
        public string? userFirstName;
        [ObservableProperty]
        public string? userLastName;
        [ObservableProperty]
        public string? userEmail;
        [ObservableProperty]
        public static string? userDepartment;
        [ObservableProperty]
        public int userPhone;



        [ObservableProperty]
        public ObservableCollection<User> usersList = new ObservableCollection<User>();
        [ObservableProperty]
        public ObservableCollection<Module> selectedModules = new ObservableCollection<Module>();



        [ObservableProperty]
        public ObservableCollection<Module> moduleList;
        public UserRegVM()
        {
            
            LoadUser();




        }
        public UserRegVM(User user, List<Module> moduleList)
        {

            ModuleList = new ObservableCollection<Module>(moduleList);
            UserId = user.IDUser;
            UserFirstName = user.FirstNameUser;
            UserLastName = user.LastNameUser;
            UserEmail = user.EmailUser;
            UserDepartment = user.DepartmentUser;
            UserPhone = user.PhoneUser;
            UpdateSelectedModulesForUser(user);

        }


        [RelayCommand]

        public void AddUser()
        {
            using (var db = new StudentContext())
            {
                foreach (var module in ModuleList)
                {
                    bool isSelected = module.IsSelected;

                    if (isSelected)
                    {


                        SelectedModules.Add(db.Modules.FirstOrDefault(u => u.ModuleName == module.ModuleName));
                        MessageBox.Show($"{module.ModuleId}");

                    }

                }



                User user = new User()
                {
                    IDUser = UserId,


                    FirstNameUser = UserFirstName,
                    LastNameUser = UserLastName,
                    EmailUser = UserEmail,
                    PhoneUser = UserPhone,
                    DepartmentUser = UserDepartment,
                    Modules = SelectedModules.ToList(),
                    Students = new List<Student>(),
                };




                db.Users.Add(user);
                db.SaveChanges();
            }

            LoadUser();

        }


        public void LoadUser()
        {


           
            using (var db = new StudentContext())
            {
                var listusers = db.Users


                .ToList();
                UsersList = new ObservableCollection<User>(listusers);

                var modules = db.Modules

                .ToList();

                /* if (modules == null)
                 {
                     MessageBox.Show("no mudules");
                 }*/
                if (modules == null)
                {
                    ModuleList = new ObservableCollection<Module>();
                }
                ModuleList = new ObservableCollection<Module>(modules);
              

            }
        }

        [RelayCommand]
        public void EditUser(User user)
        {
            List<Module> DepModuleList = new List<Module>();
           

            using (var db = new StudentContext())
            {
                
                
                DepModuleList = db.Modules.ToList();

            }

            var editView = new UserRegistration(user, DepModuleList);
            editView.Show();
        }

        [RelayCommand]
        public void UpdateSelectedModulesForUser(User user)
        {


            foreach (var moduleL in ModuleList)
            {
                bool exists = false;
                foreach (var module in user.Modules)
                {
                    if (moduleL.ModuleId == module.ModuleId)
                    {
                        exists = true;
                    }
                }

                if (exists)
                {
                    moduleL.IsSelected = true;
                }
            }
        }



    }
}
