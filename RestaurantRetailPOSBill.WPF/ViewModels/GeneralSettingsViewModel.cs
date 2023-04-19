using Microsoft.Win32;
using Mysqlx.Crud;
using POSBill.Domain.Models;
using POSBill.EntityFramework;
using RestaurantRetailPOSBill.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace RestaurantRetailPOSBill.WPF.ViewModels
{
    public class GeneralSettingsViewModel : SettingViewModel
    {
        public ICommand BrowseCommand { get; set; }
        public string _imageSource;
        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;
                    OnPropertyChanged("ImageSource");
                }
            }
        }
        private string _textProperty;
        public string TextProperty
        {
            get { return _textProperty; }
            set
            {
                if (_textProperty != value)
                {
                    _textProperty = value;
                    OnPropertyChanged("TextProperty");
                }
            }
        }
        public GeneralSettingsViewModel()
        {
            BrowseCommand = new RelayCommand(Browse);
            LoadImage(); 
        }
        public void Browse()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    ImageSource = openFileDialog.FileName;
                    _imageSource = ImageSource;
                }
                save(_imageSource);
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        } 
        public void save(string strImgSource)
        {
            try
            {
                Settings settings = new Settings();
                DbManager<Settings> dbManager = new DbManager<Settings>();
                settings._imagesource = strImgSource;
                if (dbManager.GetAll().Result.ToList().Count > 0)
                {
                    dbManager.Update(0, settings);
                }
                else
                {
                    dbManager.Create(settings);
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("An Exception Occured", ex);
            }
        }

        private void LoadImage()
        {
            DbManager<Settings> dbManager = new DbManager<Settings>();
            List<Settings> settingsList = dbManager.GetAll().Result.ToList();
            if (settingsList.Count > 0)
            {
                Settings settings = settingsList[0];
                string strimg = settings._imagesource;
                ImageSource = strimg;
                _imageSource = ImageSource;
                TextProperty = "Hai Welcome";
            } 
           
        }
    }
}
