using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTest.ViewModel
{
    /**
     View Model Locator class.
     It is bind to the view as a static resource to provide the corresponding view model to it's view.
     */
    public class ViewModelLocator
    {
        public static MainViewModel MainViewModel => new();
        public static HomePageViewModel HomePageViewModel => new();
        public static EditUserViewModel EditUserViewModel => new();
        public static AddUserViewModel AddUserViewModel => new();
    }
}
