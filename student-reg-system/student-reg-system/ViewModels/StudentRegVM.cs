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

namespace student_reg_system.ViewModels
{
    partial class StudentRegVM:ObservableObject
    {
        [ObservableProperty]
        public int id;

        [ObservableProperty]
        public string? firstName;
        [ObservableProperty]
        public string? lastName;
        [ObservableProperty]
        public DateTime dateofBirth;
        [ObservableProperty]
        public string? adress;
        




        [ObservableProperty]
         ObservableCollection<Module> moduleList;
        public StudentRegVM()
        {

            moduleList = new ObservableCollection<Module>()
            {
             new Module(3305, "Signal and Systems", 3),
             new Module(3301, "Analog Electronics", 3),           
             new Module(3302, "Data Structures and Algorithems", 3),
             new Module(3203, "Measurement", 2),
             new Module(3251, "GUI Prgramming", 2),
             new Module(3250, "Programming  Project", 3),
           

        };
        }
        [RelayCommand]

        public void addStudent()
        {
            Student student = new Student()
            {
                StudentIDStudent = Id,
                FirstNameStudent = FirstName,
                LastNameStudent = LastName,
                DateofBirthStudent = DateofBirth,
                AdressStudent = Adress,
            };

           // using (var db = new PersonContext())
           /* {
                db.Persons.Add(p);
                db.SaveChanges();
            }
            LoadPerson();*/
        }
    }
   

}
