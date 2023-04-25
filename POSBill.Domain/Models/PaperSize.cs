using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class PaperSize : DomainObject
    {
        public PaperSize() 
        {
            _name = "papersize_settings";
        }
        public string _name { get; set; }
        public string _category { get; set; }
        public string _type { get; set; }
        public int _length { get; set; }
        public string _value { get; set; }

        public override string GetInsertQuery()
        {
            return "insert into 0_sys_prefs  (name,category,type,length,value) Values ('"+ _name + "' , '', '',0,'"+ _value + "')";
        }

        public override string GetSelectAllQuery()
        {
            return "SELECT * FROM reference_db.0_sys_prefs where name = 'papersize_settings'";
        }

        public override string GetUpdateQuery(string id)
        {
            return "update 0_sys_prefs set value = '" + _value + "' where name = 'papersize_settings'";
        }

        public override async Task<IEnumerable<T>> ToArray<T>(DataSet dataSet)
        {
            List<PaperSize> paperSize = new List<PaperSize>();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    string strPapersizeValue = row["value"].ToString();
                    PaperSize paperSizes = new PaperSize();
                    paperSizes._value = strPapersizeValue;
                    paperSize.Add(paperSizes);
                }
            }
            return await Task.FromResult<IEnumerable<T>>(paperSize as IEnumerable<T>);
        }
    }
}
