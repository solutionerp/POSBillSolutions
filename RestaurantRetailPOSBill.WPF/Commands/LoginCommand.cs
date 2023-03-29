using POSBill.Domain.Services;
using RestaurantRetailPOSBill.WPF.State.Authenticators;
using RestaurantRetailPOSBill.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSBill.Domain.Services;
using System.Windows.Input;

namespace RestaurantRetailPOSBill.WPF.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly POSLoginViewModel _loginViewModel;
        private readonly IMajorIndexService _majorIndexService;

        string _userName;
        string _password;

        public LoginCommand(POSLoginViewModel loginViewModel,
            IMajorIndexService majorIndexService)
        {
            _loginViewModel = loginViewModel;
            _majorIndexService = majorIndexService;
            _userName = loginViewModel.Username;
            _password = loginViewModel.Password;
        }



        // private readonly IAuthenticator _authenticator;

        //public LoginCommand(POSLoginViewModel loginViewModel,
        //    IAuthenticator authenticator
        //    )
        //{
        //    _authenticator = authenticator;
        //    _loginViewModel = loginViewModel;
        //}

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
          return true;
        }

        public async void Execute(object? parameter)
        {
            // bool success = await _authenticator.Login(_loginViewModel.Username, string.Empty);
            _majorIndexService.Authenticate(_userName, _password);
        }
    }
}
