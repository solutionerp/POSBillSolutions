using RestaurantRetailPOSBill.WPF.State.LoginNavigator;
using RestaurantRetailPOSBill.WPF.State.Navigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRetailPOSBill.WPF.ViewModels
{
    public class MainwindowViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }
        public MainwindowViewModel(INavigator navigator)
        {
            Navigator = navigator;
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }

    }
}
