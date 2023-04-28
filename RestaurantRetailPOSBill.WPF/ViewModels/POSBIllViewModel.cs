using RestaurantRetailPOSBill.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private string _deliverChargeText { get; set; }
        private string _taxableAmntText { get; set; }

        public decimal Number { get; set; }
        public ICommand NumberButtonCommand { get; set; }
        public ICommand DecimalButtonCommand { get; set; }
        public ICommand ClearButtonCommand { get; set; }

        public string TaxableAmntText
        {
            get { return _taxableAmntText; }
            set
            {
                _taxableAmntText = value;
                OnPropertyChanged(nameof(TaxableAmntText));
            }
        }
        public string DeliverChargeText
        {
            get { return _deliverChargeText; }
            set
            {
                _deliverChargeText = value;
                OnPropertyChanged(nameof(DeliverChargeText));
            }
        }
        public string SearchText
        {
            get { return _qrCodeText; }
            set
            {
                _qrCodeText = value;
                OnPropertyChanged(nameof(SearchText));
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
