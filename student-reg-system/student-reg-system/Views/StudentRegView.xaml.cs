using student_reg_system.ViewModels;
using System.Windows;

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
