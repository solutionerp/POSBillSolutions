using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class User : DomainObject
    {
        public string user_id { get; set; }
        public string password { get; set; }
        public string real_name { get; set; }
        public int role_id { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string language { get; set; }
        public int date_format { get; set; }
        public int date_sep { get; set; }
        public int tho_sep { get; set; }
        public int dec_sep { get; set; }
        public string theme { get; set; }
        public string page_size { get; set; }
        public int prices_dec { get; set; }
        public int qty_dec { get; set; }
        public int rates_dec { get; set; }
        public int percent_dec { get; set; }
        public int show_gl { get; set; }
        public int show_codes { get; set; }
        public int show_hints { get; set; }
        public DateTime last_visit_date { get; set; }
        public int query_size { get; set; }
        public int graphic_links { get; set; }
        public int pos { get; set; }
        public int print_profile { get; set; }
        public int rep_popup { get; set; }
        public int sticky_doc_date { get; set; }
        public string startup_tab { get; set; }
        public int transaction_days { get; set; }
        public int save_report_selections { get; set; }
        public int use_date_picker { get; set; }
        public int def_print_destination { get; set; }
        public int def_print_orientation { get; set; }
        public int inactive { get; set; }
    }
}
