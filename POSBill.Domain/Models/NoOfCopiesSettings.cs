using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class NoOfCopiesSettings: DomainObject
    {
        public NoOfCopiesSettings() 
        {
            _name = "NoOfCopies_settings";
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
            return "SELECT * FROM reference_db.0__sys_prefs where name = 'NoOfCopies_settings'";
        }

        public override string GetUpdateQuery(string id)
        {
            return "update 0__sys_prefs set value = '" + _value + "' where name = 'NoOfCopies_settings'";
        }

        public override async Task<IEnumerable<T>> ToArray<T>(DataSet dataSet)
        {
            List<NoOfCopiesSettings> noOfCopiesSettings = new List<NoOfCopiesSettings>();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    string strdefaultPrinterValue = row["value"].ToString();
                    NoOfCopiesSettings noOfCopiesSetting = new NoOfCopiesSettings();
                    noOfCopiesSetting._value = strdefaultPrinterValue;
                    noOfCopiesSettings.Add(noOfCopiesSetting);
                }
            }
            return await Task.FromResult<IEnumerable<T>>(noOfCopiesSettings as IEnumerable<T>);
        }
    }
}
