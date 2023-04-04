using RestaurantRetailPOSBill.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantRetailPOSBill.WPF.State.SettingsNavigator
{
    public enum SettingsViewType
    {
        general,
        server,
        category,
        printer
    }
   public interface ISettingsNavigator
    {
        SettingViewModel SettingsCurrentViewModel { get; set; }
        ICommand UpdateSettingsCurrentViewModelCommand { get; }
    }
}
