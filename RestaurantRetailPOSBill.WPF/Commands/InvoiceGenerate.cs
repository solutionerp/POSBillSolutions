using POSBill.Domain.Models;
using POSBill.EntityFramework;
using RestaurantRetailPOSBill.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace RestaurantRetailPOSBill.WPF.Commands
{
 public class InvoiceGenerate
    {
        public void GenerateInvoice(string strPaymentMethod)
        {
            Cart cartnew = new Cart();
            Invoice invoice = new Invoice();


            #region Array
            //foreach (PosBillDetails item in ArrayGridItems)
            //{
            //    // Access properties of the item and process as needed
            //     itemName = item.strPosItemName;
            //     quantity = item.strPosQty;
            //     price = item.strPrice;
            //     discount = item.strDscount;
            //     total = item.strTotal;
            //} 
            #endregion

            SaveInvoice(cartnew);
            PrintInvoice(invoice);
        }
        private string GetCustomerName()
        {
            string strCustomer = "";
            Customer customerDetails = new Customer();
            strCustomer = customerDetails.customer_name;
            return strCustomer;
        }
        private int GenerateInvoiceNumber()
        {
            return 1234;
        }
        private void SaveInvoice(Cart cart)
        {
            
        }
        #region PrintInvoice
        private void PrintInvoice(Invoice invoice)
        {
            try
            {

                PrintDocument printDocument = new PrintDocument();
                printDocument.DocumentName = "Invoice";
                string strPrinterName = "";
                DbManager<DefaultPrinterSettings> dbManagerDefaultPrinter = new DbManager<DefaultPrinterSettings>();
                List<DefaultPrinterSettings> defaultprinterSettingsList = dbManagerDefaultPrinter.GetAll().Result.ToList();
                if (defaultprinterSettingsList != null)
                {
                    foreach (DefaultPrinterSettings settings in defaultprinterSettingsList)
                    {
                        strPrinterName = settings._value.ToString();
                    }
                }
                printDocument.PrintPage += (sender, e) =>
            {

                string content = $"Invoice Number: {invoice.InvoiceNumber}\n" +
                                 $"Date: {invoice.Date}\n" +
                                 $"Customer Name: {invoice.CustomerName}";


                Font font = new Font("Arial", 12);
                SolidBrush brush = new SolidBrush(Color.Black);
                float x = 10, y = 10;
                e.Graphics.DrawString(content, font, brush, x, y);
            };
                printDocument.PrinterSettings.PrinterName = strPrinterName;
                printDocument.Print();

            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        } 
        #endregion
    }
}
