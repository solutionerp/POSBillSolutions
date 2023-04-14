using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class budget_trans: DomainObject
    {
        public string id { get; set; }
        public DateOnly tran_date { get; set; }
        public string account { get; set; }
        public string memo_ { get; set; } 
        public double amount { get; set; }
        public int dimension_id { get; set; }
        public int dimension2_id { get;set; }
    }
}
