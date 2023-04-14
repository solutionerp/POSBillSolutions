using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class areas: DomainObject
    {
        public int area_code { get; set; }
        public string description { get; set; }
        public int inactive { get; set; }
    }
}
