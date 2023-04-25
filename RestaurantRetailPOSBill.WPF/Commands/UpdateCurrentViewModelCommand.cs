using RestaurantRetailPOSBill.WPF.State.Navigator;
using RestaurantRetailPOSBill.WPF.ViewModels;
using RestaurantRetailPOSBill.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantRetailPOSBill.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {

        INavigator _navigator;
        private readonly IRootRestaurantRetailPOSBillViewModelFactory _viewModelFactory;
        public bool IsSettingsVisible = false;

        public UpdateCurrentViewModelCommand(INavigator navigator,
            IRootRestaurantRetailPOSBillViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }
        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter)
        {
            return true;
        }
        public void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
                _navigator.CurrentViewModel.Navigator = _navigator;
            }
        }
    }
}
