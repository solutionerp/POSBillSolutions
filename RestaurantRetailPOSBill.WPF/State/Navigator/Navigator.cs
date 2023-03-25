using RestaurantRetailPOSBill.WPF.Commands;
using RestaurantRetailPOSBill.WPF.Models;
using RestaurantRetailPOSBill.WPF.ViewModels;
using RestaurantRetailPOSBill.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantRetailPOSBill.WPF.State.Navigator
{
    public class Navigator : ObservableObject, INavigator
    {
        
        public ViewModelBase _currentViewmodel;

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


        public ICommand UpdateCurrentViewModelCommand { get;set; }
        
        public Navigator(IRootRestaurantRetailPOSBillViewModelFactory viewModelFactory)
        {
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(this, viewModelFactory);
        }

        public new event PropertyChangedEventHandler PropertyChanged;

    }
}
