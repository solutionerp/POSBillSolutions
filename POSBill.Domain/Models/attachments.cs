using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class attachments: DomainObject
    {
        public int id { get; set; }
        public string description { get; set; }
        public int type_no { get; set; }
        public int trans_no { get; set; }
        public string unique_name { get; set; }
        public DateOnly tran_date { get; set; }
        public string filename { get; set; }
        public int filesize { get; set; }
        public string filetype { get; set; }
    }
}
