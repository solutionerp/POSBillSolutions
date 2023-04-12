using POSBill.Domain.Services;
using RestaurantRetailPOSBill.WPF.Commands;
using RestaurantRetailPOSBill.WPF.State.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRetailPOSBill.WPF.ViewModels.Factories
{
    public class POSLoginViewModelFactory : IRestaurantRetailPOSBillViewModelFactory<POSLoginViewModel>
    {
        // private readonly IAuthenticator _authenticator;
        //private readonly IMajorIndexService _majorIndexService;

        //public POSLoginViewModelFactory(IMajorIndexService majorIndexService)
        //{
        //    _majorIndexService = majorIndexService;
        //}

        //public POSLoginViewModelFactory(IAuthenticator authenticator)
        //{
        //    _authenticator = authenticator;
        //}

        public POSLoginViewModel CreateViewModel()
        {
            return new POSLoginViewModel();
        }
    }
}
