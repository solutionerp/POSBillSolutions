using RestaurantRetailPOSBill.WPF.State.Navigator;
using RestaurantRetailPOSBill.WPF.State.SettingsNavigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRetailPOSBill.WPF.ViewModels.Factories
{
   public class RootRestaurantRetailPOSBillSettingsViewModelFactory : IRootSettingsViewModelBase
    {
        private readonly IRestuarantPOSBillSettingsViewModel<GeneralSettingsViewModel>  _genearlSettingsView;
        private readonly IRestuarantPOSBillSettingsViewModel<PrinterSettingsViewModel> _printerSettingsnavigator;
        private readonly IRestuarantPOSBillSettingsViewModel<ServerSettingsViewModel> _serverSettingsnavigator;

        public RootRestaurantRetailPOSBillSettingsViewModelFactory(IRestuarantPOSBillSettingsViewModel<GeneralSettingsViewModel> genearlSettingsView,
            IRestuarantPOSBillSettingsViewModel<PrinterSettingsViewModel> printerSettingsnavigator, 
            IRestuarantPOSBillSettingsViewModel<ServerSettingsViewModel> serverSettingsnavigator)
        {
            _genearlSettingsView = genearlSettingsView;
            _printerSettingsnavigator = printerSettingsnavigator;
            _serverSettingsnavigator = serverSettingsnavigator;
        }

        public SettingViewModel SettingsCurrentViewModel(SettingsViewType settingsViewType)
        {
            switch (settingsViewType)
            {
                case SettingsViewType.general:
                    return _genearlSettingsView.CreateSettingsViewModel();
                case SettingsViewType.server:
                    return _serverSettingsnavigator.CreateSettingsViewModel();
                   case SettingsViewType.printer:
                    return _printerSettingsnavigator.CreateSettingsViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have ViewModel.", "viewType");
            }
        }
    }
}
