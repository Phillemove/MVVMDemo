using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMTest.ViewModel
{
    /**
     View Model for the Add User View.
     Uses some Properties to bind them to the view and some Properties to get the Data from the model.
     There are also some Relay Commands for user interaction from the view.
     */
    public partial class AddUserViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private UserCollection users;

        [ObservableProperty]
        private User user;

        public AddUserViewModel()
        {
            Name = string.Empty;
            Email = string.Empty;
            User = new User();
            Users = UserCollection.Instance;
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

            MessageBoxResult result = MessageBox.Show("User successfull created", "Add", MessageBoxButton.OK, MessageBoxImage.Information);

            if (result == MessageBoxResult.OK)
            {
                CloseCommand.Execute(this);
            }
        }

        [RelayCommand]
        private static void Close()
        {
            var currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            currentWindow?.Close();
        }
    }
}
