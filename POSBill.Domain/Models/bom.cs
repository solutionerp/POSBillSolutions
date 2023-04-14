using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class bom : DomainObject
    {
        public int id { get; set; }
        public string parent { get; set; } 
        public string component { get; set; }    
        public int workcentre_added { get; set; }    
        public string loc_code { get; set; }
        public double quantity { get; set; }

    }
}
