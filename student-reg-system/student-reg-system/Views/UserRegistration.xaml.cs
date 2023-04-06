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
    /// Interaction logic for UserRegistration.xaml
    /// </summary>
     public partial class UserRegistration : Window
    { 
        public UserRegistration()
        {
            InitializeComponent();
            DataContext = new UserRegVM();
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
        private void OnTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Foreground.Equals(Brushes.LightGray))
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }
    }
}
