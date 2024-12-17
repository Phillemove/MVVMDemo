using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTest.ViewModel
{
    public class ViewModelLocator
    {
        public static MainViewModel MainViewModel => new();
        public static HomePageViewModel HomePageViewModel => new();
        public static EditUserViewModel EditUserViewModel => new();
        public static AddUserViewModel AddUserViewModel => new();
    }
}
