using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRetailPOSBill.WPF.ViewModels.Factories
{
    class PrinterSettingsViewModelFactory : IRestuarantPOSBillSettingsViewModel<PrinterSettingsViewModel>
    {
        public PrinterSettingsViewModel CreateSettingsViewModel()
        {
            return new PrinterSettingsViewModel();
        }
    }
}
