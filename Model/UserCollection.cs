using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTest.Model
{
    public partial class UserCollection : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<User> users;

        public UserCollection()
        {
            Users = [new() { Name = "Phil", Email = "test@test.de" }];
        }

        public void Add(User user)
        {
            Users.Add(user);
        }

        public void Remove(User user)
        {
            Users.Remove(user);
        }
    }
}
