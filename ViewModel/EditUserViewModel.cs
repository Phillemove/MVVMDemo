using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMTest.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace MVVMTest.ViewModel
{
    /**
     View Model for the Edit User View.
     This View Model has two constructors. One without parameters and one with parameters.
     The constructor with parameters is used to pass a data selection from the view to this view model.
     Uses Properties to get the Data from the model.
     There are also some Relay Commands for user interaction from the view.
     */
    public partial class EditUserViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private User user;

        [ObservableProperty]
        private UserCollection userCollection;

        public EditUserViewModel()
        {
            User = new();
            UserCollection = UserCollection.Instance;
        }

        public EditUserViewModel(IList? obj)
        {
            User = obj?.OfType<User>().FirstOrDefault() ?? new();
            UserCollection = UserCollection.Instance;
        }

        [RelayCommand]
        private void Save()
        {
            string message;
            string title;
            MessageBoxImage icon;

            if (UserCollection.Modify(User))
            {
                message = "User successfully updated";
                title = "Modify";
                icon = MessageBoxImage.Information;
            }
            else
            {
                message = "An error occurred while updating the user";
                title = "Modify";
                icon = MessageBoxImage.Error;
            }

            if (MessageBox.Show(message, title, MessageBoxButton.OK, icon) == MessageBoxResult.OK && icon == MessageBoxImage.Information)
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
