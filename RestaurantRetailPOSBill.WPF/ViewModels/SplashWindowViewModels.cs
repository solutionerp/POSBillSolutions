using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace RestaurantRetailPOSBill.WPF.ViewModels
{
    class SplashWindowViewModels : Window
    {
        DispatcherTimer timer;
        public MainWindow MainWindowDataContext;
        public SplashWindowViewModels()
        {
            
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            timer.Stop();
            this.DataContext = MainWindowDataContext;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }
    }
}
