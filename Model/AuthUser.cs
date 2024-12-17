using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTest.Model
{
    /*
     This is a simple Demo approach with hard coded credentials.
     In a real environment this would be in a Database
     */
    public partial class AuthUser : ObservableObject
    {
        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        public AuthUser()
        {
            Username = "Phil";
            Password = "password";
        }
    }
}
