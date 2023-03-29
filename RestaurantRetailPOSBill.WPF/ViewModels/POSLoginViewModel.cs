using Google.Protobuf.WellKnownTypes;
using POSBill.Domain.Services;
using RestaurantRetailPOSBill.WPF.Commands;
using RestaurantRetailPOSBill.WPF.State.Authenticators;
using RetailResuarantPOSAPI.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RestaurantRetailPOSBill.WPF.ViewModels
{
   public class POSLoginViewModel : ViewModelBase
    {
        public string _userName;
        public string _password;
        private readonly IMajorIndexService _majorIndexService;
        public RelayCommand LoginCommand { get; set; }

        public POSLoginViewModel(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
            //LoginCommand = loginCommand;
            LoginCommand = new RelayCommand(Login);
        }

       
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
       
        private void Login()
        {
            _majorIndexService.Authenticate(Username, Password);

        }


        //public ICommand LoginCommand { get; }

        //public POSLoginViewModel(IMajorIndexService _majorIndexService)
        // {
        //    LoginCommand = new LoginCommand(this, _majorIndexService);
        //}


    }
}
