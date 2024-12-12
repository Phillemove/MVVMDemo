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
        private UserCollection users;

        [ObservableProperty]
        private User user;

        public MainViewModel()
        {
            User = new User();
            Users = UserCollection.Instance;
        }

        [RelayCommand]
        private static void OpenModifyUser(IList? obj)
        {
            if (obj != null && obj.Count > 1)
            {
                MessageBox.Show("Select only one Item");
                return;
            }

            var editUserViewModel = new EditUserViewModel(obj);
            var mainWindow = Application.Current.MainWindow;

            var window = new Window
            {
                Content = new EditUser
                {
                    DataContext = editUserViewModel
                },
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

        [RelayCommand]
        private void RemoveUserFromList(IList? obj)
        {
            if (obj != null)
            {
                var copyOfSelectedItems = ((IList<object>)obj).ToList();

                foreach (User item in copyOfSelectedItems.Cast<User>())
                {
                    Users.Remove(item);
                }

                MessageBox.Show("User successfull removed", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        [RelayCommand]
        private static void OpenAddUser()
        {
            var mainWindow = Application.Current.MainWindow;

            var window = new Window
            {
                Content = new AddUser(),
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
