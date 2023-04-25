using RestaurantRetailPOSBill.WPF.State.Navigator;
using RestaurantRetailPOSBill.WPF.State.SettingsNavigator;
using RestaurantRetailPOSBill.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantRetailPOSBill.WPF.Commands
{
    public class UpdateSettingsCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        ISettingsNavigator _settingsnavigator;
        public UpdateSettingsCurrentViewModelCommand(ISettingsNavigator settingsnavigator)
        {
            _settingsnavigator = settingsnavigator;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            if (parameter is SettingsViewType)
            {
                SettingsViewType viewType = (SettingsViewType)parameter;
                switch (viewType)
                {
                    case SettingsViewType.general:
                        _settingsnavigator.SettingsCurrentViewModel = new GeneralSettingsViewModel();
                        break;
                    case SettingsViewType.server:
                        _settingsnavigator.SettingsCurrentViewModel = new ServerSettingsViewModel();
                        break;
                    case SettingsViewType.printer:
                        _settingsnavigator.SettingsCurrentViewModel = new PrinterSettingsViewModel();
                        break;
                }
            }
        }
    }
}
