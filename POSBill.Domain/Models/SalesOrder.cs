using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class SalesOrder : DomainObject
    {
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

        public override Task<IEnumerable<T>> ToArray<T>(DataSet dataSet)
        {
            throw new NotImplementedException();
        }
    }
}
