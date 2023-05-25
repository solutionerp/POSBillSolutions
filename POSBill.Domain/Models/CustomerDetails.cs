using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class CustomerDetails : DomainObject
    {
        public string customer_currency { get; set; }
        public string default_discount { get; set; }
        public string customer_name { get; set; }
        public string customer_id { get; set; }
        public string Branch { get; set; }
        public string email { get; set; }
        public string address { get; set; }    
        public string phone { get;set; }
        public string cust_ref { get; set; }
        public string taxgroup_id { get; set; }
        public string payment_terms { get; set; }
        public string sales_type { get; set; }

        public override string GetInsertQuery()
        {
            throw new NotImplementedException();
        }

        public override string GetSelectAllQuery()
        {
            throw new NotImplementedException();
        }

        public override string GetUpdateQuery(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<T>> ToArray<T>(DataSet dataSet)
        {
            throw new NotImplementedException();
        }
    }
}
