using RestaurantRetailPOSBill.WPF.State.Navigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRetailPOSBill.WPF.ViewModels
{
    public class MainwindowViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();  
    }
}
