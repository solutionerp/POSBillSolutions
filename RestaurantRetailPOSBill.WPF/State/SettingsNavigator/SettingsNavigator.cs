using RestaurantRetailPOSBill.WPF.Commands;
using RestaurantRetailPOSBill.WPF.Models;
using RestaurantRetailPOSBill.WPF.State.Navigator;
using RestaurantRetailPOSBill.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace RestaurantRetailPOSBill.WPF.State.SettingsNavigator
{
    public class SettingsNavigator : ObservableObject,ISettingsNavigator
    {
        private SettingViewModel _settingsCurrentViewModel;
        public SettingViewModel SettingsCurrentViewModel
        { 
            get
            {
                return _settingsCurrentViewModel;
            }
            set
            {
                _settingsCurrentViewModel = value;
                OnPropertyChanged(nameof(SettingsCurrentViewModel));
            }
        }
        public ICommand UpdateSettingsCurrentViewModelCommand => new UpdateSettingsCurrentViewModelCommand(this);
    }
}
