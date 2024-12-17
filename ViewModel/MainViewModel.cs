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
    /**
     View Model of the Main Window.
     It has some properties which are bind to the view and a wrapper property for the model.
     It has a relay command for the login mechanism.
     */
    public partial class MainViewModel : ObservableRecipient
    {
        private readonly AuthUser authUser;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string password;

        public MainViewModel()
        {
            Name = Password = string.Empty;
            authUser = new();
        }

        [RelayCommand]
        private void Login(object parameter)
        {

            if (parameter is not PasswordBox passwordBox)
            {
                MessageBox.Show("Invalid login input.");
                return;
            }

            Password = passwordBox.Password;

            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Please insert a Username and a Password");
                return;
            }

            if (Name == authUser.Username && Password == authUser.Password)
            {
                ShowHomePage();
            }
            else
            {
                MessageBox.Show("The Username or Password is not correct");
            }

            Name = Password = string.Empty;
        }

        private static void ShowHomePage()
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
        }

    }
}
