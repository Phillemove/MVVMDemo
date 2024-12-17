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
