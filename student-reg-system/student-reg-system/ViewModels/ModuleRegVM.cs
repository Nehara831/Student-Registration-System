using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using student_reg_system.database;
using student_reg_system.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_reg_system.ViewModels
{
    partial class ModuleRegVM : ObservableObject
    {
        [ObservableProperty]
        public int moduleIdObservable;
        [ObservableProperty]
        public string moduleNameObservable;
        [ObservableProperty]
        public char gradeObservable;
        [ObservableProperty]
        public double creditValueObservable;
        [ObservableProperty]
        public double gradePointObservable;
       
        [ObservableProperty]
        public int userModuleIdObservable;
        [ObservableProperty]
        public string userModuleDepartmentObservable;
        public ModuleRegVM()
        {
            


        }



        [RelayCommand]

        public void AddModule()
        {
            Module module = new Module()
            {
                ModuleId = ModuleIdObservable,
                ModuleName = ModuleNameObservable,

                CreditValue = creditValueObservable,
                GradePoint = gradePointObservable,
                UserId = UserModuleIdObservable,
                Department=UserModuleDepartmentObservable,
                IsSelected=false

            };

            using (var db = new StudentContext())
            {
                db.Modules.Add(module);

                var user = db.Users.FirstOrDefault(u => u.IDUser == UserModuleIdObservable);

                if (user != null)
                {
                    if (user.Modules == null)
                    {
                        user.Modules = new List<Module>();
                    }
                    user.Modules.Add(module);
                }
                /* */
                db.SaveChanges();

            }
           
        }

        
    }
}