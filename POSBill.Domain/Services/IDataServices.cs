using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Services
{
    public interface IDataServices<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id, T Enitity);
        Task<bool>Delete(int id);
        Task<IEnumerable<T>> GetByQuery(string strQuery);
        Task<T> ExecuteQuery(string strQuery);
    }
}
