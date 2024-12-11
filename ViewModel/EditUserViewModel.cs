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

        public EditUserViewModel()
        {
            User = new();
        }

        public EditUserViewModel(IList? obj)
        {
            User = new();

            User? firstUser = obj?.OfType<User>().FirstOrDefault();

            if (firstUser != null)
            {
                User.Name = firstUser.Name;
                User.Email = firstUser.Email;
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
