using Google.Protobuf.WellKnownTypes;
using RestaurantRetailPOSBill.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestaurantRetailPOSBill.WPF.Views
{
    /// <summary>
    /// Interaction logic for POSLoginView.xaml
    /// </summary>
    public partial class POSLoginView : UserControl
    {
        public POSLoginView()
        {
            InitializeComponent();
            this.DataContext = new POSLoginViewModel();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string strUsername = txtUserName.Text;
            string strpasswrd = pbPassword.Password;
            // Your code here
        }

        //private async void AuthenticateButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var api = new MyApi();
        //    try
        //    {
        //        var result = await api.Authenticate(txtUserName.Text, pbPassword.Password);
        //        // Handle successful authentication
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle authentication failure
        //    }
        //}

    }
}
