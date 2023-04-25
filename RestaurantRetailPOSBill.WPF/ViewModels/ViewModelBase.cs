using RestaurantRetailPOSBill.WPF.Commands;
using RestaurantRetailPOSBill.WPF.State.Navigator;
using RestaurantRetailPOSBill.WPF.State.SettingsNavigator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantRetailPOSBill.WPF.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public ICommand ExitCommand { get; }
        public INavigator Navigator { get; set; }
        public string NavVisibility { get; set; }
        public ViewModelBase()
        {
            NavVisibility = "visible";
        }

        public virtual void Dispose() { }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
