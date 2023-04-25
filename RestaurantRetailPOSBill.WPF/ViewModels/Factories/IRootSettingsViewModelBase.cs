using RestaurantRetailPOSBill.WPF.State.SettingsNavigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRetailPOSBill.WPF.ViewModels.Factories
{
   public interface IRootSettingsViewModelBase
    {
        SettingViewModel SettingsCurrentViewModel(SettingsViewType settingsViewType);
    }
}
