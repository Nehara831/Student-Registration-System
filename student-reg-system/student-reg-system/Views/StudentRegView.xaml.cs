using student_reg_system.ViewModels;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;

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
            MyListBox.Items.Clear();
            MyListBox.ItemsSource = StudentRegVM.moduleList;

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
