using RestaurantRetailPOSBill.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;



namespace RestaurantRetailPOSBill.WPF.ViewModels
{
   public class PrinterSettingsViewModel : SettingViewModel
    {
        private RelayCommand _uploadFileCommand;
        public ObservableCollection<string> PrinterNames { get; set; } = new ObservableCollection<string>();
        public string SelectedPrinterName { get; set; }
        public string DefaultPrinterName { get; set; }

        public ObservableCollection<int> Numbers { get; set; } = new ObservableCollection<int>(Enumerable.Range(0, 11));
        public ObservableCollection<int> HeightNumbers { get; set; } = new ObservableCollection<int>(Enumerable.Range(200, 1000));
        public ObservableCollection<decimal> MarginNumbers { get; set; } = new ObservableCollection<decimal>(Enumerable.Range(0, 101).Select(x => (decimal)x / 10));

        public string SelectedPaperSize { get; set; }

        public string _ptinterPaperSize;

        public string ItemsForPaperSize
        {
            get
            {
                return _ptinterPaperSize;
            }
            set
            {
                _ptinterPaperSize = value;
                OnPropertyChanged("ItemsForPaperSize");
            }
        }
        public ICommand UploadFileCommand
        {
            get
            {
                if (_uploadFileCommand == null)
                {
                    _uploadFileCommand = new RelayCommand(UploadFile);
                }
                return _uploadFileCommand;
            }
        } 
        public PrinterSettingsViewModel()
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                PrinterNames.Add(printer);
            }
            DefaultPrinterName = new System.Drawing.Printing.PrinterSettings().PrinterName;
            SelectedPrinterName = DefaultPrinterName;
            string selectedPaperSize = SelectedPaperSize;
        }
        private void UploadFile()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                // The user selected a file, do something with it
                string filePath = openFileDialog.FileName;
                // TODO: Handle the file upload logic here
            }
        }
       
    }
}
