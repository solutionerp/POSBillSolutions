using RestaurantRetailPOSBill.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantRetailPOSBill.WPF.State.Navigator
{
    public enum ViewType
    {
        DashBoard,
        POSBill,
        Settings
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
