using RestaurantRetailPOSBill.WPF.Commands;
using RestaurantRetailPOSBill.WPF.State.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantRetailPOSBill.WPF.ViewModels
{
   public class POSLoginViewModel : ViewModelBase
    {
        public string _userName;
        public string _password;

        public string Username
        {
            get
            {
                return _userName;
            }
            set
            { 
                _userName = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public ICommand LoginCommand { get; }

        //public POSLoginViewModel(IAuthenticator authenticator)
        //{
        //    LoginCommand = new LoginCommand(this, authenticator);
        //}

    }
}
