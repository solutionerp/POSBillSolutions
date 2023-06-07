using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class PosBillDetails
    {
        public string strPosItemName { get; set; }
        public string strPosItemCode { get ; set; } 
        public string strPosQty { get; set; }
        public string strPrice { get; set; }
        public string strDscount { get; set; }
        public string strTotal { get; set; }
    }
}
