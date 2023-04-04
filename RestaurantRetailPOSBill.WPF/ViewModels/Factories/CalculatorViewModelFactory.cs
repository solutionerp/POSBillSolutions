using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRetailPOSBill.WPF.ViewModels.Factories
{
    public class CalculatorViewModelFactory : IRestaurantRetailPOSBillViewModelFactory<CalculatorViewModel>
    {
        public CalculatorViewModel CreateViewModel()
        {
            return new CalculatorViewModel();
        }
    }
}
