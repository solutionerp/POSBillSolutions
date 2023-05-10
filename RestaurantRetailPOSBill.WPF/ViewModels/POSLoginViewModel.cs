using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNet.Identity;
using Org.BouncyCastle.Asn1.Crmf;
using POSBill.Domain.Models;
using POSBill.Domain.Services;
using POSBill.EntityFramework;
using RestaurantRetailPOSBill.WPF.Commands;
using RestaurantRetailPOSBill.WPF.Controls;
using RestaurantRetailPOSBill.WPF.State.Authenticators;
using RestaurantRetailPOSBill.WPF.State.Navigator;
using RestaurantRetailPOSBill.WPF.Views;
using RetailResuarantPOSAPI.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace RestaurantRetailPOSBill.WPF.ViewModels
{
   public class POSLoginViewModel : ViewModelBase
    {
        public string _userName;
        public string _password;
        private readonly IMajorIndexService _majorIndexService;
        private UserdbManager _userdbManager;
        public RelayCommand LoginCommand { get; set; }
        public List<User> Users { get; set; }
        bool IsValidUser = false;
        public event EventHandler LoginSuccessful;
        private string strPassword;
        private string strUsername;
        //public POSLoginViewModel(IMajorIndexService majorIndexService)
        //{
        //    _majorIndexService = majorIndexService;
        //    //LoginCommand = loginCommand;
        //    LoginCommand = new RelayCommand(Login);
        //}
        public POSLoginViewModel()
        {
            //  _majorIndexService = majorIndexService;
            //LoginCommand = loginCommand;
            LoginCommand = new RelayCommand(Login);
            NavVisibility = "collapsed";

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
                strUsername = _userName;
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
                strPassword = _password;   
                OnPropertyChanged(nameof(Password));
            }
        }
        private void Login()
        {
            try
            {

                // _userdbManager.SetUsers(Username, Password);
                 _userdbManager = new UserdbManager();
                User user = _userdbManager.GetUserByIdAndPassword(Username, Password);
                if(user!= null)
                {
                    if (user.user_id == Username && user.password == Password)
                    {
                        IsValidUser = true;
                        ((Navigator)Navigator).IsLoggedIn = true;
                        MessageBox.Show("Sucessfully Login");
                        strUsernameVM = strUsername;
                        strPasswordVM = strPassword;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username and Password");
                }
                
                //_majorIndexService.Authenticate(Username, Password);
                Username = "";
                Password = "";
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
       
        //public ICommand LoginCommand { get; }

        //public POSLoginViewModel(IMajorIndexService _majorIndexService)
        // {
        //    LoginCommand = new LoginCommand(this, _majorIndexService);
        //}
    }
}
