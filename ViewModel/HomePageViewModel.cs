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
    public partial class HomePageViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private UserCollection users;

        [ObservableProperty]
        private User user;

        public HomePageViewModel()
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

            if (obj != null && obj.Count == 0)
            {
                MessageBox.Show("Please select one user from the list", "Modify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var editUserViewModel = new EditUserViewModel(obj);
            var homeWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);

            var window = new Window
            {
                Content = new EditUser
                {
                    DataContext = editUserViewModel
                },
                Width = homeWindow!.ActualWidth,
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
            if (obj != null)
            {
                if (obj.Count == 0)
                {
                    MessageBox.Show("Please select one or more user from the list", "Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

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
            var homeWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);

            var window = new Window
            {
                Content = new AddUser(),
                Width = homeWindow!.ActualWidth,
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
            var currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            currentWindow?.Close();
        }
    }
}
