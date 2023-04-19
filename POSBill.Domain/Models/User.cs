using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class User : DomainObject
    {
        public string user_id { get; set; }
        public string password { get; set; }


        public override string GetSelectAllQuery()
        {
            return "SELECT * FROM reference_db.0_users";
        }
        public override async Task<IEnumerable<T>> ToArray<T>(DataSet dataSet)
        {
            List<User> users = new List<User>();
            if (dataSet.Tables[0].Rows.Count > 0) 
            {
                foreach(DataRow row in dataSet.Tables[0].Rows) 
                {
                    var user = new User
                    {
                        user_id = (string)row["user_id"],
                        password = (string)row["password"]
                    };
                    users.Add(user);
                }
            }
            return await Task.FromResult<IEnumerable<T>>(users as IEnumerable<T>);
        }
    }
}
