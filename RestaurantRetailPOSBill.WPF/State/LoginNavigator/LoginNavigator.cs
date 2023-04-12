using RestaurantRetailPOSBill.WPF.Commands;
using RestaurantRetailPOSBill.WPF.Models;
using RestaurantRetailPOSBill.WPF.State.Navigator;
using RestaurantRetailPOSBill.WPF.ViewModels;
using RestaurantRetailPOSBill.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantRetailPOSBill.WPF.State.LoginNavigator
{
    public class LoginNavigator : ObservableObject, ILoginNavigator
    {
        public ViewModelBase _currentViewmodel;
        //public SettingViewModel _settingsViewModel;

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewmodel;
            }
            set
            {
                _currentViewmodel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
        public ICommand UpdateCurrentLoginViewModelCommand { get; set; }
        public LoginNavigator(IRootRestaurantRetailPOSBillViewModelFactory viewModelFactory)
        {
            UpdateCurrentLoginViewModelCommand = new UpdateCurrentLoginViewModelCommand(this, viewModelFactory);
        }

        public new event PropertyChangedEventHandler PropertyChanged;
    }
}
