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

namespace student_reg_system.ViewModels
{
   partial class UserRegVM:ObservableObject
    {

        [ObservableProperty]
        public int userId;
        [ObservableProperty]
        public string? userFirstName;
        [ObservableProperty]
        public string? userLastName;
        [ObservableProperty]
        public string? userEmail;
        [ObservableProperty]
        public string? userDepartment;
        [ObservableProperty]
        public int userPhone;


        [ObservableProperty]
        public ObservableCollection<User> usersList;

        [ObservableProperty]
        public ObservableCollection<Module> moduleList;
        [RelayCommand]

        public void AddUser()
        {
            User user = new User()
            {
                IDUser = UserId,


                FirstNameUser= UserFirstName,
                LastNameUser = UserLastName,
                EmailUser = UserEmail,
                PhoneUser=UserPhone,
                DepartmentUser = UserDepartment,
            };

            using (var db = new StudentContext())
            {
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
            }
        }

        public UserRegVM()
        {
            LoadUser();
            
            using (var db = new StudentContext())
            {
                var TestObj = from users in db.Users
                              from modules in db.Modules
                              where modules.UserId == users.IDUser
                              select new {
                                  
                      newModuleName = modules

                              };

               
                ObservableCollection<Module> moduleusers=new ObservableCollection<Module> ();
                foreach (var obj in TestObj)
                {
                    moduleusers.Add(obj.newModuleName);
                }
                ModuleList = moduleusers;
            }

            
        }




    }
}
