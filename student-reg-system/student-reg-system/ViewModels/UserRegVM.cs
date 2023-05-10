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
        public string userUserName;
        [ObservableProperty]
        public string userPassword;
        [ObservableProperty]
        public int userPhone;


        [ObservableProperty]
        public   ObservableCollection<User> usersList;
        [ObservableProperty]
        public ObservableCollection<Module> selectedModules = new ObservableCollection<Module>();

        public static List<User> users = new List<User>();

        [ObservableProperty]
        public ObservableCollection<Module> moduleList;
        public UserRegVM()
        {
            UsersList = new ObservableCollection<User>();
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
            UserPassword = user.Password;
            UserUserName = user.UserName;
            UpdateSelectedModulesForUser(user);
           

        }

        [RelayCommand]
        public void AddUser()
        {
            
            using (var db = new StudentContext())
            {
                var user1 = db.Users.FirstOrDefault(u => u.IDUser == UserId);
                if (user1 != null)
                {
                    db.Remove(user1);
                    db.SaveChanges();
                }

               
                    foreach (var module in ModuleList)
                {
                   
                    bool isSelected = module.IsSelected;
                   

                        if (isSelected)
                        {
                       
                        SelectedModules.Add(db.Modules.FirstOrDefault(u => u.ModuleName == module.ModuleName));
                                                     
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
                        Password = UserPassword,
                        UserName = UserUserName,
                        Students = new List<Student>(),
                    };

                    db.Users.Add(user);
                    db.SaveChanges();

                }
           
            LoadUser();
            ClearTextBoxes();
           // var adminView = new AdminView();
          //  var vv = new UserPage();
           // Application.Current.Windows.OfType<UserView>().SingleOrDefault(x => x.IsActive)?.Close();

           // adminView.Show();
           // vv.ShowsNavigationUI= true;

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

                user.Modules = db.Users.Include(u => u.Modules).FirstOrDefault(u => u. IDUser== user.IDUser).Modules;
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
                if (user.Modules != null)
                
                    foreach (var module in user.Modules)
                    {
                        MessageBox.Show($"{module.ModuleName}");
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
        

        [RelayCommand]
        public void ClearTextBoxes()
        {
            var window = Application.Current.Windows.OfType<UserRegistration>().SingleOrDefault(x => x.IsActive);

            window.t1.Text = "";
            window.t2.Text = "";
            window.t3.Text = "";
            window.t4.Text = "";
            window.t5.Text = "";
            window.t6.Text = "";
            window.t7.Text = "";
            window.t8.Text = "";
           // window.myComboBox.SelectedItem = null;
        }
        [RelayCommand]
        public void DeleteUser(User user)
       
        {
            using (var db = new StudentContext())
            {
                db.Remove(user);
                db.SaveChanges();

                var userView = new AdminView();
                Application.Current.Windows.OfType<UserView>().SingleOrDefault(x => x.IsActive)?.Close();

                userView.Show();

            }

            }
    }
}
