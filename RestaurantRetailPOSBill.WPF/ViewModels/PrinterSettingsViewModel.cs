using RestaurantRetailPOSBill.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace RestaurantRetailPOSBill.WPF.ViewModels
{
   public class PrinterSettingsViewModel : SettingViewModel
    {
        private RelayCommand _uploadFileCommand;
        public ObservableCollection<string> PrinterNames { get; set; } = new ObservableCollection<string>();
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
