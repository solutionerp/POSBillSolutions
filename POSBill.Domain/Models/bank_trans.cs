using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class bank_trans : DomainObject
    {
        public int id { get; set; }
        public int type { get; set; }
        public int trans_no { get; set; }
        public string bank_act { get; set; }
        public string refno{get;set;}
        public DateOnly trans_date { get; set; }
        public double amount { get; set; }
        public int dimension_id { get; set; }
        public int dimension2_id { get; set; }
        public int person_type_id { get; set; }
        public int person_id { get; set; }
        public int reconciled { get; set; }

    }
}
