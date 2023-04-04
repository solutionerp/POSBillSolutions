using RestaurantRetailPOSBill.WPF.State.Navigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRetailPOSBill.WPF.ViewModels.Factories
{
    public class RootRestaurantRetailPOSBillViewModelFactory : IRootRestaurantRetailPOSBillViewModelFactory
    {
        private readonly IRestaurantRetailPOSBillViewModelFactory<DashBoardViewModel> _dashBoardViewModel;
        private readonly IRestaurantRetailPOSBillViewModelFactory<SettingViewModel> _settingsViewModel;
        private readonly IRestaurantRetailPOSBillViewModelFactory<POSBIllViewModel> _posBillViewModel;
        private readonly IRestaurantRetailPOSBillViewModelFactory<POSLoginViewModel> _posLoginViewModel;
        private readonly IRestaurantRetailPOSBillViewModelFactory<CalculatorViewModel> _calculatorViewmodel;

        public RootRestaurantRetailPOSBillViewModelFactory(IRestaurantRetailPOSBillViewModelFactory<DashBoardViewModel> dashBoardViewModel,
            IRestaurantRetailPOSBillViewModelFactory<SettingViewModel> settingsViewModel,
            IRestaurantRetailPOSBillViewModelFactory<POSBIllViewModel> posBillViewModel, 
            IRestaurantRetailPOSBillViewModelFactory<POSLoginViewModel> posLoginViewModel,
            IRestaurantRetailPOSBillViewModelFactory<CalculatorViewModel> calculatorViewmodel)
        {
            _dashBoardViewModel = dashBoardViewModel;
            _settingsViewModel = settingsViewModel;
            _posBillViewModel = posBillViewModel;
            _posLoginViewModel = posLoginViewModel;
            _calculatorViewmodel = calculatorViewmodel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {

                case ViewType.Login:
                    return _posLoginViewModel.CreateViewModel();
                case ViewType.DashBoard:
                    return _dashBoardViewModel.CreateViewModel();
                case ViewType.POSBill:
                    return _posBillViewModel.CreateViewModel();
                case ViewType.Settings:
                    return _settingsViewModel.CreateViewModel();
                case ViewType.calculator:
                    return _calculatorViewmodel.CreateViewModel();

                default:
                    throw new ArgumentException("The ViewType does not have ViewModel.", "viewType");
            }
            
        }
    }
}
