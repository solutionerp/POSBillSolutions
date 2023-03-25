﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRetailPOSBill.WPF.ViewModels.Factories
{
    public class POSBIllViewModelFactory : IRestaurantRetailPOSBillViewModelFactory<POSBIllViewModel>
    {
        public POSBIllViewModel CreateViewModel()
        {
           return new POSBIllViewModel();
        }
    }
}
