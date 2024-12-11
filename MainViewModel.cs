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
using System.Windows.Input;

namespace MVVMTest.ViewModel
{
    public partial class MainViewModel : ObservableRecipient
    {

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private UserCollection users;

        [ObservableProperty]
        private User user;

        public MainViewModel()
        {
            Name = string.Empty;
            Email = string.Empty;
            User = new User();
            Users = new UserCollection();
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

            var window = new Window
            {
                Content = new EditUser
                {
                    DataContext = editUserViewModel
                }
            };
            window.Show();
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
            }
        }

        [RelayCommand]
        private void AddUserToList()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email))
            {
                MessageBox.Show("Please insert Data");
                return;
            }

            User.Name = Name;
            User.Email = Email;
            Users.Add(User);

            Name = string.Empty;
            Email = string.Empty;
        }
    }
}
