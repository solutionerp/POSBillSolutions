using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using POSBill.Domain.Services;
using POSBill.Domain.Services.AuthenticationServices;
using POSBill.EntityFramework;
using RestaurantRetailPOSBill.WPF.State.Authenticators;
using RestaurantRetailPOSBill.WPF.State.Navigator;
using RestaurantRetailPOSBill.WPF.ViewModels;
using RestaurantRetailPOSBill.WPF.ViewModels.Factories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Hosting;
using RestaurantRetailPOSBill.WPF.ViewModels;
using POSBill.Domain.Models;
using POSBill.EntityFramework.Services;
using RetailResuarantPOSAPI.Api.Services;
using System.Windows.Input;
using RestaurantRetailPOSBill.WPF.Commands;

namespace RestaurantRetailPOSBill.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        private const int MINIMUM_SPLASH_TIME = 6000;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }
        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IServiceProvider serviceProvider = CreateServiceProvider();
            Window window = serviceProvider.GetRequiredService<SplashWindow>();
            window.Show();


            Task.Factory.StartNew(() =>

            {
                //simulate some work being done
                System.Threading.Thread.Sleep(MINIMUM_SPLASH_TIME);

                //since we're not on the UI thread
                //once we're done we need to use the Dispatcher
                //to create and show the main window
                this.Dispatcher.Invoke(() =>
                {
                    //initialize the main window, set it as the application main window
                    //and close the splash screen
                    
                    MainWindow mainWindow = serviceProvider.GetRequiredService<MainWindow>();
                    mainWindow.Show();
                    window.Close();
                });
            });
        }
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<RestaurantRetailPOSBillDBContextFactory>();
            services.AddSingleton<IDataServices<User>, GenericDataService<User>>();
            services.AddSingleton<IAccountServices<User>, GenericAccountService<User>>();
            services.AddSingleton<IMajorIndexService, MajorIndexService>();
            services.AddSingleton<ICommand, RelayCommand>();
            //services.AddSingleton<IAccountServices<User>, MajorIndexService>();

            services.AddSingleton<IRootRestaurantRetailPOSBillViewModelFactory, RootRestaurantRetailPOSBillViewModelFactory>();
            services.AddSingleton<IRestaurantRetailPOSBillViewModelFactory<DashBoardViewModel>, DashBoardViewModelFactory>();
            services.AddSingleton<IRestaurantRetailPOSBillViewModelFactory<POSBIllViewModel>, POSBIllViewModelFactory>();
            services.AddSingleton<IRestaurantRetailPOSBillViewModelFactory<SettingViewModel>, SettingsViewModelFactory>();
            services.AddSingleton<IRestaurantRetailPOSBillViewModelFactory<POSLoginViewModel>, POSLoginViewModelFactory>();
            services.AddSingleton<IRestaurantRetailPOSBillViewModelFactory<GeneralSettingsViewModel>, GeneralSettingsViewModelFactory>();
            services.AddSingleton<IRestaurantRetailPOSBillViewModelFactory<CalculatorViewModel>, CalculatorViewModelFactory>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();

            services.AddSingleton<SplashWindow>(s => new SplashWindow(s.GetRequiredService<SplashViewModel>()));
             
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainwindowViewModel>()));
            //services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<SettingViewModel>()));
            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<IAuthenticator, Authenticator>();
            services.AddScoped<MainwindowViewModel>();

            services.AddTransient<SplashViewModel>();
            services.AddTransient<MainwindowViewModel>();


            return services.BuildServiceProvider();
        }
    }
}
