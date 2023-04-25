using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRetailPOSBill.WPF.ViewModels.Factories
{
    class ServerSettingsViewModelFactory : IRestuarantPOSBillSettingsViewModel<ServerSettingsViewModel>
    {
        public ServerSettingsViewModel CreateSettingsViewModel()
        {
           return new ServerSettingsViewModel();
        }
    }
}
