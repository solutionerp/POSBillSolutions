using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class MarginBottomSettings : DomainObject
    {
        public MarginBottomSettings() 
        {
            _name = "MarginBottom_settings";
        }
        public string _name { get; set; }
        public string _category { get; set; }
        public string _type { get; set; }
        public int _length { get; set; }
        public string _value { get; set; }

        public override string GetInsertQuery()
        {
            return "insert into 0_sys_prefs  (name,category,type,length,value) Values ('" + _name + "' , '', '',0,'" + _value + "')";
        }

        public override string GetSelectAllQuery()
        {
            return "SELECT * FROM reference_db.0_sys_prefs where name = 'MarginBottom_settings'";
        }

        public override string GetUpdateQuery(string id)
        {
            return "update 0_sys_prefs set value = '" + _value + "' where name = 'MarginBottom_settings'";
        }
        public override async Task<IEnumerable<T>> ToArray<T>(DataSet dataSet)
        {
            List<MarginBottomSettings> marginBottom = new List<MarginBottomSettings>();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    string strMarginBottomValue = row["value"].ToString();
                    MarginBottomSettings marginBottoms = new MarginBottomSettings();
                    marginBottoms._value = strMarginBottomValue;
                    marginBottom.Add(marginBottoms);
                }
            }
            return await Task.FromResult<IEnumerable<T>>(marginBottom as IEnumerable<T>);
        }
    }
}
