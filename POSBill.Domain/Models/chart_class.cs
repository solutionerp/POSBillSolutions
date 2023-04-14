using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class chart_class: DomainObject
    {
        public string cid { get; set; }
        public string class_name { get; set; }
        public int ctype { get; set; }
        public int inactive { get; set;}
    }
}
