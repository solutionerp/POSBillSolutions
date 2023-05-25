using RestaurantRetailPOSBill.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using POSBill.Domain.Models;
using POSBill.EntityFramework;
using System.Windows;

namespace RestaurantRetailPOSBill.WPF.ViewModels
{
   public class PrinterSettingsViewModel : SettingViewModel
    {
        private RelayCommand _uploadFileCommand;
        public ObservableCollection<string> PrinterNames { get; set; } = new ObservableCollection<string>();
        public string SelectedPrinterName { get; set; }
        public string DefaultPrinterName { get; set; }

        //public ObservableCollection<int> Numbers { get; set; } = new ObservableCollection<int>(Enumerable.Range(0, 11));
        //public ObservableCollection<int> HeightNumbers { get; set; } = new ObservableCollection<int>(Enumerable.Range(200, 1000));
        //public ObservableCollection<decimal> MarginNumbers { get; set; } = new ObservableCollection<decimal>(Enumerable.Range(0, 101).Select(x => (decimal)x / 10));

        public string _updatePrinterettings;
        public RelayCommand PrinterUpdate { get; set; }
        public string _ptinterPaperSize;
        public string _customWidthText;
        public string _customHeightText;
        public string _scalarfactor;
        public string _noOfCopies;
        public string _marginLeftText;
        public string _marginRightText;
        public string _marginTopText;
        public string _marginBottomText;

        public string MarginBottomText
        {
            get
            {
                return _marginBottomText;
            }
            set
            {
                _marginBottomText = value;
                OnPropertyChanged("MarginBottomText");
            }
        }
        public string MarginTopText
        {
            get
            {
                return _marginTopText;
            }
            set
            {
                _marginTopText = value;
                OnPropertyChanged("MarginTopText");
            }
        }
        public string MarginRightText
        {
            get
            {
                return _marginRightText;
            }

            set
            {
                _marginRightText = value;
                OnPropertyChanged("MarginRightText");
            }
        }
        public string MarginLeftText
        {
            get
            {
                return _ptinterPaperSize;
            } 
            set
            {
                _ptinterPaperSize = value;
                OnPropertyChanged("MarginLeftText");
            }
        }
        public string NoOfCopiesText
        {
            get
            {
                return _noOfCopies;
            }
            set
            {
                _noOfCopies = value;
                OnPropertyChanged("NoOfCopiesText");
            }
        }
        public string ScaleFactorText
        {
            get
            {
                return _scalarfactor;
            }
            set
            {
                _scalarfactor = value;
                OnPropertyChanged("ScaleFactorText");
            }
        }
        public string CustomWidthText
        {
            get
            {
                return _customWidthText;
            }
            set
            {
                _customWidthText = value;
                OnPropertyChanged("CustomWidthText");
            }
        } 
        public string CustomHeightText
        {
            get
            {
                return _customHeightText;
            }
            set
            { 
                _customHeightText = value;
                OnPropertyChanged("CustomHeightText");
            }
        }
        public string SelectedPaperSize
        {
            get
            {
                return _ptinterPaperSize;
            }
            set
            {
                _ptinterPaperSize = value;
                OnPropertyChanged("SelectedPaperSize");
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
            PrinterUpdate = new RelayCommand(UpadatePrintersettings);
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
      public void  UpadatePrintersettings()
        {
            DbManager<PaperSize> dbManagerPapersize = new DbManager<PaperSize>();
            List<PaperSize> paperSizeList = dbManagerPapersize.GetAll().Result.ToList();
            PaperSize paperSize = new PaperSize();
            paperSize._value = SelectedPaperSize;
            if (paperSizeList.Count > 0)
            {
                dbManagerPapersize.Update(0, paperSize);
                SelectedPaperSize = "";
            }
            else
            {
                dbManagerPapersize.Create(paperSize);
                SelectedPaperSize = "";
            }

            DbManager<DefaultPrinterSettings> dbManagerDefaultPrinter = new DbManager<DefaultPrinterSettings>();
            List<DefaultPrinterSettings> defaultprinterSettingsList = dbManagerDefaultPrinter.GetAll().Result.ToList();
            DefaultPrinterSettings defaultPrinterSettings = new DefaultPrinterSettings();
            defaultPrinterSettings._value = SelectedPrinterName;
            if (defaultprinterSettingsList.Count > 0)
            {
                dbManagerDefaultPrinter.Update(0, defaultPrinterSettings);
                SelectedPrinterName = "";
            }
            else
            {
                dbManagerDefaultPrinter.Create(defaultPrinterSettings);
                SelectedPrinterName = "";
            }

            DbManager<CustomWidthSettings> dbManagerCustomWidth = new DbManager<CustomWidthSettings>();
            List<CustomWidthSettings> CustomWidthSettingsList = dbManagerCustomWidth.GetAll().Result.ToList();
            CustomWidthSettings customWidthSettings = new CustomWidthSettings();
            customWidthSettings._value = CustomWidthText;
            if(CustomWidthSettingsList.Count > 0)
            {
                dbManagerCustomWidth.Update(0, customWidthSettings);
                CustomWidthText = "";
            } 
            else
            {
                dbManagerCustomWidth.Create(customWidthSettings);
                CustomWidthText = "";
            }
            DbManager<CustomHeightSettings> dbManagerCustomHeight = new DbManager<CustomHeightSettings>();
            List<CustomHeightSettings> CustomHeightSettingsList = dbManagerCustomHeight.GetAll().Result.ToList();
            CustomHeightSettings customHeightSettings = new CustomHeightSettings();
            customHeightSettings._value = CustomWidthText;
            if(CustomHeightSettingsList.Count >0)
            {
                dbManagerCustomHeight.Update(0, customHeightSettings);
                CustomWidthText = "";
            } 
            else
            {
                dbManagerCustomHeight.Create(customHeightSettings);
                CustomWidthText = "";
            }

            DbManager<NoOfCopiesSettings> dbManagerNoOfCopiesSettings = new DbManager<NoOfCopiesSettings>();
            List<NoOfCopiesSettings> NoOfCopiesSettingsList = dbManagerNoOfCopiesSettings.GetAll().Result.ToList();
            NoOfCopiesSettings NoOfCopiesSettings = new NoOfCopiesSettings();
            NoOfCopiesSettings._value = NoOfCopiesText;
            if(NoOfCopiesSettingsList.Count >0)
            {
                dbManagerNoOfCopiesSettings.Update(0, NoOfCopiesSettings);
                NoOfCopiesText = "";
            }
            else
            {
                dbManagerNoOfCopiesSettings.Create(NoOfCopiesSettings);
                NoOfCopiesText = "";
            }

            DbManager<ScalarFActorSettings> dbManagerScalarFActorSettings = new DbManager<ScalarFActorSettings>();
            List<ScalarFActorSettings> ScalarFActorSettingsList = dbManagerScalarFActorSettings.GetAll().Result.ToList();
            ScalarFActorSettings ScalarFActorSettings = new ScalarFActorSettings();
            ScalarFActorSettings._value = ScaleFactorText;
            if(ScalarFActorSettingsList.Count > 0)
            {
                dbManagerScalarFActorSettings.Update(0, ScalarFActorSettings);
            }
            else
            {
                dbManagerScalarFActorSettings.Create(ScalarFActorSettings);
            }

            DbManager<MarginLeftSettings> dbManagerMarginLeftSettings = new DbManager<MarginLeftSettings>();
            List<MarginLeftSettings> MarginLeftSettingsList = dbManagerMarginLeftSettings.GetAll().Result.ToList();
            MarginLeftSettings marginLeftSettings = new MarginLeftSettings();
            marginLeftSettings._value = MarginLeftText;
            if(MarginLeftSettingsList.Count > 0)
            {
                dbManagerMarginLeftSettings.Update(0, marginLeftSettings);
            }
            else
            {
                dbManagerMarginLeftSettings.Create(marginLeftSettings);
            }

            DbManager<MarginRightSettings> dbManagerMarginRightSettings = new DbManager<MarginRightSettings>();
            List<MarginRightSettings> marginRightSettingsList = dbManagerMarginRightSettings.GetAll().Result.ToList();
            MarginRightSettings marginRightSettings = new MarginRightSettings();
            marginRightSettings._value = MarginRightText;
            if(marginRightSettingsList.Count > 0)
            {
                dbManagerMarginRightSettings.Update(0, marginRightSettings);
            } 
            else
            {
                dbManagerMarginRightSettings.Create(marginRightSettings);
            }

            DbManager<MarginTopSettings> dbManagerMarginTopSettings = new DbManager<MarginTopSettings>();
            List<MarginTopSettings> marginTopSettingsList = dbManagerMarginTopSettings.GetAll().Result.ToList();
            MarginTopSettings marginTopSettings = new MarginTopSettings();
            marginLeftSettings._value = MarginTopText;
            if (marginRightSettingsList.Count > 0)
            {
                dbManagerMarginTopSettings.Update(0, marginTopSettings);
            }
            else
            {
                dbManagerMarginTopSettings.Create(marginTopSettings);
            }

            DbManager<MarginBottomSettings> dbManagerMarginBottomSettings = new DbManager<MarginBottomSettings>();
            List<MarginBottomSettings> marginBottomSettingsList = dbManagerMarginBottomSettings.GetAll().Result.ToList();
            MarginBottomSettings MarginBottomSettings = new MarginBottomSettings();
            MarginBottomSettings._value = MarginTopText;
            if (marginRightSettingsList.Count > 0)
            {
                dbManagerMarginBottomSettings.Update(0, MarginBottomSettings);
            }
            else
            {
                dbManagerMarginBottomSettings.Create(MarginBottomSettings);
            }
            MessageBox.Show("Successfully Updated");
        }
    }
}
