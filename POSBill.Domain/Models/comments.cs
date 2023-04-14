using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class comments: DomainObject
    {
        public int type { get; set; }
        public int id { get; set; } 
        public DateOnly date_ { get; set; }   
        public string memo_ { get; set; }    

    }
}
