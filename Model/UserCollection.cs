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
        private static UserCollection? instance = null;

        [ObservableProperty]
        private ObservableCollection<User> users;

        private int idCount;

        public static UserCollection Instance
        {
            get
            {
                instance ??= new UserCollection();
                return instance;
            }
        }

        private UserCollection()
        {
            idCount = 0;
            Users = [new() { Id = idCount, Name = "Phil", Email = "test@test.de" }];
        }

        public void Add(User user)
        {
            idCount++;
            user.Id = idCount;
            Users.Add(user);
        }

        public void Remove(User user)
        {
            Users.Remove(user);
        }

        public void Modify(User user)
        {
            User? existingUser = Users.FirstOrDefault(item => item.Id == user.Id);

            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
            }
        }
    }
}
