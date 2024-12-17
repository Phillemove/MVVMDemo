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

        public AddUserViewModel()
        {
            Name = Email = string.Empty;
            Users = UserCollection.Instance;
        }

        [RelayCommand]
        private void AddUserToList()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Please insert valid Data", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Users.Add(new User { Name = Name, Email = Email });

            Name = Email = string.Empty;

            if (MessageBox.Show("User successfull created", "Add", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
            {
                CloseCommand.Execute(this);
            }
        }

        [RelayCommand]
        private static void Close()
        {
            Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive)?.Close();
        }
    }
}
