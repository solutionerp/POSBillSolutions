﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace POSBill.Domain.Models
{
    public class POSBillGrid : INotifyPropertyChanged
    {
        private string itemName;
        private string itemcode;
        private decimal quantity;
        private decimal price;
        private string discount;
        private decimal total;
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; NotifyPropertyChanged(); }
        }

        public decimal Quantity
        {
            get { return quantity; }
            set { quantity = value; NotifyPropertyChanged(); }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; NotifyPropertyChanged(); }
        }

        public string Discount
        {
            get { return discount; }
            set { discount = value; NotifyPropertyChanged(); }
        }
        public decimal Total
        {
            get { return total; }
            set { total = value; NotifyPropertyChanged(); }
        }

        public string Itemcode
        {
            get { return itemcode; }
            set { itemcode = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
