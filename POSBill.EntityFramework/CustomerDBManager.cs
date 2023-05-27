using POSBill.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.EntityFramework
{
    public class CustomerDBManager : DbManager<Customer>
    {
        #region CustomerDetailsByDeptNo
        public Customer CustomerDetailsByDeptNo(string strDeptNo)
        {
            try
            {
                string strQuery = string.Format("SELECT " +
                                    "d.name, " +
                                    "d.address, " +
                                    "d.discount," +
                                    "d.payment_terms," +
                                    "d.sales_type, " +
                                    "c.br_name," +
                                    "c.tax_group_id," +
                                    "d.debtor_ref," +
                                    "p.address," +
                                    "p.email," +
                                    "p.id," +
                                    "p.phone," +
                                    "d.curr_code" +
                                    " FROM " +
                                    "0_debtors_master d " +
                                    "JOIN " +
                                   "0_cust_branch c ON (d.debtor_no = c.debtor_no)" +
                                   "LEFT JOIN " +
                                   "0_crm_persons p ON (d.debtor_ref = p.ref)" +
                                   "WHERE " +
                                   "d.debtor_no = {0}", strDeptNo);
                var customer = GetByQuery(strQuery).Result.ToList();
                if (customer.Count > 0)
                {
                    return customer[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        } 
        #endregion
    }
}
