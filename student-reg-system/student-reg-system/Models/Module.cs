using student_reg_system.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace student_reg_system.Models
{
    public class Module: INotifyPropertyChanged
    {
        public int ModuleId { get; set; }
      //  public string ModuleName { get; set; }
        public char Grade { get; set; }
        public double CreditValue { get; set; }
        public double GradePoint { get; set; }
        
        public User User { get; set; }
        public string Department { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }
        public ICollection<Student> Students { get; set; }
        
            private string _moduleName;
            private bool _isSelected;

            public string ModuleName
            {
                get { return _moduleName; }
                set { _moduleName = value; NotifyPropertyChanged(); }
            }

            public bool IsSelected
            {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyPropertyChanged();

                if (_isSelected)
                {
                    // Add the module to the SelectedModules collection
                    StudentRegVM.SelectedModulesStudent.Add(this);
                }
                else
                {
                    // Remove the module from the SelectedModules collection
                    StudentRegVM.SelectedModulesStudent.Remove(this);
                }
            }
        }

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        

        public Module(int moduleId, string moduleName, double creditValue)
        {

            ModuleId = moduleId;
            ModuleName = moduleName;
            CreditValue = creditValue;
        }
        public Module() { }



    }
}
