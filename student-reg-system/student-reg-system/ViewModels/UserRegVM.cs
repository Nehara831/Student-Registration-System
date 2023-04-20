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

namespace student_reg_system.ViewModels
{
   partial class UserRegVM:ObservableObject
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
        public ObservableCollection<User> usersList;
        [ObservableProperty]
        public ObservableCollection<Module> selectedModulesList=new ObservableCollection<Module>();
      

        [ObservableProperty]
        public ObservableCollection<Module> userModuleList;
        public UserRegVM()
        {
           // UserModuleList = new ObservableCollection<Module>();
            LoadUser();




        }
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
                Modules = SelectedModulesList.ToList(),
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

                var modules = db.Modules
               
                .ToList();

                /* if (modules == null)
                 {
                     MessageBox.Show("no mudules");
                 }*/
                if (modules == null)
                {
                    UserModuleList = new ObservableCollection<Module>();
                }
                UserModuleList = new ObservableCollection<Module>(modules);
                
            }
            }
            
        

       
     
       


    }
}
