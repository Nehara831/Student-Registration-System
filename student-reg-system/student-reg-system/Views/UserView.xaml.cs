using student_reg_system.database;
using student_reg_system.Models;
using student_reg_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace student_reg_system.Views
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Window
    { 
        public UserView()
        {
            InitializeComponent();
           
            DataContext = new StudentRegVM();
          //  membersDataGrid.ItemsSource = StudentRegVM.studentList;
   

        }

        private bool IsMaximize = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximize = true;
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StudentRegView newview = new StudentRegView();
            newview.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

        private void DataGridCheckBoxColumn_Checked(object sender, RoutedEventArgs e)
        {
            /*if (((FrameworkElement)sender).DataContext is Student selectedStudent && selectedStudent.IsSelected)
            {
                MessageBox.Show("Selected student: " + selectedStudent.FirstNameStudent);
            }*/
        }
        private void Checked(object sender, RoutedEventArgs e)
        {
           // Student selectedStudent = membersDataGrid.SelectedItem as Student;

            // Show a message box with the selected student's name
           // MessageBox.Show("You have selected " + selectedStudent.FirstNameStudent + " " + selectedStudent.LastNameStudent);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Button working .cs");
            Checked(sender,e);
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected student object
            Student selectedStudent = membersDataGrid.SelectedItem as Student;

            StudentRegView studentRegView = new StudentRegView(selectedStudent);
            studentRegView.Show();
        }
    }

   
}
   
