using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class chart_master: DomainObject
    {
        public string account_code { get; set; }    
        public string account_code2 { get; set;}
        public string account_name { get; set; } 
        public int inactive { get; set; } 
    }
}
