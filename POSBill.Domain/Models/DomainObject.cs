using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public abstract class DomainObject
    {
        public int Id { get; set; }
        public abstract string GetSelectAllQuery();
        public abstract string GetInsertQuery();
        public abstract string GetUpdateQuery(string id);
        public abstract Task<IEnumerable<T>> ToArray<T>(DataSet dataSet) where T : class;
       
    }
}
