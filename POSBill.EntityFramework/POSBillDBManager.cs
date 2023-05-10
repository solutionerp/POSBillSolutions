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
                                  + " 0_prices p join  0_stock_master s on p.stock_id = s.stock_id Join 0_item_codes i on s.stock_id = i.stock_id WHERE " + "( s.description LIKE " + "'%" + strSuggestionData + "%'" + " OR i.item_code LIKE " + "'%" + strSuggestionData + "%') ";
                DataSet dataSet = DataBaseUtils.GetRecord(strQuery);
                return dataSet;
            }
          catch(Exception ex)
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
                string strQuery = "";
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
                string strQuery = "select s.* from 0_sales_pos s where s.price_list =" + "'"+ strPos + "'" + "and s.price_list =" + "'"+0+"'";
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
                string strQuery = "select s.def_cust,d.* from 0_sales_pos s join 0_debtors_master d where s.price_list ="+ "'"+ strPos + "'";
                DataSet dataSet = DataBaseUtils.GetRecord(strQuery);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        } 
        #endregion
    }
}
