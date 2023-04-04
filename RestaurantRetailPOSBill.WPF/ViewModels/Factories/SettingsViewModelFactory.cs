using RestaurantRetailPOSBill.WPF.State.Navigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRetailPOSBill.WPF.ViewModels.Factories
{
    public class SettingsViewModelFactory : IRestaurantRetailPOSBillViewModelFactory<SettingViewModel>
    {
        
        public SettingViewModel CreateViewModel()
        {
            return new SettingViewModel();
        }
    }
}
