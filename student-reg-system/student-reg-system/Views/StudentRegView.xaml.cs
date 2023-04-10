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
       
        public StudentRegView()
        {
            InitializeComponent();
            DataContext = new StudentRegVM();
            // Create a list to store the selected items
            
            foreach (var selectedItem in MyListBox.SelectedItems)
            {
                 // Get the text of the selected item
                SelectedModules.Add((Module)selectedItem); // Add the text to the SelectedModulesList
            }


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

        private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /*  private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {

              var comboBox = sender as ComboBox;
              var listBox = comboBox.Template.FindName("PART_ListBox", comboBox) as ListBox;
              MessageBox.Show($"Listbox null{listBox.SelectedItems.Count}");
              if (listBox == null)
              {

                  return;
              }

              selectedModules.Clear();


              foreach (var item in listBox.SelectedItems)
              {
                  var module = item as Module;
                  if (module != null)
                  {
                      selectedModules.Add(module);

                  }
              }
          }*/




    }
}
