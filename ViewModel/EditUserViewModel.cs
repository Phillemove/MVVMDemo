using CommunityToolkit.Mvvm.ComponentModel;
using MVVMTest.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
