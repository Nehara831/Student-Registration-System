﻿using student_reg_system.Models;
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
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        private bool IsMaximize = false;
        public AdminView()
        {
            InitializeComponent();
            DataContext = new UserRegVM();
            

        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    WindowState = System.Windows.WindowState.Normal;


                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximize = false;
                }
                else
                {
                    WindowState = System.Windows.WindowState.Maximized;

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

        
       

      
        private void StudentClick(object sender, RoutedEventArgs e)
        {
             MainContentFrame.Navigate(new UserPage());


        }
        private void GPACalculator(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new GpaCalculator());

        }
    }
}
