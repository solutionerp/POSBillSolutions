using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class MarginLeftSettings : DomainObject
    {
        public MarginLeftSettings() 
        {
            _name = "margin_left_settings";
        }
        public string _name { get; set; }
        public string _category { get; set; }
        public string _type { get; set; }
        public int _length { get; set; }
        public string _value { get; set; }

        public override string GetInsertQuery()
        {
            return "insert into 0__sys_prefs  (name,category,type,length,value) Values ('" + _name + "' , '', '',0,'" + _value + "')";
        }

        public override string GetSelectAllQuery()
        {
            return "SELECT * FROM reference_db.0__sys_prefs where name = 'margin_left_settings'";
        }

        public override string GetUpdateQuery(string id)
        {
            return "update 0__sys_prefs set value = '" + _value + "' where name = 'margin_left_settings'";
        }

        public override async Task<IEnumerable<T>> ToArray<T>(DataSet dataSet)
        {
            List<MarginLeftSettings> marginLeft = new List<MarginLeftSettings>();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    string strMarginLeftValue = row["value"].ToString();
                    MarginLeftSettings marginLefts = new MarginLeftSettings();
                    marginLefts._value = strMarginLeftValue;
                    marginLeft.Add(marginLefts);
                }
            }
            return await Task.FromResult<IEnumerable<T>>(marginLeft as IEnumerable<T>);
        }
    } 
}
