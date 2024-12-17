using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMTest.Model;
using MVVMTest.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVMTest.ViewModel
{
    public partial class MainViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private AuthUser authUser;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string password;



        public MainViewModel()
        {
            Name = string.Empty;
            Password = string.Empty;
            AuthUser = new AuthUser();
        }

        [RelayCommand]
        private void Login(object parameter)
        {

            var passwordbox = parameter as PasswordBox;

            Password = passwordbox!.Password;

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Please insert a Username and a Password");
                return;
            }

            if (Name == AuthUser.Username && Password == AuthUser.Password)
            {
                var mainWindow = Application.Current.MainWindow;

                var window = new Window
                {
                    Content = new HomePage(),
                    Width = mainWindow.ActualWidth,
                    Height = mainWindow.ActualHeight,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = mainWindow,
                    WindowStyle = WindowStyle.None,
                    ResizeMode = ResizeMode.NoResize,
                    ShowInTaskbar = false

                };
                window.ShowDialog();

                Name = string.Empty;
                Password = string.Empty;
            }
            else
            {
                MessageBox.Show("The Username or Password is not correct");
                Name = string.Empty;
                Password = string.Empty;
                return;
            }
        }

    }
}
