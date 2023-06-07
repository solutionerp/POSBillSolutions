using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class Cart
    {
        public Customer custmerCart { get; set; }
        public User userCart { get; set; }
         
        public PosBillDetails[] posBillArray;
        public double AmountTotal { get; set; }
        public double order { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime strDate { get; set; }
        public string strCartPaymentMethod { get; set; }
        
    }
}
