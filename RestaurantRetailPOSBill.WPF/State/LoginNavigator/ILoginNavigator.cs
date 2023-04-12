using RestaurantRetailPOSBill.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantRetailPOSBill.WPF.State.LoginNavigator
{
    public enum LoginViewType
    {
        Login
    }
    public interface ILoginNavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentLoginViewModelCommand { get; }
    }
}
