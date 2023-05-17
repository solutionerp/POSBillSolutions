using System;
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
        private int quantity;
        private double price;
        private string discount;
        private int total;
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; NotifyPropertyChanged(); }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; NotifyPropertyChanged(); }
        }

        public double Price
        {
            get { return price; }
            set { price = value; NotifyPropertyChanged(); }
        }

        public string Discount
        {
            get { return discount; }
            set { discount = value; NotifyPropertyChanged(); }
        }
        public int Total
        {
            get { return total; }
            set { total = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
