using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTest.Model
{
    /**
     Simple Data class for a User with observable Properties
     */
    public partial class User : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string email;

        private int id;

        public int Id
        {
            get => id;
            set => id = value;
        }

        public User()
        {
            Id = -1;
            Name = string.Empty;
            Email = string.Empty;
        }

    }
}
