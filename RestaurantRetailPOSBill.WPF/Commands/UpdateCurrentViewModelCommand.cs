using RestaurantRetailPOSBill.WPF.State.Navigator;
using RestaurantRetailPOSBill.WPF.ViewModels;
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

        public event EventHandler? CanExecuteChanged;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(parameter is ViewType)
            {
               ViewType viewType = (ViewType)parameter;
                switch(viewType)
                {
                    case ViewType.DashBoard:
                        _navigator.CurrentViewModel = new DashBoardViewModel();
                        break;
                    case ViewType.POSBill:
                        _navigator.CurrentViewModel = new POSBIllViewModel();
                        break;
                    case ViewType.Settings:
                        _navigator.CurrentViewModel = new SettingViewModel();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
