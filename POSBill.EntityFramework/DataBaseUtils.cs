using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace POSBill.EntityFramework
{
    public class DataBaseUtils
    {
        #region DataSetGetRecords
        public DataSet GetRecord(string strQuery)
        {
            try
            {
                var connection = new MySqlConnection("Server=localhost;Database=reference_db;Uid=root;Pwd=1234");
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, connection))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured", ex);
            }
        }
        #endregion

        #region GetDecimalRecord
        public decimal GetDecimalRecord(string strQuery)
        {
            try
            {
                var connection = new MySqlConnection("Server=localhost;Database=reference_db;Uid=root;Pwd=1234");
                using (MySqlCommand command = new MySqlCommand(strQuery, connection))
                {
                    connection.Open();
                    decimal result = (decimal)command.ExecuteScalar();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured", ex);
            }
        } 
        #endregion
        public object ExecuteScalar(string strQuery)
        {
            try
            {
                using (var connection = new MySqlConnection("Server=localhost;Database=reference_db;Uid=root;Pwd=1234"))
                {
                    connection.Open();
                    var command = new MySqlCommand(strQuery, connection);
                    return command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured", ex);
            }
        }
        public void ExecuteQuery(string strQuery) 
        {
            try
            {
                using (var connection = new MySqlConnection("Server=localhost;Database=reference_db;Uid=root;Pwd=1234"))
                {
                    connection.Open();
                    var command = new MySqlCommand(strQuery, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured", ex);
            }
        }
    }
}
