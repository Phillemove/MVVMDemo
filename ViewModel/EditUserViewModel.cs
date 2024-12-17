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
            User = new();
            UserCollection = UserCollection.Instance;

            User? firstUser = obj?.OfType<User>().FirstOrDefault();

            if (firstUser != null)
            {
                User.Id = firstUser.Id;
                User.Name = firstUser.Name;
                User.Email = firstUser.Email;
            }
        }

        [RelayCommand]
        private void Save()
        {
            bool modresult = UserCollection.Modify(User);
            if (modresult)
            {
                MessageBoxResult result = MessageBox.Show("User successfull updated", "Modify", MessageBoxButton.OK, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {
                    CloseCommand.Execute(this);
                }
            }
            else
            {
                MessageBox.Show("An error occured on updating the user", "Modify", MessageBoxButton.OK, MessageBoxImage.Error);
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
