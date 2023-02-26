using student_reg_system.Models;
using student_reg_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace student_reg_system.Views
{
    /// <summary>
    /// Interaction logic for StudentRegView.xaml
    /// </summary>
    public partial class StudentRegView : Window
    {
        public StudentRegView()
        {
            InitializeComponent();
            DataContext = new StudentRegVM();

        }
    }
}
