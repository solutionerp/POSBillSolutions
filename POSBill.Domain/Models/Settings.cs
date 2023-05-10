using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class Settings:DomainObject
    { 
        public string _imagesource { get; set; }
        public override string GetSelectAllQuery()
        {
            return "SELECT * FROM reference_db.0__sys_prefs where name = 'coy_logo'";
        }
        public override string GetUpdateQuery(string id)
        {
            _imagesource = _imagesource.Replace("\\", "\\\\");
            return "Update 0__sys_prefs set value = '" + _imagesource + "'" + " where name = 'coy_logo'";
        } 
        public override string GetInsertQuery()
        {
            return "insert into 0__sys_prefs " + "(coy_logo) " + "Values " + "('" +_imagesource+"')";
        }
        public override async Task<IEnumerable<T>> ToArray<T>(DataSet dataSet)
        {
            string strImgSource = "";
            List<Settings> setting = new List<Settings>();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    strImgSource = row["value"].ToString();
                    Settings settings = new Settings();
                    settings._imagesource = strImgSource;
                    setting.Add(settings);
                }
            }
            return await Task.FromResult<IEnumerable<T>>(setting as IEnumerable<T>);
        }
    }
}
