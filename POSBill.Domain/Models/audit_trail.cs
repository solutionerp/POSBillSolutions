using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class audit_trail: DomainObject
    {
        public int id { get; set; }
        public int type { get; set; }
        public int trans_no { get; set; }
        public string user { get; set; }
        public TimestampAttribute stamp { get; set; }
        public string description { get; set; }
        public int fiscal_year { get; set; }
        public DateOnly gl_date { get; set; }
        public int gl_seq { get; set; }
    }
}
