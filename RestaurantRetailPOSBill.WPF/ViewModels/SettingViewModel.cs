using Org.BouncyCastle.Security;
using RestaurantRetailPOSBill.WPF.Commands;
using RestaurantRetailPOSBill.WPF.State.Navigator;
using RestaurantRetailPOSBill.WPF.State.SettingsNavigator;
using RestaurantRetailPOSBill.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantRetailPOSBill.WPF.ViewModels
{
    public class SettingViewModel : ViewModelBase
    {
        public ISettingsNavigator SettingsNavigator { get; set; } = new SettingsNavigator();

        public SettingViewModel()
        {
            
        }
         

}
}
