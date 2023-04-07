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
        public ObservableCollection<Module> moduleListObservable;
        [ObservableProperty]
        public int userIdObservable;
        public ModuleRegVM()
        {
            LoadModule();

        }



        [RelayCommand]

        public void AddModule()
        {
            Module module = new Module()
            {
                ModuleId = ModuleIdObservable,
                ModuleName = ModuleNameObservable,
                Grade = gradeObservable,
                CreditValue = creditValueObservable,
                GradePoint = gradePointObservable,
                UserId=UserIdObservable,

            };

            using (var db = new StudentContext())
            {
                db.Modules.Add(module);
                db.SaveChanges();
            }
            LoadModule();
        }

        public void LoadModule()
        {
            using (var db = new StudentContext())
            {
                var list = db.Modules


                .ToList();
                ModuleListObservable = new ObservableCollection<Module>(list);
            }
        }
    }

}