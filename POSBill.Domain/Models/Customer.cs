using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class Customer : DomainObject
    {
        public string customer_currency { get; set; }
        public string cust_deptNo { get;set; }
        public string customer_GstNo { get; set; }
        public string default_discount { get; set; }
        public string customer_name { get; set; }
        public string customer_id { get; set; }
        public string Branch { get; set; }
        public string email { get; set; }
        public string address { get; set; }    
        public string phone { get;set; }
        public string cust_ref { get; set; }
        public string taxgroup_id { get; set; }
        public string payment_terms { get; set; }
        public string sales_type { get; set; }
        public string credit_status { get; set; }
        public string Shipping_copmany { get;set; }
        public string Sales_Area { get; set; }
        public string Sale_person { get;set; }
        public override string GetInsertQuery()
        {
            throw new NotImplementedException();
        }

        public override string GetSelectAllQuery()
        {
            throw new NotImplementedException();
        }

        public override string GetUpdateQuery(string id)
        {
            throw new NotImplementedException();
        }

        public override  async Task<IEnumerable<T>> ToArray<T>(DataSet dataSet)
        {
            try
            {
                List<Customer> customers = new List<Customer>();
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        string strCuurency = row["curr_code"].ToString();
                        string strDefaultDiscount = row["discount"].ToString();
                        string strCustomerName = row["name"].ToString();
                        string strCustId = row["id"].ToString();
                        string strBranch = row["br_name"].ToString();
                        string strEmail= row["email"].ToString();
                        string strAddress = row["address"].ToString();
                        string strPhone = row["phone"].ToString();
                        string strtaxGroupId = row["tax_group_id"].ToString();
                        string strPaymentTerms = row["payment_terms"].ToString();
                        string strSalestype = row["sales_type"].ToString();
                        var customer = new Customer
                        {
                            customer_currency = strCuurency,
                            default_discount = strDefaultDiscount,
                            customer_name=strCustomerName,
                            customer_id = strCustId,
                            Branch = strBranch,
                            email = strEmail,
                            address = strAddress,
                            phone = strPhone,
                            taxgroup_id = strtaxGroupId,
                            payment_terms = strPaymentTerms,
                            sales_type = strSalestype
                        };
                        customers.Add(customer);
                    }
                }
                return await Task.FromResult<IEnumerable<T>>(customers as IEnumerable<T>);
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
    }
}
