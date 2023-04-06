using student_reg_system.ViewModels;
using System.Windows;
using System.Windows.Input;

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
        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
