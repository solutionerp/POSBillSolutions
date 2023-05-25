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
        public string strPos { get;set; }
        public int m_QtyDecimal { get; set; }
        public int m_PriceDecimal { get; set; }
        public int m_PerncetageDecimal { get; set; }


        public override string GetUpdateQuery(string id)
        {
            throw new NotImplementedException();
        }
        public override string GetInsertQuery()
        {
            throw new NotImplementedException();
        }
        public override string GetSelectAllQuery()
        {
            return "SELECT * FROM reference_db.0_users";
        }

        #region ToArray
        public override async Task<IEnumerable<T>> ToArray<T>(DataSet dataSet)
        {
            try
            {
                List<User> users = new List<User>();
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        string strPosValue = row["pos"].ToString();
                        int strQtyDecimal = Convert.ToInt32(row["qty_dec"]);
                        int strPriceDecimal =Convert.ToInt32 (row["prices_dec"]);
                        int strPercentageDecimal =Convert.ToInt32 (row["percent_dec"]);
                        var user = new User
                        {
                            user_id = (string)row["user_id"],
                            password = (string)row["password"],
                            strPos = strPosValue,
                            m_QtyDecimal = strQtyDecimal,
                            m_PriceDecimal = strPriceDecimal,
                            m_PerncetageDecimal = strPercentageDecimal
                        };
                        users.Add(user);
                    }
                }
                return await Task.FromResult<IEnumerable<T>>(users as IEnumerable<T>);
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        } 
        #endregion

    }
}
