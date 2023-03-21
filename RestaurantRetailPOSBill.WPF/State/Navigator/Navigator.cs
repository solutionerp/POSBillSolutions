using RestaurantRetailPOSBill.WPF.Commands;
using RestaurantRetailPOSBill.WPF.Models;
using RestaurantRetailPOSBill.WPF.ViewModels;
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

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);

      
        public new event PropertyChangedEventHandler PropertyChanged;

    }
}
