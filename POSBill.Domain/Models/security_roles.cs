using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class security_roles : DomainObject
    {
        public string role { get; set; }
        public string description { get; set; }
        public string sections { get; set; }
        public string areas { get; set; }
        public  string inactive { get; set; }
    }
}
