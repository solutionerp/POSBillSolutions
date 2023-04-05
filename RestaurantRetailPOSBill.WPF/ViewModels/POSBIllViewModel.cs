using RestaurantRetailPOSBill.WPF.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantRetailPOSBill.WPF.ViewModels
{
    public class POSBIllViewModel : ViewModelBase
    {
        public ICommand ScanQRCodeCommand { get; }
        private string _qrCodeText;

        private string _coloredText = "TomatoBisket  :";
        private string _coloredPriceText = "Price :10";

        public string ColoredPriceText
        {
            get { return _coloredPriceText; }
            set
            {

                _coloredText = value;
                OnPropertyChanged(nameof(ColoredPriceText));
            }
        }
        public string ColoredText
        {
            get { return _coloredText; }
            set
            {
                
                _coloredText = value;
                OnPropertyChanged(nameof(ColoredText));
            }
        }
        public string QRCodeText
        {
            get { return _qrCodeText; }
            set
            {
                _qrCodeText = value;
                OnPropertyChanged(nameof(QRCodeText));
            }
        }
        public POSBIllViewModel() 
        {
            ScanQRCodeCommand = new RelayCommand(ScanQRCode);
        }
        private void ScanQRCode()
        {
            // Use QR code scanner library to read QR code
            // Update QRCodeText property with scanned text
        }
        //private void ScanQRCode()
        //{
        //    string qrCodeContents = "some search term";
        //    SearchTerm = qrCodeContents;
        //}
        private void PerformSearch()
        {
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
