using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualStudio.ApplicationInsights.Extensibility.Implementation;
using student_reg_system.database;
using student_reg_system.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace student_reg_system.ViewModels
{
    public partial class LoginViewVM:ObservableObject
    {

        [ObservableProperty]
        public string userName;
        [ObservableProperty]
        public string passWord;
        [ObservableProperty]
        public string loginView;
        public  static int CurrentUserId { get; set; }

        [RelayCommand]
        public  void LoginAcess()
        {
           


            
      using (StudentContext context = new StudentContext())
      {
          
          bool userfound = context.LoginAuthentications.Any(user => user.Username == UserName && user.Password == PassWord);

          if (userfound)
          {
              var user = context.LoginAuthentications.FirstOrDefault(u => u.Username == UserName && u.Password == PassWord);

              CurrentUserId = user.LoginId;

              GrantAcess();

          }
          else
          {
              MessageBox.Show("User Not Found");
          }

      }
      

        }
        [RelayCommand]
        public static void GrantAcess()
        {
            UserView userView= new UserView ();
            userView.Show();

        }
    }
}
