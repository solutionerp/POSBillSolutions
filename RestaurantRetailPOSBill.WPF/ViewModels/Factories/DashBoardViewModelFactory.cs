using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRetailPOSBill.WPF.ViewModels.Factories
{
    public class DashBoardViewModelFactory : IRestaurantRetailPOSBillViewModelFactory<DashBoardViewModel>
    {
        public DashBoardViewModel CreateViewModel()
        {
            return new DashBoardViewModel();
        }
    }
}
