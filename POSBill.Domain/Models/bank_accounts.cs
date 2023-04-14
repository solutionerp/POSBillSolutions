using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class bank_accounts : DomainObject
    {
        public string account_code { get; set; }
        public int account_type { get; set; }
        public string bank_account_name { get; set;}
        public string bank_account_number { get; set; }
        public string bank_name { get; set; }
        public string bank_address { get; set;}
        public string bank_curr_code { get; set;}
        public int dflt_curr_act { get;set; }
        public int id { get; set;}
        public string bank_charge_act { get; set; }
        public string last_reconciled_date { get; set; }
        public double ending_reconcile_balance { get; set; }
        public int inactive { get; set; }

    }
}
