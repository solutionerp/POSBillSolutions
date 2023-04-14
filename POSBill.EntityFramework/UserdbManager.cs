using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Mysqlx.Prepare;
using POSBill.Domain.Models;
using POSBill.Domain.Services;
using POSBill.EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace POSBill.EntityFramework
{ 
    public class UserdbManager : DbManager<User>
    {
        public UserdbManager() 
        {
        }
        public List<User> GetUsers()
        {
            try
            {
                var users = new List<User>();
                DataBaseUtils dataBaseUtils = new DataBaseUtils();
                string strQuery = "SELECT * FROM reference_db.0_users";
                DataSet dataset = dataBaseUtils.GetRecord(strQuery);
                if (dataset.Tables[0].Rows.Count >0)
                {
                    foreach (DataRow row in dataset.Tables[0].Rows)
                    {
                        var user = new User
                        {
                            user_id = (string)row["user_id"],
                            password = (string)row["password"]
                        };
                        users.Add(user);
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
      
        public User GetUserByIdAndPassword(string strUserId,string strPassword)
        {
            string strQuery = string.Format("SELECT * FROM reference_db.0_users where user_id='{0}' and password='{1}'", strUserId, strPassword);
            var users = GetByQuery(strQuery).Result.ToList();
            if(users.Count > 0) 
            {
                return users[0];
            }
            return null;
        }

    }
}
