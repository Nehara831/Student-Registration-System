﻿using CommunityToolkit.Mvvm.ComponentModel;
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
        public ObservableCollection<Module> selectedModules=new ObservableCollection<Module>();
       


        [ObservableProperty]
        public ObservableCollection<Module> userModuleList;
        [RelayCommand]

        public void AddUser()
        {
            using (var db = new StudentContext())
            {
                foreach (var module in UserModuleList)
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
            

            using (StudentContext context = new StudentContext())
            {
              //  List<Student> students = context.Students.Where(student => student.user== lectureId).ToList();
                
            }
            using (var db = new StudentContext())
            {
                var listusers = db.Users


                .ToList();
               UsersList = new ObservableCollection<User>(listusers);

                var modules = db.Modules
               
                .ToList();


                UserModuleList = new ObservableCollection<Module>(modules);
                
            }
            }
            
        

        public UserRegVM()
        {
            LoadUser();
          



        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

            storage = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

       


    }
}
