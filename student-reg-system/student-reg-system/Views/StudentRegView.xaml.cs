using Microsoft.EntityFrameworkCore;
using student_reg_system.database;
using student_reg_system.Models;
using student_reg_system.ViewModels;
using System.Collections.Generic;
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
        public static List<Module> SelectedModules = new List<Module>();

        public Student Student { get; }

        public StudentRegView()
        {
            InitializeComponent();
            DataContext = new StudentRegVM();
            //Create a list to store the selected items
/*///////////////////////////////////////////////////////////////////////////////////////////////////////////
            foreach (var selectedItem in MyListBox.SelectedItems)
            {
                // Get the text of the selected item
                SelectedModules.Add((Module)selectedItem); // Add the text to the SelectedModulesList
            }*/



        }
        public StudentRegView(Student student)
        {
            InitializeComponent();
            DataContext = new StudentRegVM(student);
            // Create a list to store the selected items

          /*  foreach (var selectedItem in MyListBox.SelectedItems)
            {
                // Get the text of the selected item
                SelectedModules.Add((Module)selectedItem); // Add the text to the SelectedModulesList
            }*/



        }



        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /*  private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
              AddSelectedModulesToList();
          }
          private void AddSelectedModulesToList()
          {
              List<Module> SelectedModulesList = new List<Module>(); // Create a list to store the selected modules

              foreach (Module selectedItem in MyListBox.SelectedItems)
              {
                  SelectedModules.Add(selectedItem); // Add the selected module to the SelectedModulesList
              }
              int leength = SelectedModules.Count;
              MessageBox.Show($"No.of Selected Modules {leength}");
              // Do something with the SelectedModulesList
          }

          private void Button_Click_2(object sender, RoutedEventArgs e)
          {
              myLabel1.Text = "";
              foreach (Module selectedItem in MyListBox.SelectedItems)
              {
                  myLabel1.Text+=selectedItem.ModuleName; // Add the selected module to the SelectedModulesList
              }
          }*/



     /*   private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            StudentContext dbContext = new StudentContext();
            var checkBox = sender as CheckBox;
            var enrollment = checkBox.DataContext as Enrollment;
            enrollment.IsSelected = true;
            dbContext.SaveChanges();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            StudentContext dbContext = new StudentContext();
            var checkBox = sender as CheckBox;
            var enrollment = checkBox.DataContext as Enrollment;
            enrollment.IsSelected = false;
            dbContext.SaveChanges();
        }*/

    }
}
