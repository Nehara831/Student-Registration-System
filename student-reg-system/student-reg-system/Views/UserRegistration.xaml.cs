﻿using student_reg_system.database;
using student_reg_system.Models;
using student_reg_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    { public List<Module> ModuleList { get; set; }
        public UserRegistration()
        {
            InitializeComponent();
            DataContext = new UserRegVM();
            
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
        public void LoadModule()
        {
            using (var db = new StudentContext())
            {
                var list = db.Modules


                .ToList();
                ModuleList = new List<Module>(list);
            }
        }
       
    }
}
