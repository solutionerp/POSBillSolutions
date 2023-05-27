using Microsoft.EntityFrameworkCore.Metadata.Internal;
using POSBill.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.EntityFramework
{
    public class POSBillDbManager : DataBaseManager
    {
        #region SelectStockItems
        public DataSet SelectStockItems(string strSuggestionData)
        {
            try
            {
                string strStockId = strSuggestionData;
                string strItemcode = strSuggestionData;
                string strQuery = "SELECT" +
                                  " i.item_code, i.description, s.stock_id,p.price " + "FROM "
                                  + " 0_prices p join  0_stock_master s on p.stock_id = s.stock_id Join 0_item_codes i on s.stock_id = i.stock_id WHERE " + "( s.description LIKE " + "'%" + strSuggestionData + "%'" + " OR i.item_code LIKE " + "'%" + strSuggestionData + "%') limit 10";
                DataSet dataSet = DataBaseUtils.GetRecord(strQuery);
                return dataSet;
            }
          catch(Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        #endregion

        #region GetCustomerDeatils
        public DataSet GetCustomerDeatils(string strCustomer)
        {
            try
            {
                string strQuery = "SELECT" +
                                  " name,debtor_no, address,debtor_ref " + "FROM "
                                  + "0_debtors_master " + " where name like "
                                  + "'%" + strCustomer + "%'" + " limit 5";
                DataSet dataSet = DataBaseUtils.GetRecord(strQuery);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        } 
        #endregion

        #region GetItemKit
        public DataSet GetItemKit(string itemcode)
        {
            try
            {
                string strQuery = "SELECT DISTINCT kit.*, item.units, comp.description as comp_name"
                                    + " FROM 0_item_codes kit, 0_item_codes comp"
                                    + " LEFT JOIN 0_stock_master item"
                                    + " ON item.stock_id = comp.item_code"
                                    + " WHERE kit.stock_id = comp.item_code"
                                    + " AND kit.item_code =" + "'"+ itemcode + "'";
                DataSet dataSet = DataBaseUtils.GetRecord(strQuery);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        } 
        #endregion

        #region GetSalesType
        public DataSet GetSalesType(int iSalesTypeid)
        {
            try
            {
                string strQuery = "SELECT * FROM 0_sales_types where id = " + "'" + iSalesTypeid + "'";
                DataSet dataSet = DataBaseUtils.GetRecord(strQuery);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        #endregion

        #region GetCompanyPref
        public DataSet GetCompanyPref(string strAddPct)
        {
            try
            {
                
                    string strQuery = "SELECT * FROM 0_sys_prefs where name = " + "'" + strAddPct + "'";
                    DataSet dataSet = DataBaseUtils.GetRecord(strQuery);
                    return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        #endregion

        #region GetBaseSalesType
        public DataSet GetBaseSalesType()
        {
            try
            {
                string strQuery = "SELECT * FROM 0_sales_types";
                DataSet dataSet = DataBaseUtils.GetRecord(strQuery);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        #endregion

        #region GetCompanyCurrency
        public DataSet GetCompanyCurrency()
        {
            try
            {
                string strQuery = "SELECT value FROM 0_sys_prefs where name = 'curr_default'";
                DataSet dataSet = DataBaseUtils.GetRecord(strQuery);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        #endregion

        #region GetItemPrice
        public DataSet GetItemPrice(string iStockid, string strCurrency, string strHomeCurrency)
        {
            try
            {
                string strQuery = "SELECT price, curr_abrev, sales_type_id FROM 0_prices WHERE stock_id =" + "'" + iStockid + "'" + "AND (curr_abrev =" + "'" + strCurrency + "'" + " OR curr_abrev =" + "'" + strHomeCurrency + "'" + " )";
                DataSet dataSet = DataBaseUtils.GetRecord(strQuery);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        #endregion

        #region getCompanyPrefRountTo
        public DataSet GetCompanyPrefRounTo(string strRoundTo)
        {
            try
            {
                string strQuery = "SELECT * FROM 0_sys_prefs where name = " + "'" + strRoundTo + "'";
                DataSet dataSet = DataBaseUtils.GetRecord(strQuery);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        #endregion

        #region GetUnitCost
        public decimal GetUnitCost(string iStockId)
        {
            try
            {
                string strQuery = "SELECT material_cost FROM 0_stock_master where stock_id =" + "'" + iStockId + "'";
                decimal dMaterialPrice = DataBaseUtils.GetDecimalRecord(strQuery);
                return dMaterialPrice;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        #endregion

        #region GetSalesTypeId
        public DataSet GetSalesTypeId(string strPos)
        {
            try
            {
                string strQuery = "select s.* from 0_sales_pos s where s.id =" + "'"+ strPos + "'";
                DataSet dataSet = DataBaseUtils.GetRecord(strQuery);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        #endregion

        #region GetSalesTypeIdDeoptMaster
        public DataSet GetSalesTypeIdDeoptMaster(string strPos)
        {
            try
            {
                string strQuery = "select s.def_cust,d.* from 0_sales_pos s join 0_debtors_master d on (s.def_cust = d.debtor_no) where s.id = " + "'"+ strPos + "'";
                DataSet dataSet = DataBaseUtils.GetRecord(strQuery);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        #endregion

        #region GetItemNameByItemCode
        public DataSet GetItemNameByItemCode(string strItemCode)
        {
            try
            {
                string strQuery = "SELECT * FROM 0_item_codes where item_code = " + "'" + strItemCode + "'";
                DataSet dataset = DataBaseUtils.GetRecord(strQuery);
                return dataset;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        #endregion

        #region GetDeptNoByName
        public object GetDeptNoByName(string strCustomerName)
        {
            try
            {
                string strQuery = "SELECT debtor_no FROM 0_debtors_master where name = " + "'" + strCustomerName + "'";
                object objDeptNo = DataBaseUtils.ExecuteScalar(strQuery);
                return objDeptNo;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        } 
        #endregion
    }
}
