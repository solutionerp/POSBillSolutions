using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRetailPOSBill.WPF.ViewModels.Factories
{
    public class GeneralSettingsViewModelFactory : IRestaurantRetailPOSBillViewModelFactory<GeneralSettingsViewModel>
    {
        public GeneralSettingsViewModel CreateViewModel()
        {
            return new GeneralSettingsViewModel();
        }
    }
}
