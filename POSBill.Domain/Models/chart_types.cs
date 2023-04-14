using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class chart_types: DomainObject
    {
        public string id { get; set; }    
        public string name { get; set; }
        public string class_id { get; set; }
        public string parent { get; set; }
        public int inactive { get; set; }  
    }
}
