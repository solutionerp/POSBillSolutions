using RestaurantRetailPOSBill.WPF.State.LoginNavigator;
using RestaurantRetailPOSBill.WPF.State.Navigator;
using RestaurantRetailPOSBill.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantRetailPOSBill.WPF.Commands
{
    public class UpdateCurrentLoginViewModelCommand : ICommand
    {
        public ILoginNavigator _iLoginNavigator;
        private readonly IRootRestaurantRetailPOSBillViewModelFactory _viewModelFactory;

        public UpdateCurrentLoginViewModelCommand(ILoginNavigator iLoginNavigator,
            IRootRestaurantRetailPOSBillViewModelFactory viewModelFactory)
        {
            _iLoginNavigator = iLoginNavigator;
            _viewModelFactory = viewModelFactory;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            //if (parameter is LoginViewType)
            //{
            //    LoginViewType viewType = (LoginViewType)parameter;
            //    _iLoginNavigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            //}
        }
    }
}
