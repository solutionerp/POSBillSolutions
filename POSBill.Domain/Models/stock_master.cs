using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class stock_master : DomainObject
    {
        public int stock_id { get; set; }
        public int category_id { get; set; }
        public int tax_type_id { get; set; }
        public string description { get; set; }
        public int long_description { get; set; }
        public string units { get; set; }
        public string mb_flag { get; set; }
        public string sales_account { get; set; }
        public string cogs_account { get; set; }
        public string inventory_account { get; set; }
        public string adjustment_account { get; set; }
        public string wip_account { get; set; }
        public int dimension_id { get; set; }

        public int dimension2_id { get; set; }
        public double purchase_cost { get; set; }
        public double material_cost { get; set; }
        public double labour_cost { get; set; }
        public double overhead_cost { get; set; }
        public int inactive { get; set; }
        public int no_sale { get; set; }
        public int no_purchase { get; set; }
        public int editable { get; set; }
        public string depreciation_method { get; set; }
        public double depreciation_rate { get; set; }
        public double depreciation_factor { get; set; }
        public DateOnly depreciation_start { get; set; }
        public DateOnly depreciation_date { get; set; }
        public DateOnly fa_class_id { get; set; }
    }
}
