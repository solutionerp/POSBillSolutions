﻿using POSBill.Domain.Models;
using POSBill.Domain.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.EntityFramework
{
    public class DbManager<T> : IDataServices<T> where T : class
    {
        public Task<T> Create(T entity)
        {
            try
            {
                DomainObject obj = entity as DomainObject;
                DataBaseUtils dataBaseUtils =new DataBaseUtils();
                string strQuery = obj.GetInsertQuery();
                dataBaseUtils.ExecuteQuery(strQuery);
                return Task.FromResult(entity);
            }
            catch (Exception ex) 
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Task<T> ExecuteQuery(string strQuery)
        {
            throw new NotImplementedException();
        }
        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<T>> GetAll()
        {
           try
            {
                DomainObject obj = (DomainObject)Activator.CreateInstance(typeof(T));
                DataBaseUtils dataBaseUtils = new DataBaseUtils();
                string strQuery = obj.GetSelectAllQuery();
                DataSet dataset = dataBaseUtils.GetRecord(strQuery);
                return obj.ToArray<T>(dataset);

            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }

        public Task<IEnumerable<T>> GetByQuery(string strQuery)
        {
            try
            {
                DomainObject obj = (DomainObject)Activator.CreateInstance(typeof(T));
                DataBaseUtils dataBaseUtils = new DataBaseUtils();
                DataSet dataset = dataBaseUtils.GetRecord(strQuery);
                return obj.ToArray<T>(dataset);
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }

        public Task<T> Update(int id, T Enitity)
        {
            try
            {
                DomainObject obj = Enitity as DomainObject;
                DataBaseUtils dataBaseUtils = new DataBaseUtils();
                string strquery = obj.GetUpdateQuery(id.ToString());
                dataBaseUtils.ExecuteQuery(strquery);
                return Task.FromResult(Enitity);
            }
            catch (Exception ex)
            {
                throw new Exception("An Exception Occured", ex);
            }
        }
    }
}
