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
   partial class UserVM:ObservableObject
    {

        [ObservableProperty]
        public int userId;
        [ObservableProperty]
        public string? userName;
        [ObservableProperty]
        public string? userEmail;
        [ObservableProperty]
        public string? userdepartment;

        [ObservableProperty]

        ObservableCollection<Module> userModuleList;

        public UserVM()
        {
            
        }

       


    }
}
