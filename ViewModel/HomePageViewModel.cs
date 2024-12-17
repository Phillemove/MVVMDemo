using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMTest.Model;
using MVVMTest.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMTest.ViewModel
{
    /**
     View Model for the view after login (Home Page).
     It has some Wrapper properties to interact with the model and some Relay commands for the unser interaction from the view.
     */
    public partial class HomePageViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private UserCollection users;

        public HomePageViewModel()
        {
            Users = UserCollection.Instance;
        }

        [RelayCommand]
        private static void OpenModifyUser(IList? obj)
        {
            if (obj is not { Count: 1 })
            {
                string message = obj == null || obj.Count == 0
                    ? "Please select one user from the list"
                    : "Select only one Item";

                MessageBox.Show(message, "Modify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var editUserViewModel = new EditUserViewModel(obj);
            var homeWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);

            if (homeWindow == null) return;

            var window = new Window
            {
                Content = new EditUser
                {
                    DataContext = editUserViewModel
                },
                Width = homeWindow.ActualWidth,
                Height = homeWindow.ActualHeight,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = homeWindow,
                WindowStyle = WindowStyle.None,
                ResizeMode = ResizeMode.NoResize,
                ShowInTaskbar = false

            };
            window.ShowDialog();

        }

        [RelayCommand]
        private void RemoveUserFromList(IList? obj)
        {
            if (obj is not { Count: > 0 })
            {
                MessageBox.Show("Please select one or more user from the list", "Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            foreach (var user in obj.Cast<User>().ToList())
            {
                Users.Remove(user);
            }

            MessageBox.Show("User successfully removed", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        [RelayCommand]
        private static void OpenAddUser()
        {
            var homeWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);

            if (homeWindow == null) return;

            var window = new Window
            {
                Content = new AddUser(),
                Width = homeWindow.ActualWidth,
                Height = homeWindow.ActualHeight,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = homeWindow,
                WindowStyle = WindowStyle.None,
                ResizeMode = ResizeMode.NoResize,
                ShowInTaskbar = false

            };
            window.ShowDialog();
        }

        [RelayCommand]
        private static void Logout()
        {
            Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive)?.Close();
        }
    }
}
