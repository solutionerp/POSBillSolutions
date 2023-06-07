using IronPdf;
using POSBill.Domain.Models;
using POSBill.EntityFramework;
using QuestPDF.Helpers;
using RestaurantRetailPOSBill.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using QuestPDF.Infrastructure;
using System.Net.Http;
using QuestPDF.Fluent;
using QuestPDF;
using RestaurantRetailPOSBill.WPF.Models;

namespace RestaurantRetailPOSBill.WPF.Commands 
{
 public class InvoiceGenerate 
    {
        public int m_transtype;

        #region GenerateInvoice
        public void GenerateInvoice(Cart cart)
        {
            // Cart cartnew = new Cart();
            string strPaymentMethod = cart.strCartPaymentMethod;
            Invoice invoice = new Invoice();
            cart.InvoiceNumber = "3333";
            cart.strDate = DateTime.Now;
            if (strPaymentMethod == "cash")
            {
                m_transtype = 10;
            }
            else if (strPaymentMethod == "card")
            {
                m_transtype = 10;
            }
            // SaveInvoice(cart);
            // PrintInvoices(cart);
            Print(cart);
        } 
        #endregion

        #region SaveInvoice
        private void SaveInvoice(Cart cart)
        {
            try
            {
                // Invoice invoice = new Invoice();
                m_transtype = 10;
                PosBillDetails[] itemarray = cart.posBillArray;
                POSBillDbManager pOSBillDbManager = new POSBillDbManager();
                string strCustName = cart.custmerCart.customer_name;
                string strCustRef = cart.custmerCart.cust_ref;
                string strCustCurency = cart.custmerCart.customer_currency;
                string strPaymentTerms = cart.custmerCart.payment_terms;
                string strDiscount = cart.custmerCart.default_discount;
                string strDeptNo = cart.custmerCart.cust_deptNo;
                string strnotes = "";
                string strTransNo = "";
                int iSrcId = 0;
                int iDeptno = 0;
                string strTransDate = "";
                string strDueDate = "";
                double ovAmount = cart.AmountTotal;
                double ovOrder = cart.order;
                //object objdeptno = pOSBillDbManager.SaveDeptormaster(strCustName, strCustRef, strCustCurency, strPaymentTerms, strDiscount, strnotes);
                //if (objdeptno != null)
                //{
                iDeptno = Convert.ToInt32(strDeptNo);
                double dDiscount = Convert.ToDouble(strDiscount);
                //}
                //object objectTransNo = pOSBillDbManager.SaveDeptTransDetails(m_transtype, iDeptno, strTransDate, strDueDate, ovOrder, ovAmount, dDiscount, strnotes);
                //if (objectTransNo != null)
                //{
                //    strTransNo = objectTransNo.ToString();
                //    cart.InvoiceNumber = strTransNo;
                //}
                foreach (PosBillDetails details in itemarray)
                {
                    string strItemCode = details.strPosItemCode;
                    string strItemName = details.strPosItemName;
                    string strQty = details.strPosQty;
                    string strPrice = details.strPrice;
                    strDiscount = details.strDscount;
                    string strtotal = details.strTotal;
                    object objectTransNo = pOSBillDbManager.SaveDeptTransDetails(m_transtype, iDeptno, strTransDate, strDueDate, ovOrder, ovAmount, dDiscount, strnotes, strItemCode, strItemName, strPrice, strQty, iSrcId);
                    // pOSBillDbManager.SaveInvoiceItems(strTransNo, strItemCode, strItemName, strPrice, strQty, iSrcId);
                }
                PrintInvoice(cart);
            }

            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }

        } 
        #endregion

        #region PrintInvoice
        private void PrintInvoice(Cart cart)
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
                e.PageSettings.PaperSize = new PaperSize("Invoice", 58, 200);

                string[] headers = { "Item Name", "Quantity", "Price", "Discount", "Total" };

                //Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                //SolidBrush headerBrush = new SolidBrush(Color.Black);

                string content = $"Invoice Number: {cart.InvoiceNumber}\n" +
                             $"Date: {cart.strDate}\n" +
                              $"Payment: {cart.strCartPaymentMethod}\n" +
                             $"Customer Name: {cart.custmerCart.customer_name}\n\n" +
                             "--------------------------------\n";
                List<string[]> rows = new List<string[]>();
                // Add table rows for each item in the cart
                foreach (PosBillDetails details in cart.posBillArray)
                {

                    string strItemCode = details.strPosItemCode;
                    string strItemName = details.strPosItemName;
                    string strQty = details.strPosQty;
                    string strPrice = details.strPrice;
                    string strDiscount = details.strDscount;
                    string strTotal = details.strTotal;
                    string[] row = {
                        details.strPosItemCode,
                        details.strPosItemName,
                        details.strPosQty,
                        details.strPrice,
                        details.strDscount,
                        details.strTotal
                };
                    rows.Add(row);
                    //  content += $"{strItemCode}\t\t{strItemName}\t\t{strQty}\t\t{strPrice}\t\t{strDiscount}\t\t{strTotal}\n";
                }
                Font font = new Font("Arial", 12);
                int maxCharsPerLine = (int)(58 / font.SizeInPoints);
                int totalLines = (int)Math.Ceiling((double)content.Length / maxCharsPerLine);
                SolidBrush brush = new SolidBrush(Color.Black);
                float x = 10, y = 10;
               // e.Graphics.DrawString(content, font, brush, x, y);

                int cellPadding = 5;
                Font headerFont = new Font("Arial", 3, FontStyle.Bold);
                Font cellFont = new Font("Arial", 2);
                SolidBrush headerBrush = new SolidBrush(Color.Black);
                SolidBrush cellBrush = new SolidBrush(Color.Black);
                Pen pen = new Pen(Color.Black);
                x = 10;
                y = 80;
                for (int line = 0; line < totalLines; line++)
                {
                    int startIndex = line * maxCharsPerLine;
                    int length = Math.Min(maxCharsPerLine, content.Length - startIndex);
                    string lineContent = content.Substring(startIndex, length);

                    e.Graphics.DrawString(lineContent, font, brush, 10, line * 50); // Adjust the Y position (12) as needed
                }
                //for (int i = 0; i < headers.Length; i++)
                //{
                //    RectangleF headerRect = new RectangleF(x, y, 100, 20);
                //    e.Graphics.DrawString(headers[i], headerFont, headerBrush, headerRect);
                //    x += 100;
                //}
                //y += 20;
                //foreach (string[] row in rows)
                //{
                //    x = 10;
                //    for (int i = 0; i < row.Length; i++)
                //    {
                //        RectangleF cellRect = new RectangleF(x, y, 100, 20);
                //        e.Graphics.DrawString(row[i], cellFont, cellBrush, cellRect);
                //        x += 100;
                //    }
                //    y += 20;
                //}

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

        #region PrintInvoices
        public void PrintInvoices(Cart cart)
        {
            try
            {
                string htmlContent = $@"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset='UTF-8'>
                <style>
                    /* CSS styles for the invoice */
                    /* Define your own styles here */
                    body {{
                        font-family: Arial, sans-serif;
                        margin: 0;
                        padding: 0;
                    }}

                    .invoice {{
                        width: 58mm; /* Adjust the width as per your requirement */
                        margin: 0 auto;
                        padding: 10px;
                        background-color: #f8f8f8;
                        border: 1px solid #ccc;
                    }}

                    .invoice h1 {{
                        font-size: 16px;
                        text-align: center;
                        margin: 0;
                        padding: 5px 0;
                    }}

                    .invoice .header p {{
                        margin: 0;
                        font-size: 10px;
                    }}

                    .invoice .details p {{
                        margin: 0;
                        font-size: 10px;
                    }}

                    .invoice .items table {{
                        width: 100%;
                        border-collapse: collapse;
                        font-size: 10px;
                        border: none; /* Remove the border */
                    }}
                    .invoice .items th {{
                        padding: 5px;
                        font-size: 8px;
                    }}
                    
                    .invoice .items td{{
                        padding: 5px;
                        font-size: 5px;
                    }}
                    .invoice .items tr {{
                    padding: 5px;
                    font-size: 6px;
                }}
                  
            .invoice .items thead tr:last-child th {{
                    border-bottom: 1px dotted #ccc;
                }}
                    .invoice .total {{
                        text-align: right;
                        font-size: 5px;
                    }}
                </style>
            </head>
            <body>
                <div class='invoice'>
                    <p>----------------------------------------</p>
                    <p>Sales Invoice Copy</p>
                    <p>----------------------------------------</p>
                    <div class='details'>
                        <p>Invoice Number: {cart.InvoiceNumber}</p>
                         <p>Date: {cart.strDate.ToString("MMMM d, yyyy")}</p>
                         <p>Due Date: {cart.strDate.AddDays(14).ToString("MMMM d, yyyy")}</p>
                         <p>Payment Type: {cart.strCartPaymentMethod}</p>
                         <p>---------------------------------------------------------------</p>
                    </div>
                    <div class='items'>
                    <table>
                     <thead>
                      <tr>
                        <th>Description</th>
                        <th>Quantity</th>
                        <th>Price</th>
                        <th>Total</th>
                      </tr>
                      <tr>
             <td colspan='4' style='border-bottom: 1px dotted;'> </td>
        </tr>
                      </thead>
                       <tbody> 
               ";

               // Generate table rows dynamically based on the data in cart.posBillArray
                                foreach (PosBillDetails details in cart.posBillArray)
                                     {
                                        htmlContent += $@"

                                         <tr>
                                         <td>{details.strPosItemName}</td>
                                         <td>{details.strPosQty}</td>
                                         <td>${details.strPrice}</td>
                                         <td>${details.strTotal}</td>
                                         </tr>
                ";
                  
                                     }


                htmlContent += $@"

                           </tbody> 
                     </table>
                    </div>
                 </div>
               </body>
            </html>";
                var renderer = new IronPdf.HtmlToPdf();
                var printOptions = renderer.PrintOptions;
                printOptions.MarginTop = 0;
                printOptions.MarginBottom = 0;
                printOptions.MarginLeft = 0;
                printOptions.MarginRight = 0;
                printOptions.SetCustomPaperSizeinMilimeters(58, 100);
                var pdf = renderer.RenderHtmlAsPdf(htmlContent);
                pdf.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occurred", ex);
            }
        } 
        #endregion

        public void Print (Cart cart)
        {
            try
            {
                var filePath = "invoice.pdf";

                var model = cart;
                var document =new InvoiceDocument(model);
                document.GeneratePdf(filePath);
                Process.Start("explorer.exe", filePath);

            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occurred", ex);
            }
        }

        public void Printf(Cart cart)
        {
            try
            {
           //     DocumentBuilder
           //.New()
           //.AddSection(section =>
           //{
           //    section
           //        .PageOrientation(PageOrientation.Portrait)
           //        .PageSize(PageSizes.A4)
           //        .Margin(50)
           //        .Header().AlignCenter().Text("Sample PDF").End()
           //        .Content()
           //        .Html(@"<h1>Hello, World!</h1><p>This is a sample HTML content.</p>");
           //})
           //.Save("output.pdf");
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occurred", ex);
            }
        }
    }
}
