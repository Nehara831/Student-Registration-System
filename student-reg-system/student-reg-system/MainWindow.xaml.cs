using student_reg_system.ViewModels;
using student_reg_system.Views;
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

namespace student_reg_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var response = MessageBox.Show("Do you really want to exit?", "Exiting...",
                                      MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (response == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

        }

        private void btnCourse_click(object sender, RoutedEventArgs e)
        {
           // MainContainer.Content = new CourseView();
        }

        private void btnIndex_Click(object sender, RoutedEventArgs e)
        {
           // MainContainer.Content = new IndexView();
        }

        private void btnStuden_Click(object sender, RoutedEventArgs e)
        {
            StudentRegView newWindow = new StudentRegView();

            // Show the new window
            newWindow.Show();
        }
    }
}
