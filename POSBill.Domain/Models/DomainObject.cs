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
        public virtual string GetSelectAllQuery()
        {
            return string.Empty;
        }
        public virtual Task<IEnumerable<T>> ToArray<T>(DataSet dataSet) where T : class
        {
            List<DomainObject> items = new List<DomainObject>();
            return Task.FromResult<IEnumerable<T>>(items as IEnumerable<T>);
        }
    }
}
